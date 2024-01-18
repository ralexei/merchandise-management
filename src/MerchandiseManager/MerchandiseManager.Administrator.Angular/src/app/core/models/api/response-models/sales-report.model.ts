import { SoldProduct } from "../core/sold-product.model";

export class SalesReport {
  totalSum: number;
  userSoldAmount: number;
  day: Date;
  soldProducts: SoldProduct[];
}
