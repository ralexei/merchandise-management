export class Category {
  public id: string;
  public name: string;
  public description: string;
  public parentId: string;
  public children: Category[];

  constructor(name: string, parentId?: string) {
    this.name = name;
    this.parentId = parentId;
    this.children = [];
  }
}
