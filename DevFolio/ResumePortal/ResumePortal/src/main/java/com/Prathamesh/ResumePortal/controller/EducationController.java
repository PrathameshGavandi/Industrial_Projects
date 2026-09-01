package com.Prathamesh.ResumePortal.controller;

import com.Prathamesh.ResumePortal.model.EducationModel;
import com.Prathamesh.ResumePortal.service.EducationService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/education")
@CrossOrigin(origins = "http://localhost:4200") // Angular frontend
public class EducationController {

    private final EducationService service;

    public EducationController(EducationService service) {
        this.service = service;
    }

    // Get all education records
    @GetMapping
    public List<EducationModel> getAll() {
        return service.getAll();
    }

    // Create / Save education
    @PostMapping
    public EducationModel create(@RequestBody EducationModel education) {
        return service.save(education);
    }

    // Delete education by id
    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        service.delete(id);
    }
}
