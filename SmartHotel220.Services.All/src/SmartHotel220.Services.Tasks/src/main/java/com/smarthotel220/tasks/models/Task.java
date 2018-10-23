package com.smarthotel220.tasks.models;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

/**
 * Задача
 */
@Entity
public class Task {

    public Task(){
        submitted = new Date();
    }

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;

    /** Пользователь */
    private String userId;

    /** Номер */
    private int room;

    /** Решена ли */
    private boolean resolved;

    /** Тип задачи */
    private int taskType;

    /** Дата подтверждения/получения */
    private Date submitted;

    /** Описание */
    private String description;


    public Integer getId() {return this.id;}
    public void setId(Integer id) {this.id = id;}

    public void setRoom(Integer room) {this.room = room;}
    public Integer getRoom() {return this.room;}

    public void setUserId (String userid) {this.userId = userid;}
    public String getUserId() {return this.userId;}

    public boolean getResolved() {return this.resolved;}
    public void setResolved(boolean resolved) {this.resolved = resolved;}

    public int getTaskType() {return this.taskType;}
    public void setTaskType(int taskType) {this.taskType = taskType;}

    public void setDescription (String desc) {this.description = desc;}
    public String getDescription() {return this.description;}
}