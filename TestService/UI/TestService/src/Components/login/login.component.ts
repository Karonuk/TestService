import { Component,OnInit } from '@angular/core';
import { FormBuilder,  FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { LoginResponseModel } from 'src/models/LoginResponseModel';
import { Router } from '@angular/router';
import { apiUrl } from 'src/constants/url';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  hide=true;

constructor(private formBuilder: FormBuilder,private http:HttpClient,private router:Router) {

}

  ngOnInit(): void {
     this.form = this.formBuilder.group({
      email: ['',Validators.required],
      password: ['',Validators.required],
    });

  }
  submitForm(){
      return this.http.post(`${apiUrl}/user`,this.form.value).subscribe(
        (successRes: any)=> {
          var response=successRes as LoginResponseModel;
          localStorage.setItem("token",response.token);
          this.router.navigateByUrl("/test-list");
        },
        (errorRes:any)=>{
            alert(errorRes.error);
        }
      );
  }
}
