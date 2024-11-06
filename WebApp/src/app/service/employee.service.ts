import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../Models/Employee';
import { ApiResponse } from '../Models/ApiRespone{T}';
import { AddEmployee } from '../Models/AddEmployee';
import { EditEmployee } from '../Models/EditEmployee';
import { Department } from '../Models/Department';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiUrl = 'http://localhost:5212/api/Employee/';

  constructor(private http:HttpClient ) { }

  getAllEmployee():Observable<ApiResponse<Employee[]>> {
    return this.http.get<ApiResponse<Employee[]>>(this.apiUrl + `GetAllEmployees`);
  }

  addEmployee(addEmployee: AddEmployee): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(`${this.apiUrl}AddEmployee`, addEmployee);
  }
  
  modifyEmployee(editEmployee: EditEmployee): Observable<ApiResponse<string>> {
    return this.http.put<ApiResponse<string>>(`${this.apiUrl}UpdateEmployee`, editEmployee);
  }

  deleteEmployee(employeeId: number): Observable<ApiResponse<string>> {
    return this.http.delete<ApiResponse<string>>(`${this.apiUrl}RemoveEmployee?id=${employeeId}`)
  }
  getEmployeeById(employeeId: number): Observable<ApiResponse<Employee>> {
    return this.http.get<ApiResponse<Employee>>(`${this.apiUrl}GetEmployeeById?id=${employeeId}`)
  }
  getAllDepartments():Observable<ApiResponse<Department[]>> {
    return this.http.get<ApiResponse<Department[]>>(this.apiUrl + `GetAllDepartments`);
  }
}
