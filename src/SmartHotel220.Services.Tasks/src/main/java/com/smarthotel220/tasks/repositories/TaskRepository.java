package com.smarthotel220.tasks.repositories;

import java.util.List;

import com.smarthotel220.tasks.models.Task;

import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Описывает репозиторий по работе с задачами
 */
public interface TaskRepository extends JpaRepository<Task, Integer> {

    /** Найти задачи по степени их решённости */
    List<Task> findByResolved(boolean resolved, Sort sort);
}
