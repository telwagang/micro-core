import { PagesComponent } from './components/report-builder/pages/pages.component';
import { FieldsComponent } from './components/report-builder/fields/fields.component';
import { EntityComponent } from './components/report-builder/entity/entity.component';
import { BuilderHomeComponent } from './components/report-builder/builder-home/builder-home.component';
import { ReportBuilderComponent } from './components/report-builder/report-builder.component';
import { UserHomeComponent } from './components/User/user-home/user-home.component';
import { ApproveComponent } from "./components/loan/approve/approve.component";
import { AccountComponent } from "./components/account/account.component";

import { SystemDataService } from "./services/systemData.service";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./components/app/app.component";
import { NavMenuComponent } from "./components/navmenu/navmenu.component";
import { HomeComponent } from "./components/home/home.component";
import { FetchDataComponent } from "./components/fetchdata/fetchdata.component";
import { CounterComponent } from "./components/counter/counter.component";
import { UserComponent } from "./components/User/User.component";
import { SetUpComponent } from "./components/set-up/set-up.component";
import { CompanyComponent } from "./components/company/company.component";
import { StaffComponent } from "./components/staff/staff.component";
import { InterestComponent } from "./components/interest/interest.component";
import { FormComponent } from "./components/form/form/form.component";
import { InputComponent } from "./components/form/input/input.component";
import { AppHttpService } from "./services/apphttp.service";
import { AkibaComponent } from "./components/akiba/akiba.component";
import { DepositComponent } from "./components/deposit/deposit.component";
import { LoanComponent } from "./components/loan/loan.component";
import { ReportComponent } from "./components/report/report.component";
import { LoginComponent } from "./components/login/login.component";
import { AuthguardGuard } from "./guard/authguard.guard";
import { SignUpComponent } from "./components/signup/signup.component";
import { LoginService } from "./components/login/login.service";
import { CheckToken } from "./guard/chechToken.guard";
import { LoanHomeComponent } from "./components/loan/home/loanhome.component";
import { ApplyloanComponent } from "./components/loan/applyloan/applyloan.component";
import { ProfileComponent } from "./components/loan/profile/profile.component";
import { DataTypePipe } from './pipes/dataType.pipe';

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
    SignUpComponent,
    LoanHomeComponent,
    ApplyloanComponent,
    AccountComponent,
    ApproveComponent,
    ProfileComponent,
    UserHomeComponent,
    ReportBuilderComponent,
    BuilderHomeComponent,
    PagesComponent,
    EntityComponent,
    FieldsComponent,
    DataTypePipe
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(
      [
        { path: "", redirectTo: "login", pathMatch: "full" },
        { path: "login", component: LoginComponent },
        {
          path: "signup/:key",
          component: SignUpComponent,
          canActivate: [AuthguardGuard]
        },
        { path: "home", component: HomeComponent, canActivate: [CheckToken] },
        {
          path: "counter",
          component: CounterComponent,
          canActivate: [CheckToken]
        },
        {
          path: "fetch-data",
          component: FetchDataComponent,
          canActivate: [CheckToken]
        },
        {
          path: "user",
          component: UserHomeComponent,
          canActivate: [CheckToken],
          children: [
            {
              path: "",
              component: UserComponent
            },
            {
              path: "account",
              component: AccountComponent
            }
          ]
        },
        {
          path: "set-up",
          component: SetUpComponent,
          canActivate: [CheckToken],
          children: [
            {
              path: "company",
              component: CompanyComponent
            },
            {
              path: "staff",
              component: StaffComponent
            },
            {
              path: "interest",
              component: InterestComponent
            }
          ]
        },
        {
          path: "akiba",
          component: AkibaComponent,
          canActivate: [CheckToken],
          children: [
            {
              path: "deposit",
              component: DepositComponent
            }
          ]
        },
        {
          path: "loan",
          component: LoanComponent,
          canActivate: [CheckToken],
          children: [
            {
              path: "home",
              component: LoanHomeComponent
            },
            {
              path: "apply",
              component: ApplyloanComponent
            },
            {
              path: "profile",
              component: ProfileComponent
            },
            {
              path: "approve",
              component: ProfileComponent
            }
          ]
        },
        {
          path: "reports",
          component: ReportComponent,
          canActivate: [CheckToken]
        },
        {
          path: "reportbuilder",
          component: ReportBuilderComponent,
          canActivate: [CheckToken],
          children: [
            {
              path:"" , redirectTo:'home', pathMatch:"full"
            },
            {
              path: "home",
              component: BuilderHomeComponent
            },
            {
              path: "entity",
              component: EntityComponent
            },
            {
              path: 'field/:id',
              component: FieldsComponent
            },
            {
              path: 'pages',
              component: PagesComponent
            }
          ]
        },
        { path: "**", redirectTo: "home" }
      ],
      { enableTracing: true }
    )
  ],
  providers: [
    AuthguardGuard,
    CheckToken,
    SystemDataService,
    AppHttpService,
    LoginService
  ]
})
export class AppModuleShared {}
