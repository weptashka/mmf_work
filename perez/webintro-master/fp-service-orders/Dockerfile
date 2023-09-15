FROM keymetrics/pm2

# Create app directory
WORKDIR /usr/src/app

# Install app dependencies
# A wildcard is used to ensure both package.json AND package-lock.json are copied
# where available (npm@5+)
COPY package*.json ./

ENV NPM_CONFIG_LOGLEVEL warn
RUN npm install
# If you are building your code for production
# RUN npm ci --only=production

# Bundle app source
COPY . .

EXPOSE 10011
#CMD [ "node", "./bin/www" ]
CMD [ "pm2-runtime", "start", "ecosystem.config.js", "--env", "production" ]
