package com.Prathamesh.ResumePortal.repository;

import com.Prathamesh.ResumePortal.model.SkillsModel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface SkillsRepository extends JpaRepository<SkillsModel, Long> {
    // JpaRepository provides CRUD operations
}
