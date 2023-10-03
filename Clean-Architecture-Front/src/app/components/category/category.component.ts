import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
})
export class CategoryComponent {
  public categories: any;
  filtroLista: string='';

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
