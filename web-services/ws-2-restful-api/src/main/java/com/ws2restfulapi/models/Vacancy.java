package com.ws2restfulapi.models;


import lombok.Builder;
import jakarta.persistence.*;


@Builder
@Entity
@Table(name = "vacancies")
public class Vacancy {
    @Id
    @Column(name = "id", nullable = false)
    private Long id;
    @Column(name = "name")
    private String name;
    @Column(name = "description")
    private String description;
    @Column(name = "salary")
    private double salary;
    @Column(name = "city")
    private String city;
    @Column(name = "is_remote")
    private boolean isRemote;

    public Vacancy() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public double getSalary() {
        return salary;
    }

    public void setSalary(double salary) {
        this.salary = salary;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public boolean isRemote() {
        return isRemote;
    }

    public void setRemote(boolean remote) {
        isRemote = remote;
    }

    public Vacancy(String name, String description, double salary, String city, boolean isRemote){
        this.name = name;
        this.description = description;
        this.salary = salary;
        this.city = city;
        this.isRemote = isRemote;
    }

    public Vacancy(Long id, String name, String description, double salary, String city, boolean isRemote){
        this.id = id;
        this.name = name;
        this.description = description;
        this.salary = salary;
        this.city = city;
        this.isRemote = isRemote;
    }

}
