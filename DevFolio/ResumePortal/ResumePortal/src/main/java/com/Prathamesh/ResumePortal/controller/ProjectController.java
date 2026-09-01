package com.Prathamesh.ResumePortal.controller;

import com.Prathamesh.ResumePortal.service.ProjectService;
import com.Prathamesh.ResumePortal.model.ProjectModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/projects")
@CrossOrigin("http://localhost:4200")
public class ProjectController {

    @Autowired
    private ProjectService service;

    // SAVE / UPDATE
    @PostMapping
    public ProjectModel save(@RequestBody ProjectModel data) {
        return service.save(data);
    }

    // GET ALL
    @GetMapping
    public List<ProjectModel> getAll() {
        return service.getAll();
    }

    // DELETE
    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        service.delete(id);
    }
}
