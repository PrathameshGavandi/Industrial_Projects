package com.Prathamesh.ResumePortal.model;
import java.math.BigDecimal;

import jakarta.persistence.*;

@Entity
@Table(name = "education")
public class EducationModel {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false)
    private String degree;

    private String specialization;

    @Column(nullable = false)
    private String college;

    private String university;

    private String location;

    @Column(name = "passing_year", nullable = false)
    private Integer passingYear;

    @Column(precision = 4, scale = 2)
    private BigDecimal cgpa;

    // -------- Getters & Setters --------

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getDegree() {
        return degree;
    }

    public void setDegree(String degree) {
        this.degree = degree;
    }

    public String getSpecialization() {
        return specialization;
    }

    public void setSpecialization(String specialization) {
        this.specialization = specialization;
    }

    public String getCollege() {
        return college;
    }

    public void setCollege(String college) {
        this.college = college;
    }

    public String getUniversity() {
        return university;
    }

    public void setUniversity(String university) {
        this.university = university;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public Integer getPassingYear() {
        return passingYear;
    }

    public void setPassingYear(Integer passingYear) {
        this.passingYear = passingYear;
    }

    public BigDecimal  getCgpa() {
        return cgpa;
    }

    public void setCgpa(BigDecimal  cgpa) {
        this.cgpa = cgpa;
    }
}
