package com.Prathamesh.ResumePortal.service;

import com.Prathamesh.ResumePortal.model.ExperienceModel;
import com.Prathamesh.ResumePortal.repository.ExperienceRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ExperienceService {

    @Autowired
    private ExperienceRepository repo;

    public ExperienceModel save(ExperienceModel data) {
        return repo.save(data);   // save + update
    }

    public List<ExperienceModel> getAll() {
        return repo.findAll();
    }

    public void delete(Long id) {
        repo.deleteById(id);
    }
}
