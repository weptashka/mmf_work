package com.ws2restfulapi.service;

import com.ws2restfulapi.models.Vacancy;
import com.ws2restfulapi.repositories.VacancyRepository;
import org.springframework.stereotype.Service;

import java.util.List;


@Service
public class VacancyServiceImpl implements VacancyService{

    private final VacancyRepository vacancyRepository;

    public VacancyServiceImpl(VacancyRepository vacancyRepository) {
        this.vacancyRepository = vacancyRepository;
    }


    @Override
    public boolean postVacancy(Vacancy vacancy) {
        if (vacancyRepository.existsById(vacancy.getId())) {
            return false;
        }
        else {
            vacancyRepository.save(vacancy);
            return true;
        }
    }

    @Override
    public List<Vacancy> getVacancies() {
        return vacancyRepository.findAll();
    }

    @Override
    public Vacancy getVacancy(long id) {
        List<Vacancy> vacancies = vacancyRepository.findAll();

        for (Vacancy vacancy : vacancies) {
            if (vacancy.getId() == id) {
                return vacancy;
            }
        }
        return null;

//        return vacancyRepository.getOne(id);
    }

    @Override
    public boolean putVacancy(Vacancy vacancy, long id) {
        if (vacancyRepository.existsById(id)) {
            if(vacancy.getId() == id){
                vacancyRepository.save(vacancy);
            }
            vacancyRepository.deleteById(id);
            vacancyRepository.save(vacancy);
            return true;
        }else {
            return false;
        }
    }

    @Override
    public boolean deleteVacancy(long id) {
        if (vacancyRepository.existsById(id)) {
            vacancyRepository.deleteById(id);
            return true;
        }
        return false;
    }

}
