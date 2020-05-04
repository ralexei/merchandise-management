import { Component, OnInit, Input, EventEmitter, Output, OnDestroy } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { FlatTreeControl } from '@angular/cdk/tree';
import { Category, FilteredResult, SnackBarService } from '@app/core';
import { SelectionModel } from '@angular/cdk/collections';
import { FormControl, Validators } from '@angular/forms';
import { CategoryService } from '@app/core/services/api/category.service';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-categories-tree',
  templateUrl: './categories-tree.component.html',
  styleUrls: ['./categories-tree.component.scss']
})
export class CategoriesTreeComponent implements OnInit, OnDestroy {

  @Output() public categorySelected = new EventEmitter<Category>();
  @Output() public categoryCreated = new EventEmitter<Category>();

  public treeControl: FlatTreeControl<CategoryFlatNode>;

  public dataSource: MatTreeFlatDataSource<Category, CategoryFlatNode>;

  flatNodeMap = new Map<CategoryFlatNode, Category>();
  nestedNodeMap = new Map<Category, CategoryFlatNode>();

  selectedParent: CategoryFlatNode | null = null;

  treeFlattener: MatTreeFlattener<Category, CategoryFlatNode>;

  categoryNameFormControl: FormControl = new FormControl('', Validators.required);

  newCategoryClicked = false;
  loading = false;

  private onDestroy$: Subject<void> = new Subject<void>();

  constructor(
    private categoryService: CategoryService,
    private snackBarService: SnackBarService) {
    this.treeFlattener = new MatTreeFlattener(this.transformer, this.getLevel,
      this.isExpandable, this.getChildren);
    this.treeControl = new FlatTreeControl<CategoryFlatNode>(this.getLevel, this.isExpandable);
    this.dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);
    // console.log(this.dataSource._flattenedData);
  }

  getLevel = (node: CategoryFlatNode) => node.level;

  isExpandable = (node: CategoryFlatNode) => node.expandable;

  getChildren = (node: Category): Category[] => node.children;

  hasChild = (_: number, nodeData: CategoryFlatNode) => {
    if (nodeData) {
      return nodeData.expandable;
    } else {
      return false;
    }
  }

  hasNoContent = (_: number, nodeData: CategoryFlatNode) => !nodeData.name;

  transformer = (node: Category, level: number) => {
    const existingNode = this.nestedNodeMap.get(node);
    const flatNode = existingNode && existingNode.id === node.id
      ? existingNode
      : new CategoryFlatNode();

    flatNode.id = node.id;
    flatNode.name = node.name;
    flatNode.level = level;
    flatNode.expandable = node.children ? node.children.length > 0 : false;

    this.flatNodeMap.set(flatNode, node);
    this.nestedNodeMap.set(node, flatNode);

    return flatNode;
  }

  ngOnInit(): void {
    this.fetchCategories();
  }

  getParentNode(node: CategoryFlatNode): CategoryFlatNode | null {
    const currentLevel = this.getLevel(node);

    if (currentLevel < 1) {
      return null;
    }

    const startIndex = this.treeControl.dataNodes.indexOf(node) - 1;

    for (let i = startIndex; i >= 0; i--) {
      const currentNode = this.treeControl.dataNodes[i];

      if (this.getLevel(currentNode) < currentLevel) {
        return currentNode;
      }
    }
    return null;
  }

  public addNewItem(node: CategoryFlatNode): void {
    this.newCategoryClicked = true;
    const parentNode = this.flatNodeMap.get(node);

    parentNode.children.push({ name: '', parentId: parentNode.id } as Category);

    this.refreshTreeData();
    this.treeControl.expand(node);
  }

  public addNewRootNode(): void {
    this.newCategoryClicked = true;
    this.dataSource.data.push({ name: ''} as Category);
    this.refreshTreeData();
  }

  saveNode(node: CategoryFlatNode, itemValue: string) {
    if (this.categoryNameFormControl.valid) {
      const nestedNode = this.flatNodeMap.get(node);

      this.newCategoryClicked = false;
      this.loading = true;
      nestedNode.name = itemValue;

      this.categoryService.create(nestedNode)
        .pipe(takeUntil(this.onDestroy$))
        .subscribe(
          (newCategory: Category) => {
            this.fetchCategories();
            this.snackBarService.openSuccess('Группа успешно добавлена!');
          },
          (err: any) => {
            this.loading = false;
            this.snackBarService.openError('Не удалось добавить новую группу');
          }
        );

      this.refreshTreeData();
    }
  }

  public cancelCreation(category: Category): void {
    this.newCategoryClicked = false;
    this.dataSource.data.splice(this.dataSource.data.indexOf(category, 0), 1);
    this.refreshTreeData();
  }

  private refreshTreeData(): void {
    const tmp = this.dataSource.data;

    this.dataSource.data = [];
    this.dataSource.data = tmp;
  }

  public removeCategory(category: Category): void {
    this.loading = true;
    this.categoryService.delete(category.id)
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(
        () => {
          this.fetchCategories();
          this.snackBarService.openSuccess('Группа успешно удалена!');
        },
        (err: any) => {
          this.snackBarService.openError('Не удалось удалить выбранную группу');
          this.loading = false;
        }
      );
  }

  private fetchCategories(): void {
    this.loading = true;
    this.categoryService.getAll()
      .pipe(takeUntil(this.onDestroy$))
      .subscribe(
        (categories: FilteredResult<Category>) => {
          this.dataSource.data = categories.data;
          this.loading = false;
        },
        (err: any) => {
          this.snackBarService.openError('Не удалось извлечь группы');
          this.loading = false;
          this.dataSource.data = [];
        }
      );
  }

  public onChange(event: any): void {
    this.categorySelected.emit(event.value);
  }

  ngOnDestroy(): void {
    this.onDestroy$.next();
  }
}

export class CategoryFlatNode {
  public id: string;
  public level: number;
  public name: string;
  public expandable: boolean;
}
