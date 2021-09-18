import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User, displayGender } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-candidate-management',
  templateUrl: './candidate-management.component.html',
  styleUrls: ['./candidate-management.component.css']
})
export class CandidateManagementComponent implements OnInit {

  users: User[];

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
     this.userService.GetUsers().subscribe(data => {
      this.users = data;
    });
  }

  userGender(gender: number) {
    return displayGender(gender);
  }

  addUser() {
    this.router.navigate(['add-candidate']);
  }

  deleteUser(userGuid: string){
    this.userService.DeleteUser(userGuid).subscribe(data => {
      this.users.splice(this.users.findIndex(x => x.guid == userGuid),1);
    });
  }

}
