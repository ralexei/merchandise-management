import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {

  constructor(
    private snackBar: MatSnackBar
  ) {

  }

  private open(message: string, panelClass: string[], params?: any, duration: number = 3000): void {
    const config = new MatSnackBarConfig();
    config.duration = duration;
    config.panelClass = panelClass;
    config.verticalPosition = 'top';
    config.horizontalPosition = 'end';

    this.snackBar.open(message, '', config);
  }

  private openFromComponent(componentType: any, panelClass: string[], duration: number = 3000): void {
    const config = new MatSnackBarConfig();
    config.duration = duration;
    config.panelClass = panelClass;
    config.verticalPosition = 'top';
    config.horizontalPosition = 'end';

    this.snackBar.openFromComponent(componentType, config);
  }

  public openSuccess(message: string, params?: any, duration: number = 3000): void {
    this.open(message, ['snackbar-successful'], params, duration);
  }

  public openWarning(message: string, params?: any, duration: number = 3000): void {
    this.open(message, ['snackbar-warn'], params, duration);
  }

  public openError(message: string, params?: any, duration: number = 3000): void {
    this.open(message, ['snackbar-warn'], params, duration);
  }

  public openSuccessFromComponent(componentType: any, duration: number = 3000): void {
    this.openFromComponent(componentType, ['snackbar-successful'], duration);
  }

  public closeSnackbar(): void {
    this.snackBar.dismiss();
  }
}
