FROM golang:1.8.0

RUN apt-get update && apt-get install -y netcat
RUN go get github.com/jstemmer/go-junit-report
RUN VER="19.03.9" \
    && curl -L -o /tmp/docker-$VER.tgz https://download.docker.com/linux/static/stable/x86_64/docker-$VER.tgz \
    && tar -xz -C /tmp -f /tmp/docker-$VER.tgz \
    && mv /tmp/docker/* /usr/bin

RUN curl -L https://github.com/docker/compose/releases/download/1.25.5/docker-compose-`uname -s`-`uname -m` > /usr/local/bin/docker-compose \
    &&  chmod +x /usr/local/bin/docker-compose

