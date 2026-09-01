package com.Prathamesh.ResumePortal.service;

import com.Prathamesh.ResumePortal.model.ProfileModel;
import com.Prathamesh.ResumePortal.repository.ProfileRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProfileService {

    @Autowired
    private ProfileRepository repo;

    public ProfileModel save(ProfileModel data) {
        return repo.save(data);   // save + update
    }

    public List<ProfileModel> getAll() {
        return repo.findAll();
    }

    public void delete(Long id) {
        repo.deleteById(id);
    }
}
