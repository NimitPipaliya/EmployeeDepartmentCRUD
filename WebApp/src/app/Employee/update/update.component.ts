import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { EmployeeService } from '../../service/employee.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [CommonModule,RouterLink,ReactiveFormsModule],
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent implements OnInit{
  empForm!: FormGroup;
  employeeId: number = 0; 
  departments: any[] = []; 

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private employeeService: EmployeeService,
  ) {}

  
  ngOnInit(): void {
    this.employeeId = Number(this.route.snapshot.paramMap.get('employeeId'));

    this.empForm = this.fb.group({
      employeeId: [this.employeeId],
      employeeName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      phone: ['', [Validators.required,Validators.minLength(10), Validators.maxLength(10)]],
      email: ['', [Validators.required, Validators.email]],
      departmentId:['',[Validators.required]]
    });
    
    this.loadDepartments();
    this.loadEmployeeDetails();
}
get formControl() {
  return this.empForm.controls;
}
loadDepartments(): void {
  this.employeeService.getAllDepartments().subscribe({
    next: (departments) => {
      this.departments = departments.data; // Assuming data contains the list of departments
    },
    error: (err) => {
      console.error('Failed to fetch departments', err);
    }
  });
}
loadEmployeeDetails(): void {
  this.employeeService.getEmployeeById(this.employeeId).subscribe({
    next: (employee) => {
      this.empForm.patchValue({
        employeeName: employee.data.employeeName,
        phone: employee.data.phone,
        email: employee.data.email,
        departmentId: employee.data.department.departmentId,
      });
    },
    error: (err) => {
      console.error('Failed to fetch employee details', err);
    }
  });
}
OnSubmit(): void {

  if (this.empForm.valid) {
    const formData = {
      employeeId: this.employeeId,
      employeeName: this.empForm.value.employeeName,
      phone: this.empForm.value.phone,
      email: this.empForm.value.email,
      departmentId: this.empForm.value.departmentId
    };

    this.employeeService.modifyEmployee(formData).subscribe({
      next: (response) => {
        if (response.success) {
          this.router.navigate(['/employeeList']);
        } else {
          window.alert(response.message);
        }
      },
      error: (err) => {
        window.alert(err.error.message);
      },
      complete: () => {
        console.log("Completed");
      }
    });
  }
}

}
