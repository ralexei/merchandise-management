export class ProductsSearchModel {
  public page?: number;
  public pageSize?: number;
  public productNameContains?: string;
  public retailSellPriceMin?: number;
  public retailSellPriceMax?: number;
  public wholesaleSellPriceMin?: number;
  public wholesaleSellPriceMax?: number;
  public buyPriceMin?: number;
  public buyPriceMax?: number;
  public categoryId?: string;
}
