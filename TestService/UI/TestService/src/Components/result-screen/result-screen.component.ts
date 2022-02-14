import { Component, OnInit, Input } from '@angular/core';
import { ResultViewModel } from 'src/models/ResultViewModel';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-result-screen',
  templateUrl: './result-screen.component.html',
  styleUrls: ['./result-screen.component.scss']
})
export class ResultScreenComponent implements OnInit {

  @Input() result!:any;
  constructor(private api:ApiService) {
   }

  ngOnInit(): void {

  }

}
