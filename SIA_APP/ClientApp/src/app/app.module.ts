import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ClustersComponent } from './clusters/clusters.component';
import { ClusterComponent } from './cluster/cluster.component';
import { LoginComponent } from './login/login.component';
import { ClassesComponent } from './classes/classes.component';
import { ClassComponent } from './class/class.component';
import { CreateClusterComponent } from './create-cluster/create-cluster.component';
import { AttendanceComponent } from './attendance/attendance.component';
import { CreateClassComponent } from './create-class/create-class.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClustersComponent,
    ClusterComponent,
    LoginComponent,
    ClassesComponent,
    ClassComponent,
    CreateClusterComponent,
    AttendanceComponent,
    CreateClassComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'clusters', component: ClustersComponent },
      { path: 'cluster/:id', component: ClusterComponent },
      { path: 'class-list', component: ClassesComponent },
      { path: 'class/:id', component: ClassComponent },
      { path: 'login', component: LoginComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
