import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TestShortModel } from 'src/models/TestShortModel';
import { ApiService } from 'src/service/api.service';

@Component({
  selector: 'app-test-list',
  templateUrl: './test-list.component.html',
  styleUrls: ['./test-list.component.scss']
})
export class TestListComponent implements OnInit {
  form!:FormGroup;
  Tests!:TestShortModel[];
  isVisible=false;

  constructor(private service:ApiService,private fb:FormBuilder) { }

  toggleTest(id:any){
    this.Tests.forEach((elem=>{
      if(elem.id===id){
        elem.isVisible=true;
      }
      else{
        elem.isVisible=false;
      }
    }))
  }

  ngOnInit(): void {
    this.service.getTestByUser().subscribe(
      (successRes:any)=>{
          this.Tests=successRes;
          console.log(this.Tests);
      }
    );
    this.form=this.fb.group({
      checkbox:[false,Validators.required]
    })
  }

}
