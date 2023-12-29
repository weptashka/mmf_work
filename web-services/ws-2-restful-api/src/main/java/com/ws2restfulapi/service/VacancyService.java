package com.ws2restfulapi.service;

import com.ws2restfulapi.models.Vacancy;

import java.util.List;

public interface VacancyService {
    List<Vacancy> getVacancies();
    Vacancy getVacancy(long id);
    boolean postVacancy(Vacancy vacancy);
    boolean putVacancy(Vacancy vacancy, long id);
    boolean deleteVacancy(long id);
}
