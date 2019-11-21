import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'

@Injectable()
export class AuthService {

  private _registerUrl = "https://localhost:44372/api/account/register";//"http://localhost:3000/api/register";
  private _loginUrl = "https://localhost:44372/api/account/login";//"http://localhost:3000/api/login";
  private _registerMentorUrl = "https://localhost:44372/api/account/register";//"http://localhost:3000/api/mentorRegister";
  private _loginMentorUrl = "https://localhost:44372/api/account/login";//"http://localhost:3000/api/mentorLogin";
  private _registerAdminUrl = "http://localhost:3000/api/adminRegister";
  private _loginAdminUrl = "https://localhost:44372/api/account/login";//"http://localhost:3000/api/adminLogin";
  private _ = ""
  public _blockUserUrl ="https://localhost:44372/api/course/blockunblock/"
  constructor(private http: HttpClient,
              private _router: Router) { }

  registerUser(user) {
    return this.http.post<any>(this._registerUrl, user)
  }

  loginUser(user) {
    return this.http.post<any>(this._loginUrl, user)
  }

  logoutUser() {
    localStorage.removeItem('token')
    localStorage.removeItem('userEmail')
    this._router.navigate(['/events'])
  }

  registerMentor(user) {
    return this.http.post<any>(this._registerMentorUrl, user)
  }

  loginMentor(user) {
    return this.http.post<any>(this._loginMentorUrl, user)
  }

  logoutMentor() {
    localStorage.removeItem('token')
    localStorage.removeItem('mentorEmail')
    this._router.navigate(['/mentor-login'])
  }

  registerAdmin(user) {
    return this.http.post<any>(this._registerAdminUrl, user)
  }

  loginAdmin(user) {
    return this.http.post<any>(this._loginAdminUrl, user)
  }

  logoutAdmin() {
    localStorage.removeItem('token')
    localStorage.removeItem('adminEmail')
    this._router.navigate(['/admin-login'])
  }

  getToken() {
    return localStorage.getItem('token');
  }

  getMentorToken() {
    return localStorage.getItem('token')
  }

  getAdminToken() {
    return localStorage.getItem('token')
  }

  loggedIn() {
    return !!localStorage.getItem('token')    
  }

  loggedInUserName() {
    return localStorage.getItem('userEmail')   
  }

  loggedInMentor() {
    return !!localStorage.getItem('token')    
  }

  loggedInMentorName() {
    return localStorage.getItem('mentorEmail')   
  }

  loggedInAdmin() {
    return !!localStorage.getItem('token')    
  }

  loggedInAdminName() {
    return localStorage.getItem('adminEmail')   
  }

  public blockById(id) {
    return this.http.get<any>(this._blockUserUrl+id)
      
  }
  
  public unBlockById(id) {
    return this.http.get<any>(this._blockUserUrl+id)
  }

}
