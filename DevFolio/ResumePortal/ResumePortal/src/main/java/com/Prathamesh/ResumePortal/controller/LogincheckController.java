package com.Prathamesh.ResumePortal.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import com.Prathamesh.ResumePortal.model.LogincheckModel;  // Entity class
import com.Prathamesh.ResumePortal.repository.LogincheckRepository;

@RestController
@RequestMapping("/api")
@CrossOrigin(origins = {
        "http://localhost:4200",
        "https://prathamesh-gavandi-portfolio.onrender.com"
}) // Angular frontend allow
public class LogincheckController {

    @Autowired
    private LogincheckRepository logincheckRepository;

    // POST API to validate login
    @PostMapping("/login")
    public boolean login(@RequestBody LogincheckModel logincheckModel) {
        LogincheckModel l = logincheckRepository.findByUsernameAndPassword(logincheckModel.getUsername(), logincheckModel.getPassword());
        return l != null; // true if user exists in logincheck table
    }
}
