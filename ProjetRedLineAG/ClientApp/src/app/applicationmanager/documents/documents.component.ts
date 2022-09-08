import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApplicationManagerService } from '../applicationmanager.service';
import { Router } from '@angular/router';
import { Documents } from '../models/Documents';

@Component({
    selector: 'app-documents-component',
    templateUrl: './documents.component.html',
    styleUrls: ['../home/home.component.css']

})
export class DocumentsComponent implements OnInit {
    public documents: Document[];
    public newDoc: any;
    public add: boolean = false;

    @Output() manipulatingLink = new EventEmitter<string>();

    constructor(
        private _amService: ApplicationManagerService,
        private router: Router) { }

    ngOnInit() {
        this._amService.goDocuments().subscribe(result => {
            console.log(result);
            this.documents = result;            
        }, error => console.error(error));
        this.newDoc = new Documents;
    }
    
    deleteDocument(id: number) {
        let text = "Supprimer ?";

        if (confirm(text) == true) {

            this._amService.deleteDocument(id).subscribe(() => {
                
                this.ngOnInit();
            })

        } else {
            return
        }
        
    }
    addDoc() {
        this.add = true;
    }
    goDoc() {
        
        if (!this.newDoc.titleDocument) {
            return console.log("Vous n'avez pas ajouté de document") }
        this._amService.postDocument(this.newDoc).subscribe(() => {
            this.ngOnInit();
        })

    }
    navigate(link: string) {

        this.manipulatingLink.emit(link);

    }

}

interface Document {
    Id: number;
    TitleDocument: string;

}
