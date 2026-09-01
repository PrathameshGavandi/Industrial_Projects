package com.Prathamesh.ResumePortal.repository;

import com.Prathamesh.ResumePortal.model.EducationModel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface EducationRepository extends JpaRepository<EducationModel, Long> {
}
