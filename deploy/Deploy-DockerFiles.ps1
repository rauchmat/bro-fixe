function Deploy-DockerFiles {
    param (
        [string]$SshServer,
        [int]$SshPort,
        [string]$Environment,
        [string]$TargetPath
    )

    scp -P $SshPort "../src/docker-compose.yml" "docker-compose.$Environment.yml" "${SshServer}:$TargetPath"
}