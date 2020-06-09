import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {GlossaryService} from '../../services/glossary.service';
import {INewTerm} from '../../models/newterm.model';

@Component({
  selector: 'app-term-add',
  templateUrl: './term-add.component.html',
  styleUrls: ['./term-add.component.css']
})
export class TermAddComponent implements OnInit {
  addTerm: FormGroup;
  submitted = false;
  isError = false;

  constructor(
    private formBuilder: FormBuilder,
    private glossaryService: GlossaryService
  ) { }

  ngOnInit(): void {
    this.addTerm = this.formBuilder.group({
      term: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  get f() { return this.addTerm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.addTerm.invalid) {
      return;
    }

    const term: INewTerm = {
      termText: this.addTerm.controls.term.value,
      definition: this.addTerm.controls.description.value
    };

    this.glossaryService.saveGlossaryTerm(term).subscribe(
      () => {
        window.location.href = '/';
      },
      error => {
        this.isError = true;
      }
    );
  }

  onReset() {
    this.submitted = false;
    this.addTerm.reset();
  }
}
