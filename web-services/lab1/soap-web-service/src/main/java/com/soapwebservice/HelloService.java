package com.soapwebservice;

import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import jakarta.jws.WebResult;
import jakarta.jws.WebService;
import jakarta.xml.ws.RequestWrapper;
import jakarta.xml.ws.ResponseWrapper;


//веб-сервис, который принимает строку (ваше имя) и  в ответ здоровается с вами
@WebService(targetNamespace = "http://service.ws.sample/", name = "HelloService")
public interface HelloService {
    @WebResult(name = "return", targetNamespace = "")
    @RequestWrapper(
            localName = "sayHello",
            targetNamespace = "http://service.ws.sample/",
            className = "com.soapwebservice.RequestSayHello")
    @WebMethod(action = "urn:SayHello")
    @ResponseWrapper(
            localName = "sayHelloResponse",
            targetNamespace = "http://service.ws.sample/",
            className = "com.soapwebservice.SayHelloResponse")
    String sayHello(@WebParam(name = "name", targetNamespace = "") String name);
}
