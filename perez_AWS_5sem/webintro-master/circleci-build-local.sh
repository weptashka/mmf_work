circleci config validate
circleci config process .circleci/config.yml > .circleci/process.yml
circleci local execute -c .circleci/process.yml $(cat .circle.env) --job build 
