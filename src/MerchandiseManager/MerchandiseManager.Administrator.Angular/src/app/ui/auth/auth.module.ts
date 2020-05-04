import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthModuleRoutes } from './auth.routes';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { SharedModule } from '@app/shared/shared.module';
import { LoginPageComponent } from './pages/login-page/login-page.component';

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild(AuthModuleRoutes)
  ],
  declarations: [LoginPageComponent, LoginFormComponent]
})
export class AuthModule {

}
