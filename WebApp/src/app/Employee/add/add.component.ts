import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { EmployeeService } from '../../service/employee.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [CommonModule,RouterLink,ReactiveFormsModule],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css'
})
export class AddComponent implements OnInit {

  empForm!: FormGroup;
  constructor(private fb: FormBuilder, private router: Router,private employeeSevice:EmployeeService) {
    
  }
  ngOnInit(): void {
    this.empForm = this.fb.group({
      employeeName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      phone: ['', [Validators.required,Validators.minLength(10), Validators.maxLength(10)]],
      email: ['', [Validators.required, Validators.email]],
      departmentId:['',[Validators.required]]
    });
}
get formControl(){
  return this.empForm.controls;
 }
 OnSubmit(): void {

  if (this.empForm.valid) {
    const formData = {
      employeeName: this.empForm.value.employeeName,
      phone: this.empForm.value.phone,
      email: this.empForm.value.email,
      departmentId: this.empForm.value.departmentId
    };

    this.employeeSevice.addEmployee(formData).subscribe({
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
