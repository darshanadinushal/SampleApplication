import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../module/employee';


const baseUrl='http://localhost:5000/api/Employee';

const headers =new HttpHeaders();

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient: HttpClient){}


  getEmployeeList(): Observable<any>{
     const url = baseUrl;
    return this.httpClient.get(url, {headers});
  }


  saveEmployee(employee : Employee): Observable<any>{

    return this.httpClient.post(baseUrl , employee , {headers});
  }


  deleteEmployee(id:number): Observable<any>{
    debugger;
    const url = baseUrl;
   return this.httpClient.delete(url+"/"+id, {headers});
 }


}