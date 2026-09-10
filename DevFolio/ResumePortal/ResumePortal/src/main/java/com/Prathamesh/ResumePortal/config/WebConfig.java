package com.Prathamesh.ResumePortal.config;

import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@Configuration
public class WebConfig implements WebMvcConfigurer {

    @Override
    public void addCorsMappings(CorsRegistry registry) {
        registry.addMapping("/**") // तुमच्या सर्व API एंडपॉईंट्ससाठी
                .allowedOrigins("*") // जगातील सर्व फ्रंटएंड लिंक्सना परवानगी (पोर्टफोलिओसाठी सर्वोत्तम)
                .allowedMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                .allowedHeaders("*");
    }
}
