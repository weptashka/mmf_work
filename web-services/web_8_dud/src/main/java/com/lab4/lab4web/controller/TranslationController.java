package com.lab4.lab4web.controller;


import com.lab4.lab4web.model.Translation;
import com.lab4.lab4web.service.TranslationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.io.FileWriter;
import java.io.IOException;
import java.util.Optional;

@RestController
@RequestMapping("/translate")
public class TranslationController {

    private final TranslationService translationService;

    @Autowired
    public TranslationController(TranslationService translationService) {
        this.translationService = translationService;
    }


    //ГЛАВНЫЙ МЕТОД
    @GetMapping()
    public String translate(
            @RequestParam(name = "langpair") String langpair,
            @RequestParam(name = "q") String text) throws IOException, InterruptedException {
        // Разбиваем langpair на sourceLang и targetLang
        String[] languages = langpair.split("\\|");
        String sourceLang = languages[0];
        String targetLang = languages[1];

        return translationService.translate(sourceLang, targetLang, text);
    }


    @GetMapping("/saveIntoFileById/{id}")
    public String saveTranslationIntoFileById(@PathVariable Long id) {
        Optional<Translation> optionalTranslation = translationService.getTranslationById(id);

        if (optionalTranslation.isPresent()) {
            Translation translation = optionalTranslation.get();
            String fileName = String.format("translation_%d.txt", translation.getId());

            try (FileWriter writer = new FileWriter(fileName)) {
                writer.write( translation.getLanguages() + "\n");
                writer.write("sourse text: " + translation.getSourceText() + "\n");
                writer.write("Text after translation: " + translation.getTranslatedText() + "\n");

                return "Data saved into file: " + fileName;
            } catch (IOException e) {
                e.printStackTrace();
                return "Error saving data into file";
            }
        } else {
            return "Translation not found with id: " + id;
        }
    }

    @GetMapping("/saveJson/{id}")
    public String saveTranslationIntoJsonFileById(@PathVariable Long id){
        Optional<Translation> optionalTranslation = translationService.getTranslationById(id);
        if(optionalTranslation.isPresent()){
            Translation translation = optionalTranslation.get();
            translationService.saveTranslationToFile(translation);
            return "saved as json";
        }else {
            return "Translation not found with id: " + id;
        }
    }
}
