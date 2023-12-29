package com.ws2restfulapi.repositories;


import com.ws2restfulapi.models.Vacancy;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface VacancyRepository extends JpaRepository<Vacancy, Long> {
    Optional<Vacancy> findByCity(String city);
}
