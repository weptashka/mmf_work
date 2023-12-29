package com.lab4.lab4web.model;


import jakarta.persistence.*;
import lombok.*;

@Entity
@Table(name = "translation")
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class Translation {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String sourceText;
    private String translatedText;
    private String languages;
}