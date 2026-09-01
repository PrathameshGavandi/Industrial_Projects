package com.Prathamesh.ResumePortal.service;

import com.Prathamesh.ResumePortal.model.SkillsModel;
import com.Prathamesh.ResumePortal.repository.SkillsRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class SkillsService {

    @Autowired
    private SkillsRepository repo;

    public SkillsModel save(SkillsModel data) {
        return repo.save(data);  // save + update
    }

    public List<SkillsModel> getAll() {
        return repo.findAll();
    }

    public void delete(Long id) {
        repo.deleteById(id);
    }
}
