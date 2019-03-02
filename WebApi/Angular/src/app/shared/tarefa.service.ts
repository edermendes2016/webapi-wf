import { Injectable } from '@angular/core';
import { Tarefa } from './tarefa';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TarefaService {
  formData: Tarefa
  readonly url = 'localhost:50439/api';
  list: Tarefa[];

  constructor(private http: HttpClient) { }

  //Get List
  refreshList() {
    this.http.get(this.url + '/Tarefas')
      .toPromise()
      .then(res => this.list = res as Tarefa[]);
  }

  //Post data
  postTarefa() {
    return this.http.post(this.url + '/Tarefa', this.formData);
  }

  //Update data
  updateTarefa() {
    return this.http.put(this.url + '/Tarefa/' + this.formData.Id, this.formData);
  }

  //Delete Data
  deleteTarefa(id) {
    return this.http.delete(this.url + '/Tarefa/' + id);
  }

}
