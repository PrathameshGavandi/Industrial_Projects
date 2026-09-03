import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SkillsService } from '../../Services/SkillsService';
import { Observable, map, catchError, of, tap } from 'rxjs';

interface SkillRow {
  label: string;
  values: string[];
}

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-skills.html',
  styleUrls: ['./user-skills.scss']
})
export class UserSkillsComponent {

  @Output() loaded = new EventEmitter<void>();

  skills$!: Observable<SkillRow[]>;

  constructor(private skillsService: SkillsService) {
    this.loadSkills();
  }

  loadSkills() {

    this.skills$ = this.skillsService.getAllSkills().pipe(

      map((res: any[]) => {

        if (!res || res.length === 0) {
          return [];
        }

        const s = res[0];

        return [
          {
            label: 'Procedural Oriented Programming',
            values: s.pop?.split(',') ?? []
          },
          {
            label: 'Object Oriented Programming',
            values: s.oop?.split(',') ?? []
          },
          {
            label: 'Virtual Machines Based',
            values: s.vm?.split(',') ?? []
          },
          {
            label: 'Frameworks',
            values: s.fw?.split(',') ?? []
          },
          {
            label: 'Scripting Languages',
            values: s.script?.split(',') ?? []
          },
          {
            label: 'Web Technologies',
            values: s.web?.split(',') ?? []
          },
          {
            label: 'IDEs & Tools',
            values: s.ide?.split(',') ?? []
          },
          {
            label: 'Servers',
            values: s.server?.split(',') ?? []
          },
          {
            label: 'Version Control System',
            values: s.vcs?.split(',') ?? []
          },
          {
            label: 'Database',
            values: s.db?.split(',') ?? []
          },
          {
            label: 'Operating Systems',
            values: s.os?.split(',') ?? []
          },
          {
            label: 'Methodologies',
            values: s.method?.split(',') ?? []
          }
        ];

      }),

      tap(() => {
        this.loaded.emit();
      }),

      catchError((error) => {

        console.error('Skills API Error:', error);

        this.loaded.emit();

        return of([]);

      })

    );

  }

  trackByIndex(index: number): number {
    return index;
  }

}