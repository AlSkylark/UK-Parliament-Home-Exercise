import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EditorStateService {

  constructor() { }

  private editorStateSubject = new Subject<{ state: boolean, id?: number }>();
  public currentId?: number;
  editorState$ = this.editorStateSubject.asObservable();

  openEditor = (id?: number) => {
    this.editorStateSubject.next({ state: true, id: id });
    this.currentId = id;
  }

  openEditorForCreation = () => {
    this.editorStateSubject.next({ state: true, id: undefined });
    this.currentId = undefined;
  }

  closeEditor = () => {
    this.editorStateSubject.next({ state: false });
  }

}
