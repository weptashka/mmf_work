package com.ws2restfulapi.repository;

import com.ws2restfulapi.models.Vacancy;
import com.ws2restfulapi.repositories.VacancyRepository;


import org.assertj.core.api.Assertions;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.List;
import java.util.Optional;

@RunWith(SpringRunner.class)
@DataJpaTest
@AutoConfigureTestDatabase(replace = AutoConfigureTestDatabase.Replace.NONE)
public class VacancyRepositoryTests {

    @Autowired
    private VacancyRepository vacancyRepository;

    //tests witch read db, temporary can modify some info, but after working, return everything as it was
    @Test
    public void VacancyRepository_SaveAll_ReturnSavedVacancy(){
        //Arrange
    Vacancy vacancy = Vacancy.builder()
            .id(11L)
            .name("PM")
            .description("We need Project Manager, please")
            .salary(2000)
            .city("Gomel")
            .isRemote(false)
            .build();

        //Act
        Vacancy savedVacancy = vacancyRepository.save(vacancy);

        //Assert
        Assertions.assertThat(savedVacancy).isNotNull();
        Assertions.assertThat(savedVacancy.getId()).isGreaterThan(0);
    }


    @Test
    public void VacancyRepository_GetAll_ReturnMoreThenOneVacancy() {
        Vacancy vacancy = Vacancy.builder()
                .id(12L)
                .name("PM")
                .description("We need Project Manager, please")
                .salary(2000)
                .city("Gomel")
                .isRemote(false)
                .build();
        Vacancy vacancy2 = Vacancy.builder()
                .id(13L)
                .name("PM")
                .description("We need Project Manager, please")
                .salary(2000)
                .city("Gomel")
                .isRemote(false)
                .build();

        vacancyRepository.save(vacancy);
        vacancyRepository.save(vacancy2);

        List<Vacancy> vacancyList = vacancyRepository.findAll();

        Assertions.assertThat(vacancyList).isNotNull();
        Assertions.assertThat(vacancyList.size()).isGreaterThanOrEqualTo(2);
    }

    @Test
    public void VacancyRepository_FindById_ReturnVacancy() {
        Vacancy vacancy = Vacancy.builder()
                .id(13L)
                .name("PM")
                .description("We need Project Manager, please")
                .salary(2000)
                .city("Gomel")
                .isRemote(false)
                .build();

        vacancyRepository.save(vacancy);

        Vacancy vacancyList = vacancyRepository.findById(vacancy.getId()).get();

        Assertions.assertThat(vacancyList).isNotNull();
    }


    @Test
    public void VacancyRepository_FindByCity_ReturnVacancyNotNull() {
        Vacancy vacancy = Vacancy.builder()
                .id(13L)
                .name("PM")
                .description("We need Project Manager, please")
                .salary(2000)
                .city("Gomel")
                .isRemote(false)
                .build();

        vacancyRepository.save(vacancy);

        Vacancy pokemonList = vacancyRepository.findByCity(vacancy.getCity()).get();

        Assertions.assertThat(pokemonList).isNotNull();
    }



    @Test
    public void VacancyRepository_UpdateVacancy_ReturnVacancyNotNull() {
        Vacancy vacancy = Vacancy.builder()
                .id(13L)
                .name("PM")
                .description("We need Project Manager, please")
                .salary(2000)
                .city("Gomel")
                .isRemote(false)
                .build();

        vacancyRepository.save(vacancy);

        Vacancy vacancySave = vacancyRepository.findById(vacancy.getId()).get();
        vacancySave.setCity("Golang dev");
        vacancySave.setName("Ivye");

        Vacancy updatedVacancy = vacancyRepository.save(vacancySave);

        Assertions.assertThat(updatedVacancy.getName()).isNotNull();
        Assertions.assertThat(updatedVacancy.getCity()).isNotNull();
    }



    @Test
    public void VacancyRepository_VacancyDelete_ReturnVacancyIsEmpty() {
        Vacancy vacancy = Vacancy.builder()
                .id(13L)
                .name("PM")
                .description("We need Project Manager, please")
                .salary(2000)
                .city("Gomel")
                .isRemote(false)
                .build();

        vacancyRepository.save(vacancy);

        vacancyRepository.deleteById(vacancy.getId());
        Optional<Vacancy> pokemonReturn = vacancyRepository.findById(vacancy.getId());

        Assertions.assertThat(pokemonReturn).isEmpty();
    }

}
