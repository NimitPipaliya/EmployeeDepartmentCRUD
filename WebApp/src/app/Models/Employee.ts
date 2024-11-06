import { Department } from "./Department";

export interface Employee {
    employeeId: number,
    employeeName: string,
    phone: string,
    email: string,
    departmentId: number,
    department:Department
}