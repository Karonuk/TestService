import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private api:ApiService) { }
  isAuth(){
    return this.api.isAuth();
  }

  clickButton(){
    this.api.logout();
  }

  ngOnInit(): void {
  }

}
