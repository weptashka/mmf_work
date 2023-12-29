package com.lab4.lab4web.repository;


import com.lab4.lab4web.model.Translation;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

public interface TranslationRepository extends JpaRepository<Translation, Long> {
}