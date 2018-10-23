package com.smarthotel220.tasks.seeders;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.smarthotel220.tasks.models.Task;
import com.smarthotel220.tasks.repositories.TaskRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.event.ContextRefreshedEvent;
import org.springframework.context.event.EventListener;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Component;

/**
 * Для заполнения базы
 */
@Component
public class TaskSeeder {

    // Для упрощённой работы с JDBC
    private JdbcTemplate jdbcTemplate;
    // Репозиторий задач
    private TaskRepository taskRepository;

    // @Autowired - помечает конструктор, поля, геттеры/сеттеры или конфигурационный метод, 
    // который должен быть настроен средствами внедрения зависимостей Spring
    @Autowired
    public TaskSeeder(TaskRepository taskRepository, JdbcTemplate jdbcTemplate) {
        this.taskRepository = taskRepository;
        this.jdbcTemplate = jdbcTemplate;
    }

    // @EventListener - отмечае метод в качестве слушателя для событий приложения.
    // ContextRefreshedEvent - событие, возникающее при инициализации или обновлении ApplicationContext.
    @EventListener
    public void seed(ContextRefreshedEvent event) {
        // Проверяем готовность сидинга
        boolean alreadySeeded = taskRepository.count() > 0;

        if (alreadySeeded) {
            return;
        }

        // Статусы задач
        List<String> statuses = new ArrayList<String>();
        statuses.add("в ожидании");
        statuses.add("решена");

        // Типы задач
        Map<Integer, String> taskTypes = new HashMap<>();
        taskTypes.put(5, "смена полотенец");
        taskTypes.put(2, "уборка комнаты");
        taskTypes.put(3, "новые гости");
        taskTypes.put(4, "обслуживание номеров");
        taskTypes.put(1, "кондиционер");

        // Задачи
        List<TaskAndType> tasks = new ArrayList<>();
        tasks.add(new TaskAndType(1,"Не работает кондиционер. Пульт не реагирует и он продолжает дуть холодным воздухом."));
        tasks.add(new TaskAndType(1,"Мой кондиционер пахнет плесенью, сделайте что-нибудь."));
        tasks.add(new TaskAndType(1,"Кондиционер слишком громкий, звучит, как газонокосилка."));
        tasks.add(new TaskAndType(1, "Кондиционер не работает, нет питания, нет вентилятора ... Ничего."));
        tasks.add(new TaskAndType(4, "Обслуживание в номере забыли мои напитки, я заказал газированный напиток и виноградный сок"));
        tasks.add(new TaskAndType(4, "Я заказал свой завтрак более часа назад ... где мой блин ... ????"));
        tasks.add(new TaskAndType(4, "Мои дети заказали кучу еды по телевизору, и мне нужно отменить заказы на номер. Как можно скорее"));
        tasks.add(new TaskAndType(3, "Я потерял ключ от комнаты, мне нужно заменить ключ"));
        tasks.add(new TaskAndType(3, "Я хочу окно с западной стороны, очень важно для моего сна, пожалуйста, переместите мне кровать."));
        tasks.add(new TaskAndType(3, "Могу ли я получать ежедневную газету?"));
        tasks.add(new TaskAndType(3, "Поставьте раскладную кровать для одного из моих детей."));
        tasks.add(new TaskAndType(5, "Пожалуйста, придите ко мне сегодня днем и замените полотенца"));
        tasks.add(new TaskAndType(2, "Уберите комнату и протрите пыль, здесь много пыли."));
        tasks.add(new TaskAndType(2, "Стерелизуйте комнату с отбеливанием, пожалуйста, у меня аллегрия."));
        tasks.add(new TaskAndType(2, "Убери туалет, душ и раковину."));

        for (int i = 0; i < tasks.size(); i++) {
            Task task = new Task();
            task.setUserId("alexeyburyanov@gmail.com");
            task.setRoom((i+10) * 4);

            TaskAndType ttype = tasks.get(i);
            task.setTaskType(ttype.type);
            task.setResolved(false);
            task.setDescription(ttype.task);

            taskRepository.save(task);
        } // for i
    } // seed
}

/**
 * Задача и тип
 */
class TaskAndType {
    
    public String task;
    public int type;

    public TaskAndType(int type, String task) {
        this.task = task;
        this.type =type;
    }
}