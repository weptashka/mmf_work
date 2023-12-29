package com.ws2restfulapi.controllers;

import com.ws2restfulapi.models.Vacancy;
import com.ws2restfulapi.service.VacancyService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class VacancyController {
    private final VacancyService vacancyService;

    @Autowired
    public VacancyController(VacancyService vacancyService){
        this.vacancyService = vacancyService;
    }


    @GetMapping(value = "/api/vacancies")
    public ResponseEntity<Object> getAll() {
        final List<Vacancy> vacancies = vacancyService.getVacancies();

        return vacancies != null &&  !vacancies.isEmpty()
                ? new ResponseEntity<>(vacancies, HttpStatus.OK)
                : new ResponseEntity<>("Not found", HttpStatus.NOT_FOUND);
    }


    @GetMapping(value = "/api/vacancy")
    public ResponseEntity<Object> getOneVacancy(@RequestParam(required=false) long id) {
        final Vacancy vacancy = vacancyService.getVacancy(id);

        return vacancy != null
                ? new ResponseEntity<>(vacancy, HttpStatus.OK)
                : new ResponseEntity<>("Not found", HttpStatus.NOT_FOUND);
    }


    @PostMapping(value = "/api/vacancy")
    public ResponseEntity<?> post(@RequestBody Vacancy vacancy) {
        final boolean created = vacancyService.postVacancy(vacancy);

        return created
                ? new ResponseEntity<>(HttpStatus.CREATED)
                : new ResponseEntity<>("Vacancy with such id already exists", HttpStatus.METHOD_NOT_ALLOWED);
    }


    @PutMapping(value = "/api/vacancy")
    public ResponseEntity<?> put(@RequestParam(required=false) long id, @RequestBody Vacancy vacancy) {
        final boolean updated = vacancyService.putVacancy(vacancy, id);

        return updated
                ? new ResponseEntity<>(HttpStatus.OK)
                : new ResponseEntity<>("Vacancy with such id doesn't exist", HttpStatus.METHOD_NOT_ALLOWED);
    }

    @DeleteMapping(value = "/api/vacancy")
    public ResponseEntity<?> delete(@RequestParam(required=false) long id) {
        final boolean deleted = vacancyService.deleteVacancy(id);

        return deleted
                ? new ResponseEntity<>(HttpStatus.OK)
                : new ResponseEntity<>(HttpStatus.NOT_MODIFIED);
    }


}
