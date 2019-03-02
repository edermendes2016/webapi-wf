import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TarefasComponent } from './tarefas/tarefas.component';
import { TarefaComponent } from './tarefas/tarefa/tarefa.component';
import { TarefaListComponent } from './tarefas/tarefa-list/tarefa-list.component';
import { TarefaService } from './shared/tarefa.service';

@NgModule({
  declarations: [
    AppComponent,
    TarefasComponent,
    TarefaComponent,
    TarefaListComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [TarefaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
