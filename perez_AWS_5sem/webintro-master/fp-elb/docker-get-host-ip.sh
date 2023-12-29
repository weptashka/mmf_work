# Check https://forums.docker.com/t/accessing-host-machine-from-within-docker-container/14248/22 
# You may use some of them: 
# --env "DOCKER_HOST=$(hostname -I)" 
# host.docker.internal
docker network inspect bridge --format='{{( index .IPAM.Config 0).Gateway}}'
