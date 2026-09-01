import {
  Component,
  OnInit,
  ChangeDetectorRef
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { SkillsService } from '../../Services/SkillsService';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './skills.html',
  styleUrls: ['./skills.scss']
})
export class SkillsComponent implements OnInit {

  skillsList: any[] = [];

  skill = {
    pop: '',
    oop: '',
    vm: '',
    fw: '',
    script: '',
    web: '',
    ide: '',
    server: '',
    vcs: '',
    db: '',
    os: '',
    method: ''
  };

  constructor(
    private skillsService: SkillsService,
    private cdr: ChangeDetectorRef   // ✅ IMPORTANT
  ) {}

  /* ===============================
     LOAD ON PAGE OPEN
  ================================ */
  ngOnInit(): void {
    this.loadSkills();
  }

  loadSkills() {
    this.skillsService.getAllSkills().subscribe({
      next: res => {
        this.skillsList = res ?? [];
        this.cdr.detectChanges();   // 🔥 THIS IS THE FIX
      },
      error: () => {
        Swal.fire('Error', 'Failed to load skills', 'error');
      }
    });
  }

  /* ===============================
     SAVE
  ================================ */
  saveSkills(form: NgForm) {
    if (form.invalid) return;

    this.skillsService.saveSkills(this.skill).subscribe({
      next: () => {
        Swal.fire('Success', 'Skill Saved Successfully', 'success');

        this.skill = {
          pop: '',
          oop: '',
          vm: '',
          fw: '',
          script: '',
          web: '',
          ide: '',
          server: '',
          vcs: '',
          db: '',
          os: '',
          method: ''
        };

        form.resetForm();
        this.loadSkills(); // 🔁 auto refresh
      },
      error: () => {
        Swal.fire('Error', 'Skill not saved', 'error');
      }
    });
  }

  /* ===============================
     DELETE
  ================================ */
  deleteSkills(id: number) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'This skill will be deleted permanently',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#ef4444',
      confirmButtonText: 'Yes, delete'
    }).then(result => {
      if (result.isConfirmed) {
        this.skillsService.deleteSkills(id).subscribe({
          next: () => {
            Swal.fire('Deleted', 'Skill removed', 'success');
            this.loadSkills();
          },
          error: () => {
            Swal.fire('Error', 'Delete failed', 'error');
          }
        });
      }
    });
  }
}
