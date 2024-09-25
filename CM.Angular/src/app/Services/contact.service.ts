import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
const subUrl = "Contact/";

@Injectable({
  providedIn: 'root'
})
export class ContactService extends BaseService {

  public getContacts(): Observable<any> {
    return super.getRequest(subUrl + "GetContacts");
  }
}
