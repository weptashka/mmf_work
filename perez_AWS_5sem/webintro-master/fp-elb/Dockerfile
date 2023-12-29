FROM alpine:3.11
RUN apk --no-cache add ca-certificates tzdata
RUN set -ex; \
	apkArch="$(apk --print-arch)"; \
	case "$apkArch" in \
		armhf) arch='armv6' ;; \
		aarch64) arch='arm64' ;; \
		x86_64) arch='amd64' ;; \
		*) echo >&2 "error: unsupported architecture: $apkArch"; exit 1 ;; \
	esac; \
	wget --quiet -O /tmp/traefik.tar.gz "https://github.com/containous/traefik/releases/download/v2.2.1/traefik_v2.2.1_linux_$arch.tar.gz"; \
	tar xzvf /tmp/traefik.tar.gz -C /usr/local/bin traefik; \
	rm -f /tmp/traefik.tar.gz; \
	chmod +x /usr/local/bin/traefik

# Comment if use command line options, since they are mutually exclusive
# COPY ./traefik/traefik.toml /etc/traefik/traefik.toml
COPY ./entrypoint.sh /
RUN ["chmod", "+x", "/entrypoint.sh"]

EXPOSE 80
ENTRYPOINT ["/entrypoint.sh"]
CMD ["traefik"]
