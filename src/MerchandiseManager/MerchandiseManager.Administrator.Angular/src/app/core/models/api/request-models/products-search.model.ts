export class ProductsSearchModel {
  public start?: number;
  public limit?: number;
  public productNameContains?: string;
  public retailSellPriceMin?: number;
  public retailSellPriceMax?: number;
  public wholesaleSellPriceMin?: number;
  public wholesaleSellPriceMax?: number;
  public buyPriceMin?: number;
  public buyPriceMax?: number;
  public categoryId?: string;
}
