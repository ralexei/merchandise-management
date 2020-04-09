import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsService } from './services/api';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthorizationInterceptor } from './services/interceptors';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { CustomPaginator } from './utils';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: jwtTokenGetter
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizationInterceptor,
      multi: true
    },
    {
      provide: MatPaginatorIntl,
      useValue: CustomPaginator()
    }
  ]
})

export class CoreModule { }

export function jwtTokenGetter() {
  return '';
}
