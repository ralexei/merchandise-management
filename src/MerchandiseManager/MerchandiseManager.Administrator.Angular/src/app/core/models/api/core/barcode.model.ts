export class Barcode {
  id: string;
  rawCode: string;
  productId?: string;

  constructor(rawCode: string, productId?: string) {
    this.rawCode = rawCode;
    this.productId = productId;
  }
}
