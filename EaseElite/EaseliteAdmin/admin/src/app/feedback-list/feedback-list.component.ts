import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { WebService } from '../Service';

@Component({
  selector: 'app-feedback-list',
  templateUrl: './feedback-list.component.html',
  styleUrls: ['./feedback-list.component.scss']
})
export class FeedbackListComponent implements OnInit {
  feedbacklist: any[] = []; // List to store feedback data
  FeedbackMap: { [key: string]: any } = {}; // Map to store user details by RegistrationId

  constructor(private router: Router, private service: WebService) {}

  ngOnInit(): void {
    this.GetAllFeedbackDetail();
  }

  // Fetch all feedback
  GetAllFeedbackDetail(): void {
    this.service.GetAllFeedback().subscribe(
      (data: any[]) => {
        this.feedbacklist = data;
        console.log('Feedback Data:', data);

        // Extract unique RegistrationIds
        const registrationIds = [...new Set(data.map(feedback => feedback.registration.RegistrationId))];
        this.fetchFeedbackDetails(registrationIds);
      },
      error => {
        Swal.fire('Error', 'Failed to fetch feedback details. Please try again later.', 'error');
        console.error('Error fetching feedback:', error);
      }
    );
  }

  // Fetch user details for each RegistrationId
  fetchFeedbackDetails(registrationIds: string[]): void {
    registrationIds.forEach(registrationId => {
      this.service.GetRegistrationById(registrationId).subscribe(
        userDetails => {
          // Populate FeedbackMap with fetched user details
          this.FeedbackMap[registrationId] = userDetails;
        },
        error => {
          console.error(`Error fetching details for RegistrationId: ${registrationId}`, error);
        }
      );
    });
  }

  // Dynamically get user detail by RegistrationId and key (FName, LName, Email)
  getFeedbackDetail(registrationId: string, key: string): string {
    return this.FeedbackMap[registrationId]?.[key] || 'N/A';
  }
}
