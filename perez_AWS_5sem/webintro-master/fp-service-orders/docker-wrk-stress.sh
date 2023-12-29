docker run --rm --link=fp-orders -v $(pwd):/data skandyla/wrk -s stress.lua -t5 -c30 -d10 http://fp-orders:10011/api/v1/tea/spots
