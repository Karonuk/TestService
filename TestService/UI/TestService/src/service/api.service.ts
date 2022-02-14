import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject } from 'rxjs';
import { apiUrl } from 'src/constants/url';
import { LoginResponseModel } from 'src/models/LoginResponseModel';
import { ResultViewModel } from 'src/models/ResultViewModel';
import { TestShortModel } from 'src/models/TestShortModel';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http:HttpClient,private router:Router) { }
  options: object = {};

  getQuestionsByTest(id:number){
    this.loadHeaders();
    return this.http.get(`${apiUrl}/User/Questions?id=${id}`,this.options);
  }
  getTestByUser(){
    this.loadHeaders();
    return this.http.get(`${apiUrl}/User/Tests`,this.options);
  }
  public token$ = new BehaviorSubject<any>(null);

  getResult(answers:number[]){
    return this.http.post(`${apiUrl}/User/Result`,answers,this.options);
  }

  logout(){
    localStorage.removeItem("token");
  }

  isAuth(){
    if(localStorage.getItem("token")){
      return this.AuthToken(this.token$.value);
    }
    else{
      return false;
    }
  }

  AuthToken(token:any){
    const helper=new JwtHelperService();
    return helper.isTokenExpired(token);
  }

  loadHeaders = () => {
    const token = localStorage.getItem("token");
    if (!!token) {
      this.options = {
        ...this.options,
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + token
        })
      }
    }
  }
}
