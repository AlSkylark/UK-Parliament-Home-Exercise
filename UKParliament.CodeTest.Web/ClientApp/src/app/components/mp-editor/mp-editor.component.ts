import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Subscription, catchError, throwError } from 'rxjs';
import { EditorStateService } from 'src/app/services/editor-state.service';
import { AffiliationViewModel } from 'src/models/affiliation-model';
import { MPEditModel } from 'src/models/mp-edit-model';

@Component({
  selector: 'app-mp-editor',
  templateUrl: './mp-editor.component.html',
  styleUrls: ['./mp-editor.component.scss']
})
export class MpEditorComponent implements OnInit {

  @Input() mpId?: number;
  @Output() dataUpdated = new EventEmitter<number>();

  private editor: EditorStateService;
  private editorStateSubscription: Subscription;
  private emptyMp = {
    personId: 0,
    name: '',
    dob: new Date(),
    addressId: 0,
    affiliationId: 0,
    address1: '',
    address2: '',
    town: '',
    county: '',
    postcode: ''
  };

  public affiliations: AffiliationViewModel[] = [];
  public mp: MPEditModel = this.emptyMp;
  public colour = "#f0f0f0";
  public reqError = false;

  constructor(private _editor: EditorStateService, private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.editor = _editor;
    this.editorStateSubscription = this.editor.editorState$.subscribe(v => {
      if (!v.state) return;
      if (v.id) {
        this.GetData(v.id);
      }
      else {
        this.mp = this.emptyMp;
        this.LoadColour();
      }

    });
    this.GetAffiliations();
  }

  GetAffiliations() {
    this.httpClient.get<AffiliationViewModel[]>(`${this.baseUrl}api/affiliation`).subscribe(v => this.affiliations = v);
  }

  GetData(id: number) {
    this.httpClient.get<MPEditModel>(`${this.baseUrl}api/mp/${id}`).subscribe(v => {
      this.mp = v;
      this.LoadColour();
    });
  }

  ngOnInit(): void {
    if (this.mpId) this.GetData(this.mpId);
  }

  ngOnDestroy(): void {
    this.editorStateSubscription.unsubscribe();
  }

  closeEditor() {
    this.editor.closeEditor();
  }

  LoadColour() {
    const affi = this.affiliations.find(affi => affi.affiliationId == this.mp.affiliationId);
    this.colour = "#f0f0f0";
    if (affi) this.colour = affi.colour;
  }

  handleError(err: HttpErrorResponse) {
    //I'm running out of time here, so I'm just going to display a simple error message!
    this.reqError = true;
    return throwError(() => new Error(":("));
  }

  handleSuccess(mp: MPEditModel) {
    this.mp = mp;
    this.LoadColour();
    this.dataUpdated.emit(mp.personId);
  }

  submit() {

    if (this.mpId) { //update
      console.log(JSON.stringify(this.mp));
      this.httpClient.patch<MPEditModel>(`${this.baseUrl}api/mp/${this.mpId}`,
        JSON.stringify(this.mp),
        { headers: { "Content-Type": "application/json" } })
        .pipe(
          catchError(err => this.handleError(err))
        )
        .subscribe(v => this.handleSuccess(v));

    } else { //create
      this.httpClient.post<MPEditModel>(`${this.baseUrl}api/mp`, JSON.stringify(this.mp),
        { headers: { "Content-Type": "application/json" } })
        .pipe(
          catchError(err => this.handleError(err))
        )
        .subscribe(v => {
          this.handleSuccess(v);
          this.editor.closeEditor();
        });
    }
  }

}
