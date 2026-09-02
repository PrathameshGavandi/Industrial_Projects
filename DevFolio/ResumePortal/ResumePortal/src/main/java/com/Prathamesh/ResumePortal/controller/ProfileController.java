package com.Prathamesh.ResumePortal.controller;

import com.Prathamesh.ResumePortal.service.ProfileService;
import com.Prathamesh.ResumePortal.model.ProfileModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/profile")
@CrossOrigin("*")
public class ProfileController {

    @Autowired
    private ProfileService service;

    // SAVE / UPDATE
    @PostMapping
    public ProfileModel save(@RequestBody ProfileModel data) {
        return service.save(data);
    }

    // GET ALL
    @GetMapping
    public List<ProfileModel> getAll() {
        return service.getAll();
    }

    // DELETE
    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id) {
        service.delete(id);
    }
}
