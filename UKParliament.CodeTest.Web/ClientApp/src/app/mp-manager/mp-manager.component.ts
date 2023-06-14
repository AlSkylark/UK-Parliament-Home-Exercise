import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MPPaginatorModel } from 'src/models/mp-paginator-model';
import { EditorStateService } from '../services/editor-state.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-mp-manager',
  templateUrl: './mp-manager.component.html',
  styleUrls: ['./mp-manager.component.scss']
})
export class MpManagerComponent implements OnInit {

  paginator: MPPaginatorModel | undefined;
  listActive: boolean = true;
  editorActive: boolean = false;
  mpId?: number;
  private editorStateSubscription: Subscription;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private editor: EditorStateService) {
    this.GoToPage();
    this.editorStateSubscription = editor.editorState$.subscribe(v => {
      if (v.state) this.OpenEditor(v.id);
      if (!v.state) this.CloseEditor();
    });
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.editorStateSubscription.unsubscribe();
  }

  GoToPage(number: number = 1) {
    this.http.get<MPPaginatorModel>(this.baseUrl + `api/mp?page=${number}`)
      .subscribe(v => {
        this.paginator = v;
      });
  }

  FindPage(id: number = 1) {
    this.http.get<MPPaginatorModel>(this.baseUrl + `api/mp?id=${id}`)
      .subscribe(v => {
        this.paginator = v;
      });
  }

  ToggleComponents(which: string) {
    const choice = (which === "list");
    this.listActive = choice;
    this.editorActive = !choice;
  }

  OpenEditor(id?: number) {
    this.mpId = id;
    this.editorActive = true;
    this.listActive = false;
  }

  OpenEditorForCreation() {
    this.editor.openEditorForCreation();
  }

  CloseEditor() {
    this.editorActive = false;
    this.listActive = true;
  }

  OnDataChanged(id: number) {
    this.FindPage(id);
    this.mpId = id;
    this.editor.openEditor(id);
  }

}
