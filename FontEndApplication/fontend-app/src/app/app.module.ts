import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './employee-manage/employee-manage.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeeService } from './service/employee.service';
import { DepartmentService } from './service/department.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [DepartmentService ,EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
