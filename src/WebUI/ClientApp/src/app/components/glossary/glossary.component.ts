import {ChangeDetectionStrategy, Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import { data} from '../../../assets/data';
import { Columns, Config, DefaultConfig } from 'ngx-easy-table';
import {Router} from '@angular/router';
import {IGlossary} from '../../models/glossary.model';
import {GlossaryService} from '../../services/glossary.service';
import {AlertifyService} from '../../services/alertify.service';

@Component({
  selector: 'app-glossary',
  templateUrl: './glossary.component.html',
  styleUrls: ['./glossary.component.css'],
  changeDetection: ChangeDetectionStrategy.Default
})
export class GlossaryComponent implements OnInit {
  @ViewChild('actionTpl', { static: true }) actionTpl: TemplateRef<any>;

  public configuration: Config;
  public columns: Columns[];
  public data: IGlossary[];
  isError = false;
  failedToDelete = false;

  constructor(
    private router: Router,
    private glossaryService: GlossaryService,
    private alertify: AlertifyService
  ) {
  }

  ngOnInit(): void {
    this.configuration = { ...DefaultConfig };
    this.columns = [
      { key: 'id', title: 'ID' },
      { key: 'termText', title: 'Term' },
      { key: 'definition', title: 'Description' },
      { key: 'action', title: 'Actions', cellTemplate: this.actionTpl, searchEnabled: false, orderEnabled: false}
    ];
    this.configuration.searchEnabled = true;

    this.glossaryService.getGlossaryTerms().subscribe(
      (response) => {
        this.data = response['terms'];
      },
      error => {
        this.isError = true;
        this.data = data;
      });
  }

  edit(rowIndex: number): void {
    const selectedId: number = this.data[rowIndex].id;
    this.router.navigate(['/edit-term/', selectedId]).then(e => {});
  }

  remove(rowIndex: number): void {
    this.alertify.confirm('Are you sure you want to delete this term?', () => {
      // this.data = [...this.data.filter((v: IGlossary, k: number) => k !== rowIndex)];
      const selectedId = this.data[rowIndex].id;

      this.glossaryService.deleteTerm(selectedId).subscribe(
        () => {
          window.location.reload();
        },
        error => {
          this.failedToDelete = true;
        }
      );

    });
  }

}
