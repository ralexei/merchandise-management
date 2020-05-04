export class PrintRequest {
  labelsCount: number;
  barcodeToPrint: string;
  printingProduct: PrintingProductInfo;
}

export class PrintingProductInfo {
  productName: string;
  price: number;
}
