import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
})
export class CategoryComponent {
  public categories: any;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(valeu: string) {
    this._filtroLista = valeu;
    this.categories = this.filtroLista
      ? this.filtrarCategorias(this._filtroLista)
      : this.categories;
  }

  filtrarCategorias(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.categories.filter(
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
      (response) => (this.categories = response),
      (error) => console.log(error)
    );
  }
}
