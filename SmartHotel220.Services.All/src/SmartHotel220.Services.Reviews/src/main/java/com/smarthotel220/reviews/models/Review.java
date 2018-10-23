package com.smarthotel220.reviews.models;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

import com.fasterxml.jackson.annotation.JsonProperty;

/** Отзыв */
@Entity
public class Review {

    @Id
    @GeneratedValue(strategy= GenerationType.AUTO)
    private Integer id;

    /** Юзер */
    private String userId;

    /** Дата подтверждения/оставления отзыва */
    private Date submitted;

    /** Описание/сообщение */
    @Column(length = 1024)
    private String description;

    /** Отель */
    private Integer hotelId;

    /** Имя пользователя */
    private String userName;


    public Integer getId() {return this.id;}
    public void setId(Integer id) {this.id = id;}

    public Date getSubmitted() {return this.submitted;}
    public void setSubmitted(Date date) {this.submitted = date;}

    public Integer getHotelId() {return this.hotelId;}
    public void setHotelId(int hotel) {this.hotelId = hotel;}

    public void setUserId (String userid) {this.userId = userid;}
    public String getUserId() {return this.userId;}

    public void setDescription (String desc) {this.description = desc;}
    public String getDescription() {return this.description;}

    public String getUserName() { return this.userName;}
    public void setUserName(String value) { this.userName = value;}

    /** Форматируемая дата */
    @JsonProperty("formattedDate")
    public String getFormattedDate() {
        String format = System.getenv("DATE_FORMAT");

        if (format == null) {
            format = "EEE, d MMM yyyy HH:mm:ss";
        }

        SimpleDateFormat sdf = new SimpleDateFormat(format, new Locale("ru"));
        
        return sdf.format(this.submitted);
    } // getFormattedDate
} // Review