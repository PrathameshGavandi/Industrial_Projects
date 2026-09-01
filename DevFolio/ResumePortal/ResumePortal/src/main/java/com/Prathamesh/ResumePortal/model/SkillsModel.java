package com.Prathamesh.ResumePortal.model;

import jakarta.persistence.*;

@Entity
@Table(name = "skills")
public class SkillsModel {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;  // maps to 'id' column

    @Column(name = "pop")
    private String pop;

    @Column(name = "oop")
    private String oop;

    @Column(name = "vm")
    private String vm;

    @Column(name = "fw")
    private String fw;

    @Column(name = "script")
    private String script;

    @Column(name = "web")
    private String web;

    @Column(name = "ide")
    private String ide;

    @Column(name = "server")
    private String server;

    @Column(name = "vcs")
    private String vcs;

    @Column(name = "db")
    private String db;

    @Column(name = "os")
    private String os;

    @Column(name = "method")
    private String method;

    // ===== Getters & Setters =====

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getPop() {
        return pop;
    }

    public void setPop(String pop) {
        this.pop = pop;
    }

    public String getOop() {
        return oop;
    }

    public void setOop(String oop) {
        this.oop = oop;
    }

    public String getVm() {
        return vm;
    }

    public void setVm(String vm) {
        this.vm = vm;
    }

    public String getFw() {
        return fw;
    }

    public void setFw(String fw) {
        this.fw = fw;
    }

    public String getScript() {
        return script;
    }

    public void setScript(String script) {
        this.script = script;
    }

    public String getWeb() {
        return web;
    }

    public void setWeb(String web) {
        this.web = web;
    }

    public String getIde() {
        return ide;
    }

    public void setIde(String ide) {
        this.ide = ide;
    }

    public String getServer() {
        return server;
    }

    public void setServer(String server) {
        this.server = server;
    }

    public String getVcs() {
        return vcs;
    }

    public void setVcs(String vcs) {
        this.vcs = vcs;
    }

    public String getDb() {
        return db;
    }

    public void setDb(String db) {
        this.db = db;
    }

    public String getOs() {
        return os;
    }

    public void setOs(String os) {
        this.os = os;
    }

    public String getMethod() {
        return method;
    }

    public void setMethod(String method) {
        this.method = method;
    }
}
