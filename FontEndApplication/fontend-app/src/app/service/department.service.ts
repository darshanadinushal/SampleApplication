import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


const baseUrl='http://localhost:5000/api/Department';

const headers =new HttpHeaders();

@Injectable({
    providedIn: 'root'
})
export class DepartmentService {

  constructor(private httpClient: HttpClient){}


  getDepartmentList(): Observable<any>{
     const url = baseUrl;
    return this.httpClient.get(url, {headers});
  }



}