package com.smarthotel220.reviews.controllers;

import com.smarthotel220.reviews.models.Review;
import com.smarthotel220.reviews.repositories.ReviewRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ReviewsController {

    // @Autowired - помечает конструктор, поля, геттеры/сеттеры или конфигурационный метод, 
    // который должен быть настроен средствами внедрения зависимостей Spring
    @Autowired
    private ReviewRepository reviewRepository;

    // @CrossOrigin() - разрешает cross-origin запросы
    // @GetMapping("") - аннотация для сопоставления запросов HTTP GET на конкретные методы обработчика
    /** Получить отзывы по отелю */
    @CrossOrigin()
    @GetMapping("/reviews/hotel/{id}")
    public @ResponseBody
    Iterable<Review> getByHotel(@PathVariable int id) {
        return reviewRepository.findByHotelId(id, new Sort(Sort.Direction.DESC, "submitted"));
    }
}