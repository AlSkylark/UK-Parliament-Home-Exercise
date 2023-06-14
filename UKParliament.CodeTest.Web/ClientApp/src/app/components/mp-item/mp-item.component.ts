import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EditorStateService } from 'src/app/services/editor-state.service';
import { MPViewModel } from 'src/models/mp-view-model';

@Component({
  selector: 'app-mp-item',
  templateUrl: './mp-item.component.html',
  styleUrls: ['./mp-item.component.scss']
})
export class MpItemComponent implements OnInit {

  @Input() mp!: MPViewModel;
  private editorStateSubscription: Subscription;
  private editor: EditorStateService;
  currentId?: number;

  constructor(_editor: EditorStateService) {
    this.editor = _editor;
    this.editorStateSubscription = _editor.editorState$.subscribe(v => {
      this.currentId = v.id;
    });
  }

  ngOnInit(): void {
    this.currentId = this.editor.currentId;
  }

  ngOnDestroy(): void {
    this.editorStateSubscription.unsubscribe();
  }

  openEditor(id: number) {
    this.editor.openEditor(id);
  }

}
