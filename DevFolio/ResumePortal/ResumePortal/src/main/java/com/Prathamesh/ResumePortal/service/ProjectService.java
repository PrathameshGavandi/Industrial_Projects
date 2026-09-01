package com.Prathamesh.ResumePortal.service;

import com.Prathamesh.ResumePortal.model.ProjectModel;
import com.Prathamesh.ResumePortal.repository.ProjectRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProjectService {

    @Autowired
    private ProjectRepository repo;

    public ProjectModel save(ProjectModel data) {
        return repo.save(data);  // save or update
    }

    public List<ProjectModel> getAll() {
        return repo.findAll();
    }

    public void delete(Long id) {
        repo.deleteById(id);
    }
}
