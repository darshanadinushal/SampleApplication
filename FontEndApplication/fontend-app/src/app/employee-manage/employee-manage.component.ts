import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Employee } from '../module/employee';
import { DepartmentService } from '../service/department.service';
import { EmployeeService } from '../service/employee.service';
import { Department } from '../module/department';

@Component({
  selector: 'employee-manage',
  templateUrl: './employee-manage.component.html',
  styleUrls: ['./employee-manage.component.scss']
})
export class EmployeeComponent implements OnInit {

    employeeFormGroup: FormGroup;
    errormessage:boolean =false;
    successmessage:boolean=false;
    employee:Employee;
    departmentList : Department[] =[];
    employeeList:Employee[]=[];
    currentEmpId:number=0;

    constructor(private router: Router , private fb: FormBuilder ,private departmentService:DepartmentService ,private employeeService:EmployeeService) {

     }

    ngOnInit() {
        this.initialLoad();
        
       }


       initialLoad(){
         this.currentEmpId=0;
        this.initialForm();
        this.getDepartmentList();
        this.getEmployeeList();
       }


       
   initialForm(){
    this.employeeFormGroup = this.fb.group({
        department: new FormControl('' , Validators.required),
        firstName: new FormControl('' , Validators.required),
        lastName: new FormControl('' , Validators.required),
        phone: new FormControl('' ,[Validators.required ,Validators.pattern("(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{4}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})")]),
        email: new FormControl('' ,[Validators.required ,Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]),
        salary: new FormControl('' , Validators.required),
        address: new FormControl('' , Validators.required)
        
      });
}


getDepartmentList(){
    this.departmentService.getDepartmentList().subscribe(data => {
      console.log(data);
      if(data){
         this.departmentList = data;
      }
  });
  }


  getEmployeeList(){
    this.employeeService.getEmployeeList().subscribe(data => {
      console.log(data);
      if(data){
        this.employeeList=data;
      }
      
  });
  }


saveClick(){
  debugger;
    if(!this.employeeFormGroup.invalid){

      const selectedDepartment:Department =this.employeeFormGroup.controls['department'].value;

        const firstName =this.employeeFormGroup.controls['firstName'].value.trim();
        const lastName =this.employeeFormGroup.controls['lastName'].value;
        const address =this.employeeFormGroup.controls['address'].value.trim();
        const email =this.employeeFormGroup.controls['email'].value.trim();
        const phone =this.employeeFormGroup.controls['phone'].value.trim();
        const salary =+this.employeeFormGroup.controls['salary'].value;

        this.employee = {
           firstName :firstName,
           lastName : lastName,
           address:address,
           departmentId:selectedDepartment.id,
           email:email,
           phone:phone,
           id:this.currentEmpId,
           salary:salary

        };

        this.employeeService.saveEmployee(this.employee).subscribe(data => {
          if(data){
            if(data.errorBean){
              this.errormessage=true;
              this.successmessage=false;
            }
            else{
              this.initialLoad();
             this.successmessage=true;
             this.errormessage=false;
            }
           
          }
  
  
        });
    
      }

}

getSelectedDepartment(depId:number){

  var depIndex =this.departmentList.findIndex((x)=>x.id === depId);
  if(depIndex >=0){
    return this.departmentList[depIndex];
  }
  else{
    return null;
  }

}

editEmployeeClick(employee:Employee){
        this.employee =employee;
        this.currentEmpId= employee.id;
        var selectedDepartment =this.getSelectedDepartment(employee.departmentId);
        this.employeeFormGroup.controls['department'].setValue(selectedDepartment);
        this.employeeFormGroup.controls['firstName'].setValue(employee.firstName);
        this.employeeFormGroup.controls['lastName'].setValue(employee.lastName);
        this.employeeFormGroup.controls['address'].setValue(employee.address);
        this.employeeFormGroup.controls['email'].setValue(employee.email);
        this.employeeFormGroup.controls['phone'].setValue(employee.phone);
        this.employeeFormGroup.controls['salary'].setValue(employee.salary);

}


deleteEmployeeClick(id:any){
  this.employeeService.deleteEmployee(id).subscribe(data => {
    if(data){
     
      this.initialLoad();
    }
  });
}

clearClick(){
  this.initialLoad();
}



}