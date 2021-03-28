import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource, MatTableModule } from '@angular/material/table' 
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public productSource: string;
  public productArray: Product[];
 
  public displayedColumns = ['ID', 'Name', 'Price', 'ImagePath', 'Edit/Delete/Add'];
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

    const header = new Headers()
    header.append('Content-Type', 'application/json')
    header.append('Authorization', 'Bearer ' + sessionStorage.getItem("token"));
    fetch(this.baseUrl + 'Product', {
      method: 'GET',
      headers: header
    }).then(response => response.text().then(text => this.productSource = text).then(rec => console.log(this.productSource))
      .then(rest => this.productArray = JSON.parse(this.productSource)).then(rest => console.log(this.productArray)))
  }
  public addRecord(obj) {
    var temp = obj;
    temp.id += '+';
    const header = new Headers()
    header.append('Content-Type', 'application/json')
    header.append('Authorization', 'Bearer ' + sessionStorage.getItem("token"));
    fetch(this.baseUrl + 'Product', {
      method: 'POST',
      headers: header,
      body:JSON.stringify(temp)
    }).then(rslt=> window.location.reload())
  }
  public deleteRecord(obj) {
    var temp = obj;
    const header = new Headers()
    header.append('Content-Type', 'application/json')
    header.append('Authorization', 'Bearer ' + sessionStorage.getItem("token"));
    fetch(this.baseUrl + 'Product', {
      method: 'DELETE',
      headers: header,
      body: JSON.stringify(temp)
    }).then(rslt => window.location.reload())
  }
  public editRecord(obj) {
    var temp = obj;
    temp.name += 'Edited';
    const header = new Headers()
    header.append('Content-Type', 'application/json')
    header.append('Authorization', 'Bearer ' + sessionStorage.getItem("token"));
    fetch(this.baseUrl + 'Product', {
      method: 'PATCH',
      headers: header,
      body: JSON.stringify(temp)
    }).then(rslt => window.location.reload())
  }
}

interface Product {
  ID: string;
  Name: string;
  Price;
  ImagePath: string;
}
