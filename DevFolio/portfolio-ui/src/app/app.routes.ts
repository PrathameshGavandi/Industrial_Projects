import { Routes } from '@angular/router';

import { AdminGuard } from './Services/admin.guard';

/* Admin */

import { LoginComponent } from './AdminPanel/login/login';

import { ProfileComponent } from './AdminPanel/profile/profile';

import { EducationComponent } from './AdminPanel/education/education';

import { ExperienceComponent } from './AdminPanel/experience/experience';

import { SkillsComponent } from './AdminPanel/skills/skills';

import { ProjectsComponent } from './AdminPanel/projects/projects';

/* User */

import { UserPortfolioComponent } from './UserPanel/user-portfolio/user-portfolio';


export const routes: Routes = [

  /* =========================
      DEFAULT → USER PORTFOLIO
  ========================== */

  { path: '', component: UserPortfolioComponent },

  /* =========================
        USER PORTFOLIO
  ========================== */

  { path: 'userprofile', component: UserPortfolioComponent },

  /* =========================
          LOGIN
  ========================== */

  { path: 'login', component: LoginComponent },

  /* =========================
      ADMIN PAGES (PROTECTED)
  ========================== */

  { path: 'profile', component: ProfileComponent, canActivate: [AdminGuard] },

  { path: 'education', component: EducationComponent, canActivate: [AdminGuard] },

  { path: 'experience', component: ExperienceComponent, canActivate: [AdminGuard] },

  { path: 'skills', component: SkillsComponent, canActivate: [AdminGuard] },

  { path: 'projects', component: ProjectsComponent, canActivate: [AdminGuard] },

  /* =========================
        WILDCARD
  ========================== */

  { path: '**', redirectTo: '' }

];