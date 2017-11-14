import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component';
import { TodoComponent } from './todo/todo.component';
import { TodoListComponent } from './todo/todoList.component';
import { DataService } from './shared/dataService';
import { TodoEditComponent } from './todo/todo-edit.component';

let routes = [
  { path: "", component: TodoListComponent },
  { path: "todo/:id", component: TodoEditComponent },
]

@NgModule({
  declarations: [
    AppComponent,
    TodoListComponent,
    TodoComponent,
    TodoEditComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes, {
      useHash: true,
      enableTracing: false
    })

  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
