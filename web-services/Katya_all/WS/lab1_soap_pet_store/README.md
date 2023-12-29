## Pet store

Welcome to the Petstore Simple SOAP project! This project allows you to access information about pets using the SOAP (Simple Object Access Protocol) web service.

## Stack

- NestJs
- MongoDB
- Prisma

## Installation

```bash
$ npm install
```

## Running the app

1. Copy .env.example to .env. Set correct `DATABASE_URL` value

2. Run following:
```bash
# development
$ npm run start
```

## How to use

Use Postman to send requests to the API

[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/19185799-dd8688a1-fa42-46e0-ade8-d63162ab33aa?action=collection%2Ffork&source=rip_markdown&collection-url=entityId%3D19185799-dd8688a1-fa42-46e0-ade8-d63162ab33aa%26entityType%3Dcollection%26workspaceId%3Ddf436e13-5c79-480c-867a-cf69916dd26c)

Or use this examples

**Get Pet Information**

```xml
<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:web="http://www.example.com/petstore">
   <soapenv:Header/>
   <soapenv:Body>
      <web:getPetInfo>
         <web:petId>1</web:petId>
      </web:getPetInfo>
   </soapenv:Body>
</soapenv:Envelope>
```
