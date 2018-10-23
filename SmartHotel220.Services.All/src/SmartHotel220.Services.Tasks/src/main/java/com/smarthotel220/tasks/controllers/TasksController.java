package com.smarthotel220.tasks.controllers;

import com.smarthotel220.tasks.models.Task;
import com.smarthotel220.tasks.repositories.TaskRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class TasksController {

    // @Autowired - помечает конструктор, поля, геттеры/сеттеры или конфигурационный метод, 
    // который должен быть настроен средствами внедрения зависимостей Spring
    @Autowired
    private TaskRepository taskRepository;

    // @GetMapping("") - аннотация для сопоставления запросов HTTP GET на конкретные методы обработчика
    // @ResponseBody - аннотация, указывающая, что возвращаемое значение метода, должны быть привязаны к body веб-ответа
    /**
     * Получить все задачи
     */
    @GetMapping("/tasks")
    public @ResponseBody
    Iterable<Task> getAll() {
        return taskRepository.findAll(new Sort(Sort.Direction.DESC, "submitted"));
    }

    /**
     * Получить все задачи в статусе ожидания
     */
    @GetMapping("/tasks/pending")
    public @ResponseBody
    Iterable<Task> getPending() {
        return taskRepository.findByResolved(false, new Sort(Sort.Direction.DESC, "submitted"));
    }

    // @PutMapping("") - аннотация для сопоставления запросов HTTP PUT на конкретные методы обработчика
    // @PathVariable - аннотация, указывающая, что параметр метода должен быть привязан к переменной шаблона URI
    /**
     * Решить задачу
     */
    @PutMapping("/tasks/resolved/{id}")
    public @ResponseBody
    ResponseEntity resolveTask(@PathVariable int id) {
        // Находим задачу по id
        Task task = taskRepository.findOne(id);

        if (task == null) {
            return new ResponseEntity(HttpStatus.NOT_FOUND);
        }

        // Если нашло
        task.setResolved(true);
        taskRepository.save(task);
        
        return new ResponseEntity(task, HttpStatus.OK);
    }

    /**
     * Пометить, как нерешённая задача
     */
    @PutMapping("/tasks/pending/{id}")
    public @ResponseBody
    ResponseEntity unresolveTask(@PathVariable int id) {
        // Находим задачу по id
        Task task = taskRepository.findOne(id);

        if (task == null) {
            return new ResponseEntity(HttpStatus.NOT_FOUND);
        }

        // Если нашло
        task.setResolved(false);
        taskRepository.save(task);

        return new ResponseEntity(task, HttpStatus.OK);
    }

    // @PostMapping("") - аннотация для сопоставления запросов HTTP POST на конкретные методы обработчика
    // @RequestBody - аннотация, указывающая, что параметр метода, должен быть привязан к телу веб-запроса
    /**
     * Изменить статус задачи. POST-запрос
     */
    @PostMapping("/tasks/{id}")
    public @ResponseBody
    ResponseEntity changeStatus(@PathVariable int id, @RequestBody Task newData) {
        // Находим задачу по id
        Task task = taskRepository.findOne(id);

        if (task != null) {
            return new ResponseEntity(HttpStatus.BAD_REQUEST);
        }

        // Если нашло
        task.setResolved(newData.getResolved());
        taskRepository.save(task);

        return new ResponseEntity(task, HttpStatus.OK);
    } // changeStatus
} // TasksController