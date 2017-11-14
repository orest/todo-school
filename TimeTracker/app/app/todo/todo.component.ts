import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ToDo } from '../shared/todo';
import { DataService } from '../shared/dataService';

export enum ComponentMode {
	Display,
	Create,
	Update
}

@Component({
	selector: 'todo',
	templateUrl: './todo.component.html',
})
export class TodoComponent {
	@Input() todo: ToDo;
	@Input() mode: ComponentMode;
	@Output() saveNewTodo = new EventEmitter();
	newTodo = new ToDo();
	componentStates = ComponentMode;

	constructor(private dataService: DataService) {


	}
	createToDo() {
		this.saveNewTodo.emit(this.newTodo)
		this.newTodo = new ToDo();
	}

	markAsCompleted(): void {
		this.todo.isCompleted = !this.todo.isCompleted;
		this.dataService.saveTodo(this.todo).subscribe(p => {
			//maybe reload
		})
	}
}
