import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService, SnackBarService } from '@app/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {

  public formGroup: FormGroup;

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

    const loginRequest = this.formGroup.getRawValue();
    this.authService.login(loginRequest).subscribe(() => {
      this.router.navigateByUrl('/products');
      this.snackbarService.openSuccess('Авторизация успешна!');
    });
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.formGroup.controls[controlName].hasError(errorName);
  }
}
