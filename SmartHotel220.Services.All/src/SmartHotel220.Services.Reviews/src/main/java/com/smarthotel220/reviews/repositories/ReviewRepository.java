package com.smarthotel220.reviews.repositories;

import java.util.List;

import com.smarthotel220.reviews.models.Review;

import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Описывает репозиторий по работе с отзывами
 */
public interface ReviewRepository extends JpaRepository<Review, Integer> {

    /** Найти отзывы по отелю */
    List<Review> findByHotelId(int hotelId, Sort sort);
}