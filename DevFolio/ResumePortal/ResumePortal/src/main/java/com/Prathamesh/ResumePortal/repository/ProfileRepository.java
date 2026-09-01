package com.Prathamesh.ResumePortal.repository;

import com.Prathamesh.ResumePortal.model.ProfileModel;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ProfileRepository extends JpaRepository<ProfileModel, Long> {
}
