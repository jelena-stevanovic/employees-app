import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ErrorInterceptorProvider} from './interceptors/error.interceptor';
import {EmployeeComponent} from "./employee/create-edit-employee/employee.component";
import {EmployeeListComponent} from "./employee/employee-list/employee-list.component";
import {PositionsComponent} from "./position/positions.component";
import {PositionListComponent} from "./position/position-list/position-list.component";


@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    EmployeeListComponent,
    PositionsComponent,
    PositionListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [ErrorInterceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule {
}
