package com.Prathamesh.ResumePortal.repository;

import com.Prathamesh.ResumePortal.model.LogincheckModel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

public interface LogincheckRepository extends JpaRepository<LogincheckModel, Integer> {
    LogincheckModel findByUsernameAndPassword(String username, String password);
}
