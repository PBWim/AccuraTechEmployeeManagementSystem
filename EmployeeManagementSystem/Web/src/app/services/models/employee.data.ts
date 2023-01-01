import { DepartmentData } from "./department.data";

export class EmployeeData {
  public id: string = "";
  public firstName: string = "";
  public lastName: string = "";
  public gender: number = 0;
  public dob: Date = new Date();
  public address: string = "";
  public departmentId: string = "";
  public basicSalary: number = 0;
  public department: DepartmentData = {
      id: "",
      name: "",
      employees: []
  };
}
