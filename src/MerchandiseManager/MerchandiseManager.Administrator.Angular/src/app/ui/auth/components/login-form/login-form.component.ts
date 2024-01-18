import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService, SnackBarService } from '@app/core';
import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {

  public formGroup: FormGroup;

  public isLoading: boolean;

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackbarService: SnackBarService
  ) { }

  ngOnInit() {
    this.initializeForm();
  }

  private initializeForm(): void {
    this.formGroup = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  public onSubmit(): void {
    this.formGroup.markAllAsTouched();
    if (this.formGroup.invalid) {
      return;
    }

    this.isLoading = true;

    const loginRequest = this.formGroup.getRawValue();
    this.authService.login(loginRequest)
      .pipe(
        finalize(() => {
          this.isLoading = false;
        })
      )
      .subscribe(
        () => {
          this.router.navigateByUrl('/products');
          this.snackbarService.openSuccess('Авторизация успешна!');
        },
        (err: any) => {
          this.snackbarService.openError('Ошибка авторизации!')
        });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.formGroup.controls[controlName].hasError(errorName);
  }
}
