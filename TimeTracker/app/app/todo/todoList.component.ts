import { Component, OnInit } from "@angular/core"
import { NgForm } from "@angular/forms";
import { ToDo } from "../shared/todo";
import { TodoComponent, ComponentMode } from "./todo.component"
import { DataService } from "../shared/dataService";
import { Router } from "@angular/router";

@Component({
	selector: "todo-list",
	templateUrl: "./todoList.component.html",
	//styles: [`h1{background-color:yellow}`],
	styleUrls: ['./todoList.component.css']
})
export class TodoListComponent implements OnInit {
	public todoStates = ComponentMode;
	todoTitle: string = "";
	pageTitle: string = "Todo Component Test";
	errorMessage = ""
	todo: ToDo = new ToDo();
	todos: ToDo[] = [];

	constructor(private dataService: DataService, 
		 private router: Router) {

	}

	editTodo(todo) {
		this.router.navigate(["./todo", 1]);
	  }

	toggleComplete(): void {
		this.todo.isCompleted = !this.todo.isCompleted;

	}

	createTodo() {
		var newTodo = new ToDo();
		newTodo.title = this.todoTitle;
		this.saveTodo(newTodo)
	}

	saveTodo(todo: ToDo) {
		todo.priority = this.todos.length;
		this.dataService.createTodo(todo).subscribe(success => {
			if (success) {
				this.refreshTodos();
			}
		})
	}


	ngOnInit(): void {
		this.refreshTodos();
	}

	refreshTodos() {
		this.dataService.getTodos().subscribe(data => {
			this.todos = data;
		}, error => {
			this.errorMessage = error;
		});
	}
	
	showAllToDos(){
		this.dataService.loadAllTodos().subscribe(p => {
			this.todos = this.dataService.todos;
			//console.log(this.todos);
		}, error => {
			console.log(error);
		});
	}


	

	// todo={
	// 	"id": 1,
	// 	"imageUrl" :"http://proficiencyconsulting.com/content/forestdark/img/images-about.png",
	// 	"title": "Learn Angular",
	// 	"isCompleted": true,
	// 	"startDate": "2017-11-01T00:00:00",
	// 	"endDate": "2017-11-01T00:00:00",
	// 	"minutesSpent": 30,
	// 	"priority": 1

	//   };

	//   todos=[{
	// 	"id": 1,
	// 	"title": "Learn Angular",
	// 	"isCompleted": true,
	// 	"startDate": "2017-11-01T00:00:00",
	// 	"endDate": "2017-11-01T00:00:00",
	// 	"minutesSpent": 30,
	// 	"priority": 1
	//   },
	//   {
	// 	"id": 2,
	// 	"title": "Learn Angular 2",
	// 	"isCompleted": true,
	// 	"startDate": "2017-11-01T00:00:00",
	// 	"endDate": "2017-11-01T00:00:00",
	// 	"minutesSpent": 30,
	// 	"priority": 1
	//   }];

	getTitle(): string {
		return this.pageTitle + " from function";
	}

}
