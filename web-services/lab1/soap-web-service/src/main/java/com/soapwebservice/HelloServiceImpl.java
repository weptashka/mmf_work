package com.soapwebservice;

import jakarta.jws.WebService;

@WebService(
        serviceName = "HelloService",
        portName = "HelloPort",
        targetNamespace = "http://service.ws.sample/",
        endpointInterface = "com.soapwebservice.HelloService")
public class HelloServiceImpl implements HelloService{
    @Override
    public String sayHello(String name){
        return "Hello" + name;
    }
}
