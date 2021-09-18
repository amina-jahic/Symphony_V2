import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';


@Injectable()
export class UserService {
    private API_BASE_URL = 'https://localhost:44381';

    constructor(private httpClient: HttpClient) { }

  GetUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.API_BASE_URL}/api/CandidateManagement`);
  }

  SaveUser(user:User){
    return this.httpClient.post(`${this.API_BASE_URL}/api/CandidateManagement`, user);
  }

  DeleteUser(userGuid: string){
    return this.httpClient.delete(`${this.API_BASE_URL}/api/CandidateManagement/${userGuid}`)
  }
}