import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { UserComponent } from "./components/User/User.component";
import { SetUpComponent } from "./components/set-up/set-up.component";
import { CompanyComponent } from "./components/company/company.component";
import { StaffComponent } from "./components/staff/staff.component";
import { InterestComponent } from "./components/interest/interest.component";
import { FormComponent } from "./components/form/form/form.component";
import { InputComponent } from "./components/form/input/input.component";
import { AppHttpService } from "./services/apphttp.service";
import { AkibaComponent } from './components/akiba/akiba.component';
import { DepositComponent } from './components/deposit/deposit.component';
import { LoanComponent } from './components/loan/loan.component';
import { ReportComponent } from './components/report/report.component';
import { LoginComponent } from './components/login/login.component';
import { AuthguardGuard } from './guard/authguard.guard';
import { SignUpComponent } from './components/signup/signup.component';
import { LoginService } from './components/login/login.service';
@NgModule({
    declarations: [
        AppComponent,
        FormComponent,
        InputComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        UserComponent,
        SetUpComponent,
        CompanyComponent,
        StaffComponent,
        InterestComponent,
        LoanComponent,
        ReportComponent,
        AkibaComponent,
        DepositComponent,
        HomeComponent,
        LoginComponent,
        SignUpComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            {path: 'login', component: LoginComponent},
            {path: 'signup/:key', component: SignUpComponent,canActivate: [AuthguardGuard] },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'user', component: UserComponent },
            {
                path: 'set-up', component: SetUpComponent,
                children: [{
                    path: 'company',
                    component: CompanyComponent
                },
                {
                    path: 'staff',
                    component: StaffComponent
                },
                {
                    path: 'interest',
                    component: InterestComponent
                }]
            },
            {
                path: 'akiba', component: AkibaComponent
                , children: [{
                    path: 'deposit'
                    , component: DepositComponent
                }]
            },
            {
                path: 'loan', component: LoanComponent
            }, {
                path: 'reports', component: ReportComponent
            },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [AuthguardGuard ,AppHttpService, LoginService ]
})
export class AppModuleShared {
}
