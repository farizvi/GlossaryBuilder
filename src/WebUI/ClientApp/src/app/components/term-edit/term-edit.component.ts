import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute} from '@angular/router';
import {GlossaryService} from '../../services/glossary.service';
import {IGlossary} from '../../models/glossary.model';
import {IEditTerm} from "../../models/editterm.model";

@Component({
  selector: 'app-term-edit',
  templateUrl: './term-edit.component.html',
  styleUrls: ['./term-edit.component.css']
})
export class TermEditComponent implements OnInit {

  editTerm: FormGroup;
  submitted = false;
  isError = false;
  failedToUpdate = false;

  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private glossaryService: GlossaryService
  ) { }

  ngOnInit(): void {
    this.editTerm = this.formBuilder.group({
      term: ['', Validators.required],
      description: ['', Validators.required]
    });

    const selectedId: number = +this.activatedRoute.snapshot.params.id;
    this.glossaryService.getGlossaryTerm(selectedId)
          .subscribe(
            (term: IGlossary) => {
                this.editTerm.controls.term.setValue(term.termText);
                this.editTerm.controls.description.setValue(term.definition);
          },
          error => {
              this.isError = true;
          });
  }

  get f() { return this.editTerm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.editTerm.invalid) {
      return;
    }

    const selectedId: number = +this.activatedRoute.snapshot.params.id;
    const term: IEditTerm = {
      id: selectedId,
      termText: this.editTerm.controls.term.value,
      definition: this.editTerm.controls.description.value
    };

    this.glossaryService
        .updateGlossaryTerm(selectedId, term)
        .subscribe(
            () => {
            window.location.href = '/';
          },
          error => {
            this.failedToUpdate = true;
          }
        );
  }

  onReset() {
    this.submitted = false;
    this.editTerm.reset();
  }

}
