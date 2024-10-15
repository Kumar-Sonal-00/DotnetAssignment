import { Component } from '@angular/core';
import { Todo } from '../model/Todo';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent {
 // todoList contains all todos
 todoList: Todo[] =[];
 private nextId: number = 1;
 constructor() { }

 ngOnInit() {
 }
 // write logic to the onAddTodo method is to add a new todo to list
 // get maximum id in list and assign maximum id plus one while adding a todo
 onAddTodo(todoText: any) {
  if (todoText.trim()) {
    this.todoList.push({ todoId: this.nextId++, text: todoText, isCompleted: false });
  }
 }

 // write logic to the onClearTodos method to delete the all todos in the todoList
 onClearTodos() {
  this.todoList = [];
 }

 // write logic to method onCompletingTask, to mark todo as as completed or not
 onCompletingTodo(todo: Todo) {
  todo.isCompleted = !todo.isCompleted;
 }

 // write logic to method onDeletingTask, to delete the todo
 onDeletingTodo(todoId:any) {
  this.todoList = this.todoList.filter(todo => todo.todoId !== todoId);
 }
}
