import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
})
export class CategoryComponent {
  public categories: any;
  private originalCategories: any;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.categories = this.filtroLista
      ? this.filtrarCategorias(this._filtroLista)
      : this.originalCategories;
  }

  filtrarCategorias(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.originalCategories.filter(
      (category: { name: string }) =>
        category.name.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCategories();
  }

  public getCategories(): void {
    this.http.get('https://localhost:7054/api/categories').subscribe(
      (response) => {
        this.categories = response;
        this.originalCategories = response;
      },
      (error) => console.log(error)
    );
  }
}
