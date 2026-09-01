package com.Prathamesh.ResumePortal.controller;

import com.Prathamesh.ResumePortal.service.SkillsService;
import com.Prathamesh.ResumePortal.model.SkillsModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/skills")
@CrossOrigin("http://localhost:4200")
public class SkillsController {

    @Autowired
    private SkillsService service;

    @PostMapping
    public SkillsModel save(@RequestBody SkillsModel data) {
        return service.save(data);
    }

    @GetMapping
    public List<SkillsModel> getAll() {
        return service.getAll();
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        service.delete(id);
    }
}
