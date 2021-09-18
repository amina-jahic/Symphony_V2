import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-add-candidate',
  templateUrl: './add-candidate.component.html',
  styleUrls: ['./add-candidate.component.css']
})
export class AddCandidateComponent implements OnInit {

  userForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router, private userService: UserService) {
    this.userForm = this.createUserForm();
   }

  ngOnInit(): void {
  }

  createUserForm(): FormGroup {
    return this.formBuilder.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      email: [null, Validators.required],
      password: [null, Validators.required],
      dateOfBirth: [null, Validators.required],
      gender: [null, Validators.required],
      code: [null, Validators.required]
    });
  }

  saveUser() {
    const { firstName, lastName, email, password, dateOfBirth, gender, code} = this.userForm.getRawValue();

    const user: User = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      password: password,
      dateOfBirth: dateOfBirth,
      gender: gender,
      code: code
    }

      this.userService.SaveUser(user).subscribe(data => {});

  }

  cancel() {
    this.router.navigate(['candidate-management']);
  }

}
