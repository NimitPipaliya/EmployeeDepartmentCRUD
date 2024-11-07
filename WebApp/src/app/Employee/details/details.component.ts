import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../service/employee.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Employee } from '../../Models/Employee';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule,RouterLink],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent implements OnInit{
  employeeId:number|undefined;

  employee:Employee|undefined;
  constructor(private employeeService:EmployeeService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    const employeeId = Number(this.route.snapshot.paramMap.get('employeeId'));
     this.employeeService.getEmployeeById(employeeId).subscribe({
       next: (response) => {
         if (response.success) {
           this.employee = response.data;
         } else {
           console.error('Failed to fetch employee.', response.message);
         }
       },
       error: (error) => {
         console.error('Failed to fetch employee.', error);
       },
     });
  }
  deleteBook(employeeId: number) {
    if (confirm('Are you sure you want to delete this book?')) {
      this.employeeService.deleteEmployee(employeeId).subscribe(() => {
        this.router.navigate(['/employeeList']);
      });
    }
  }


}
