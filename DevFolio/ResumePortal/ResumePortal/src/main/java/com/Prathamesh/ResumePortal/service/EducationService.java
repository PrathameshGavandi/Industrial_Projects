package com.Prathamesh.ResumePortal.service;

import com.Prathamesh.ResumePortal.model.EducationModel;
import com.Prathamesh.ResumePortal.repository.EducationRepository;
import org.springframework.stereotype.Service;


import java.util.List;

@Service
public class EducationService {

    private final EducationRepository repository;

    public EducationService(EducationRepository repository) {
        this.repository = repository;
    }

    // Get all education records
    public List<EducationModel> getAll() {
        return repository.findAll();
    }

    // Save or update education
    public EducationModel save(EducationModel education) {
        return repository.save(education);
    }

    // Delete education by id
    public void delete(Long id) {
        repository.deleteById(id);
    }
}
