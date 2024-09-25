import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  params: {}
}
@Injectable({
  providedIn: 'root'
})
export class BaseService {
  baseUrl = "http://localhost:5241/";


  constructor(private http: HttpClient) { }

  public getRequest(subUrl: string, params?: any) {
    if (params) {
      httpOptions.params = params;
    }
    return this.http.get<any>(this.baseUrl + subUrl, httpOptions);
  }

  public postRequest(subUrl: string, body: any) {
    return this.http.post<any>(this.baseUrl + subUrl, JSON.stringify(body), httpOptions);
  }
}
