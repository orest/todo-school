import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';
import { ActivatedRoute, Router } from '@angular/router';
import { ToDo } from '../shared/todo';

@Component({
  selector: 'app-todo-edit',
  templateUrl: './todo-edit.component.html',
  styles: []
})
export class TodoEditComponent implements OnInit {
  todo: ToDo = new ToDo();
  public isError: boolean = false;
  public isSuccess: boolean = false;
  public errorMessage: string = "";

  constructor(private dataService: DataService, private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    var todoId = this.activeRoute.snapshot.params["id"];
    this.dataService.getById(todoId).subscribe(data => {
      this.todo = data;
      console.log(data)
    }, error => {
      console.log(error);
    })
  }

  public saveTodo() {
    this.isError = false;
    this.isSuccess = false;

    this.dataService.saveTodo(this.todo).subscribe(p => {
      console.log(p);
      this.isSuccess = true;
    }, error => {
      this.isError = true;
      this.errorMessage = error;
      //console.log(error);
    });
  }

  public startTodo() {
    this.isError = false;
    this.isSuccess = false;
    this.dataService.startTodo(this.todo).subscribe(p => {
      console.log(p);
      this.isSuccess = true;
    }, error => {
      this.isError = true;
      this.errorMessage = error;
      //console.log(error);
    });
  }
  public deleteTodo() {
    this.isError = false;
    this.isSuccess = false;

    this.dataService.deleteTodo(this.todo).subscribe(p => {
      console.log(p);
      this.isSuccess = true;
    }, error => {
      this.isError = true;
      this.errorMessage = error;
      //console.log(error);
    });
  }
}
