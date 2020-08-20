import { Component, OnInit } from '@angular/core';
import { UserListItem } from './user-list-item';
import { DataService } from '../shared';

@Component({
  selector: 'user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  private readonly service: DataService;
  public userList: any[];

  constructor(private _service: DataService) {
    this.service = _service;
  }
  ngOnInit(): void {
    this.service.getUsers().subscribe(users => this.userList = users);
  }
}