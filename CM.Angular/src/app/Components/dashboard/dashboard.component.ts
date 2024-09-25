import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../Services/contact.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
data:any;
  constructor(private service: ContactService) {

  }
  ngOnInit(): void {
    this.getMembers();
  }

  getMembers() {
    
    this.service.getContacts().subscribe(result=>{
      this.data=result.subset;
      console.log(result);
    }
  );
  }

}
