import { Barcode } from './barcode.model';

export class Product {
  public id: string;
  public productName: string;
  public productDescription: string;
  public categoryId: string;
  public categoryName: string;
  public retailSellPrice?: number;
  public wholesaleSellPrice?: number;
  public buyPrice?: number;
  public totalCount: number;
  public barcodes: Barcode[];
}
