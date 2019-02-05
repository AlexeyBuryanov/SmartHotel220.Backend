package com.smarthotel220.reviews.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import springfox.documentation.builders.RequestHandlerSelectors;
import springfox.documentation.service.ApiInfo;
import springfox.documentation.service.Contact;
import springfox.documentation.spi.DocumentationType;
import springfox.documentation.spring.web.plugins.Docket;
import springfox.documentation.swagger2.annotations.EnableSwagger2;

/**
 * Конфиг для swagger
 */
@Configuration
@EnableSwagger2
public class SwaggerConfig {

    // @Bean - указывает, что метод создает компонент, который должен управляться контейнером Spring
    @Bean
    public Docket productApi() {
        Contact contact = new Contact("", "", "");
        ApiInfo apiInfo = new ApiInfo("Review Api", "", "1.0", "", contact, "", "");
        return new Docket(DocumentationType.SPRING_WEB)
                .apiInfo(apiInfo)
                .select().apis(RequestHandlerSelectors.basePackage("com.smarthotel220.reviews.controllers"))
                .build();
    }
}