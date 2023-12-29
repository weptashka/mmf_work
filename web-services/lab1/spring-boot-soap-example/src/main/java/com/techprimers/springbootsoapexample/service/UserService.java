package com.techprimers.springbootsoapexample.service;

import com.techprimers.spring_boot_soap_example.User;
import jakarta.annotation.PostConstruct;
import org.springframework.stereotype.Service;

import java.util.HashMap;
import java.util.Map;

@Service
public class UserService {

    private static final Map<String, User> users = new HashMap<>();

    @PostConstruct
    public void initialize() {

        User peter = new User();
        peter.setEmpId(1111);
        peter.setName("Peter");
        peter.setSalary(12000);

        User sam = new User();
        sam.setEmpId(1112);
        sam.setName("Sam");
        sam.setSalary(32000);

        User ryan = new User();
        ryan.setEmpId(1113);
        ryan.setName("Ryan");
        ryan.setSalary(16000);

        users.put(peter.getName(), peter);
        users.put(sam.getName(), sam);
        users.put(ryan.getName(), ryan);
    }


    public User getUsers(String name) {
        return users.get(name);
    }
}
