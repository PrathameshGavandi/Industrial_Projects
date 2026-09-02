package com.Prathamesh.ResumePortal.controller;

import com.Prathamesh.ResumePortal.service.ExperienceService;
import com.Prathamesh.ResumePortal.model.ExperienceModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/experience")
@CrossOrigin("*")
public class ExperienceController {

    @Autowired
    private ExperienceService service;

    // SAVE / UPDATE
    @PostMapping
    public ExperienceModel save(@RequestBody ExperienceModel data) {
        return service.save(data);
    }

    // GET ALL
    @GetMapping
    public List<ExperienceModel> getAll() {
        return service.getAll();
    }

    // DELETE
    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        service.delete(id);
    }
}
