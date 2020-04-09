import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintBarcodeDialogComponent } from './print-barcode-dialog.component';

describe('PrintBarcodeDialogComponent', () => {
  let component: PrintBarcodeDialogComponent;
  let fixture: ComponentFixture<PrintBarcodeDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrintBarcodeDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintBarcodeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
