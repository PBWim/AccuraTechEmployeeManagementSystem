import { Component, OnInit } from '@angular/core';
import { EmployeeData } from '../services/models/employee.data';
import { EmployeesService } from '../services/employees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees: EmployeeData[] | undefined;
  public showSalary: boolean = false;

  constructor(private employeesService: EmployeesService) { }

  ngOnInit(): void {
    this.employeesService.getEmployees().subscribe(
      data => {
        var result = JSON.parse(data._body);
        this.employees = result;
      },
      err => {
        console.log(err.error.message);
      }
    );
  }

  showhideSalary() {
    this.showSalary = !this.showSalary;
  }

  edit(employee: any) {

  }

  delete(employee: EmployeeData) {
    var isConfirmed = confirm("Do you want to Delete this Employee ?");
    if (isConfirmed) {
      this.employeesService.deleteEmployee(employee).subscribe(
        data => {
          var result = JSON.parse(data._body);
          this.employees = result;
        },
        err => {
          console.log(err.error.message);
        }
      );
    }
  }
}
