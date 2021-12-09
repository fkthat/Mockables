[CmdletBinding()]
param(
    [Parameter(Position = 0, Mandatory = $true)]
    [ValidateSet('start', 'finish')]
    $Cmd,
    [Parameter(Position = 2, Mandatory = $false)]
    [string]
    $Name
)

Push-Location $PSScriptRoot

try {
    $exeError = "Terminated due to the failure."

    # Dirty files
    $dirty = @()
    $dirty += &{ git ls-files -o --exclude-standard }
    $dirty += &{ git diff-index --name-only HEAD }

    if($dirty) {
        throw "The folder is not clean. Commit or stash changes first."
    }

    # Fallback default name (to the current branch)
    if (-not $Name) {
        switch ($Cmd) {
            'start' {
                throw 'Missed $Name parameter.'
            }
            'finish' {
                $current = git branch --show-current

                if (-not ($current -match "^$SubCmd/")) {
                    throw "$current is not a $SubCmd branch."
                }

                $Name = $current -replace "^$SubCmd/", ""
            }
        }
    }

    switch($Cmd) {
        'start' {
            if (-not $Name) {
                throw 'Missed $Name parameter.'
            }

            # create the feature/etc branch and set tracking
            git checkout master && `
                git pull && `
                git checkout -b "$Name" && `
                git push -u origin "$Name" || `
                &{ throw $exeError }
        }
        'finish' {
            if (-not $Name) {
                $Name = git branch --show-current
            }

            if($Name -eq 'master') {
                throw 'Cannot finish master.'
            }

            if($current -eq 'master' -and -not $Name) {
                throw 'Missed $Name parameter.'
            }

            # cleanup the feature branch
            git checkout master && `
                git pull && `
                git remote prune origin && `
                git branch -d "$Name" || `
                &{ throw $exeError }
        }
    }
}
catch {
    Write-Error $_
}
finally {
    Pop-Location
}
