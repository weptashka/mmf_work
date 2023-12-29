package com.lab4.lab4web.service;


import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.lab4.lab4web.model.Translation;
import com.lab4.lab4web.model.TranslationResponse;
import com.lab4.lab4web.repository.TranslationRepository;
import org.apache.commons.io.FileUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.util.UriComponentsBuilder;
import org.springframework.web.util.UriUtils;

import java.io.File;
import java.io.IOException;
import java.net.URI;
import java.net.URLEncoder;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.nio.charset.StandardCharsets;
import java.util.List;
import java.util.Optional;

@Service
public class TranslationService {

    private final TranslationRepository translationRepository;

    private static final String API_URL = "https://translated-mymemory---translation-memory.p.rapidapi.com/get";
    private static final String API_KEY = "26fbfc03aemsh5ef69ca2699a226p1446fajsn2e064e985019";

    @Autowired
    public TranslationService(TranslationRepository translationRepository) {
        this.translationRepository = translationRepository;
    }

    public String translate(String sourceLang, String targetLang, String text) throws IOException, InterruptedException {
        String apiUrlWithParams = String.format("%s?langpair=%s&q=%s", API_URL, sourceLang + "|" + targetLang, text);

        HttpHeaders headers = new HttpHeaders();
        headers.add("X-RapidAPI-Key", API_KEY);
        headers.add("X-RapidAPI-Host", "translated-mymemory---translation-memory.p.rapidapi.com");

        HttpEntity<?> requestEntity = new HttpEntity<>(headers);

        ResponseEntity<String> responseEntity = new RestTemplate().exchange(
                apiUrlWithParams,
                HttpMethod.GET,
                requestEntity,
                String.class);

        ObjectMapper objectMapper = new ObjectMapper();
        TranslationResponse translationResponse = objectMapper.readValue(responseEntity.getBody(), TranslationResponse.class);

        String translatedText = translationResponse.getResponseData().getTranslatedText();

        System.out.println(translatedText);
        saveTranslation(translatedText, text, concureLangs(sourceLang, targetLang));

        return responseEntity.getBody();
    }

    public void saveTranslation(String translationedText, String source, String languages){
        Translation translation = new Translation();
        translation.setTranslatedText(translationedText);
        translation.setSourceText(source);
        translation.setLanguages(languages);
        translationRepository.save(translation);
    }

    public String concureLangs(String a, String b){
        StringBuilder stringBuilder = new StringBuilder("from");
        stringBuilder.append(" " + a).append(" to ").append(b);
        return stringBuilder.toString();
    }

    public List<Translation> getAllTranslations() {
        return translationRepository.findAll();
    }

    public Optional<Translation> getTranslationById(Long id) {
        return translationRepository.findById(id);
    }


    public void saveTranslationToFile(Translation translation) {
        // Создаем объект ObjectMapper для преобразования объекта в JSON
        ObjectMapper objectMapper = new ObjectMapper();

        // Получаем JSON-представление объекта Translation
        try {
            String json = objectMapper.writeValueAsString(translation);

            // Задаем путь для сохранения файла (здесь используется текущая директория, но вы можете указать свой путь)
            String filePath = String.format("translations/%d_translation.json", translation.getId());

            // Создаем файл и записываем в него JSON
            File file = new File(filePath);
            FileUtils.write(file, json, StandardCharsets.UTF_8);

            // Ваш код для логирования или обработки сохранения
        } catch (IOException e) {
            // Обработка ошибок записи в файл, например, логирование или выброс исключения
            e.printStackTrace();
        }
    }
}
