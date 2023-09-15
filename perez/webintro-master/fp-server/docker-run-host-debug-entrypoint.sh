echo 'Run after login /usr/local/openresty/bin/openresty as defined in parent Dockerfile';
docker run --rm -it --name=fp-nginx -p 9001:80 -v ${PWD}/html:/usr/local/openresty/nginx/html -v ${PWD}/templates:/usr/local/openresty/nginx/templates -v ${PWD}/conf/conf.d:/etc/nginx/conf.d -v ${PWD}/conf/nginx.conf:/usr/local/openresty/nginx/conf/nginx.conf  --entrypoint sh fp/nginx

