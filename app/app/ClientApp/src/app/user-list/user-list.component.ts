import { Component } from '@angular/core';
import { UserListItem } from './user-list-item';

@Component({
  selector: 'user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {
    public users = [
        new UserListItem("1","qwer_1","qwer@gmail.com"),
        new UserListItem("2","qwer_2","qwer@gmail.com"),
        new UserListItem("3","qwer_3","qwer@gmail.com"),
        new UserListItem("4","qwer_4","qwer@gmail.com"),
        new UserListItem("5","qwer_5","qwer@gmail.com"),
        new UserListItem("6","qwer_6","qwer@gmail.com"),
        new UserListItem("7","qwer_7","qwer@gmail.com"),
        new UserListItem("8","qwer_8","qwer@gmail.com"),
        new UserListItem("9","qwer_9","qwer@gmail.com"),
        new UserListItem("10","qwer_10","qwer@gmail.com"),
    ];
}