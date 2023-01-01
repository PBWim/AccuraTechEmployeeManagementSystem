import { Injectable, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class EmployeesService {
  myAppUrl: string = "";

  constructor(private http: Http, @Inject('API_BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getEmployees(): Observable<any> {
    const headers = new Headers({
      'accept': 'text/plain'
    })
    return this.http.get(this.myAppUrl + 'api/Employee/Get', { headers: headers });
  }

  createEmployee(employeeObj: { firstName: any; lastName: any; gender: any; dob: any; address: any; departmentId: any; basicSalary: any; department: { id: any; name: any; }; }): Observable<any> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    })
    return this.http.post(this.myAppUrl + 'api/Employees/CreateEmployee',
      {
        firstName: employeeObj.firstName,
        lastName: employeeObj.lastName,
        gender: employeeObj.gender,
        dob: employeeObj.dob,
        address: employeeObj.address,
        departmentId: employeeObj.departmentId,
        basicSalary: employeeObj.basicSalary,
        department: {
          id: employeeObj.department.id,
          name: employeeObj.department.name,
          employees: []
        }
      }, { headers: headers });
  }

  updateEmployee(employeeObj: { id: any; firstName: any; lastName: any; gender: any; dob: any; address: any; departmentId: any; basicSalary: any; department: { id: any; name: any; }; }): Observable<any> {
    const headers = new Headers({
      'Content-Type': 'application/json'
    })
    return this.http.put(this.myAppUrl + 'api/Employee/UpdateEmployee',
      {
        id: employeeObj.id,
        firstName: employeeObj.firstName,
        lastName: employeeObj.lastName,
        gender: employeeObj.gender,
        dob: employeeObj.dob,
        address: employeeObj.address,
        departmentId: employeeObj.departmentId,
        basicSalary: employeeObj.basicSalary,
        department: {
          id: employeeObj.department.id,
          name: employeeObj.department.name,
          employees: []
        }
      }, { headers: headers });
  }

  deleteEmployee(employeeObj: { id: any; firstName: any; lastName: any; gender: any; dob: any; address: any; departmentId: any; basicSalary: any; department: { id: any; name: any; }; }): Observable<any> {
    const headers = new Headers({
      'accept': 'text/plain'
    })
    let options = {
      headers: headers,
      body: {
        id: employeeObj.id,
        firstName: employeeObj.firstName,
        lastName: employeeObj.lastName,
        gender: employeeObj.gender,
        dob: employeeObj.dob,
        address: employeeObj.address,
        departmentId: employeeObj.departmentId,
        basicSalary: employeeObj.basicSalary,
        department: {
          id: employeeObj.department.id,
          name: employeeObj.department.name,
          employees: []
        }
      },
    };
    return this.http.delete(this.myAppUrl + 'api/Employee/DeleteEmployee', options);
  }
}
