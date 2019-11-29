import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/interfaces/IUser.interface';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-patients-list',
  templateUrl: './patients-list.component.html',
  styleUrls: ['./patients-list.component.scss']
})
export class PatientsListComponent implements OnInit {

  bla = 'hola';

  constructor(public userService: UsersService) {
    this.userService.getAll();
  }

  ngOnInit() {
  }

}
