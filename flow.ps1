[CmdletBinding()]
param(
    [Parameter(Position = 0, Mandatory = $true)]
    [ValidateSet('start', 'finish')]
    $Cmd,
    [Parameter(Position = 1, Mandatory = $true)]
    [ValidateSet('feature', 'bugfix', 'release', 'hotfix')]
    $SubCmd,
    [Parameter(Position = 2, Mandatory = $false)]
    [string]
    $Name
)

Push-Location $PSScriptRoot

try {
    # Dirty files
    $dirty = @()
    $dirty += &{ git ls-files -o --exclude-standard }
    $dirty += &{ git diff-index --name-only HEAD }

    if($dirty) {
        Throw "The folder is not clean. Commit or stash changes first."
    }

    # Base branch for the operation
    switch -regex ($SubCmd) {
        'feature|bugfix|release' {
            $base = 'develop'
        }
        'hotfix' {
            $base = 'master'
        }
    }

    # Fallback default name (to the current branch)
    if (-not $Name) {
        switch ($Cmd) {
            'start' {
                Throw 'Missed $Name parameter.'
            }
            'finish' {
                $current = git branch --show-current

                if (-not $current -match "^$SubCmd/") {
                    Throw "$current is not a $SubCmd branch."
                }

                $Name = $branch -replace "^$SubCmd/", ""
            }
        }
    }

    # sync base branch
    git checkout $base && git pull || `
        Throw 'Terminated due to the failure.'

    switch($Cmd) {
        'start' {
            # create the feature/etc branch and set tracking
            git checkout -b "$SubCmd/$Name" && `
                git push -u origin "$SubCmd/$Name" || `
                Throw 'Terminated due to the failure.'
        }
        'finish' {
            # cleanup the feature/etc branch
            git remote prune origin && `
                git branch -d "$SubCmd/$Name" || `
                Throw 'Terminated due to the failure.'
        }
    }
}
finally {
    Pop-Location
}
