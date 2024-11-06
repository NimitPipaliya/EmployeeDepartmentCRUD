import { Component } from '@angular/core';
import { Employee } from '../../Models/Employee';
import { EmployeeService } from '../../service/employee.service';
import { Router } from '@angular/router';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ApiResponse } from '../../Models/ApiRespone{T}';
import { CapitalizePipe } from '../../Shared/pipes/capitalize.pipe';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [RouterLink, CommonModule,CapitalizePipe],
  providers: [EmployeeService],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {
  employees: Employee[] = [];
  
  constructor(private employeeService: EmployeeService, private router: Router) { }

  ngOnInit(): void {
    this.loadAllEmployees();
  }

  loadAllEmployees(): void {
    this.employeeService.getAllEmployee().subscribe({
      next: (response: ApiResponse<Employee[]>) => {
        if (response.success) {
          this.employees = response.data;
        } else {
          console.error('Failed to fetch employees.', response.message);
          alert('Failed to fetch employees.');
        }
      },
      error: (error) => {
        console.error('Error fetching employees.', error);
      }
    });
  }

  deleteEmployee(employeeId: number) {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.employeeService.deleteEmployee(employeeId).subscribe(() => {
        this.loadAllEmployees();    
      });
    }
  }
}