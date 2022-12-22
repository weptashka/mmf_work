package com.bsu.java.methods.lab4;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class AOReplacing {
    private Stream<String> data;

    public AOReplacing(String path) throws IOException {
        this.data = Files.lines(Paths.get(path));
    }


    public void replaceao(){
        List<String> result  = this.data
                .map(line -> line.replace("PA","PO"))
                .map(line -> line.replace("Pa","Po"))
                .map(line -> line.replace("pa","po"))
                .map(line -> line.replace("pA","pO"))
                .collect(Collectors.toList());
        result.forEach(System.out::println);
    }


}
