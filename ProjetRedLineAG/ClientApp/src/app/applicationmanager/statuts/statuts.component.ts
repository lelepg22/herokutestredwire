import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ApplicationManagerService } from '../applicationmanager.service';
import { Statut } from '../models/Statut';

@Component({
  selector: 'app-statuts',
  templateUrl: './statuts.component.html',
  styleUrls: ['../home/home.component.css']
})
export class StatutsComponent implements OnInit {

    public statuts: any;
    public newStatut: any;
    public add: boolean = false;
    public contacts: [any];

    @Output() manipulatingLink = new EventEmitter<string>();

    constructor(
        private _amService: ApplicationManagerService,
        private router: Router) { }

    ngOnInit() {
        this._amService.goStatuts().subscribe(result => {
            console.log(result);
            this.statuts = result;
            this.statuts.shift();
        }, error => console.error(error));
        this.newStatut = new Statut;

        this._amService.goContact().subscribe(result => {
            console.log('BELEZA');
            this.contacts = result;
            this.contacts.shift();
            //this.contacts.forEach(x=> 
            console.log(this.contacts);
        }, error => console.error(error));
    }

    deleteStatut(id: number) {
        let text = "Supprimer ?";

        if (confirm(text) == true) {

            this.contacts.forEach(x => {
                if (x.statutId == id) {
                    x.statutId = 1;
                    this._amService.updatePerson(x).subscribe(result => {
                        console.log('resu');
                        console.log(result);
                    })
                }
            }
                )

            this._amService.deleteStatut(id).subscribe(() => {

                this.ngOnInit();
            })

        } else {
            return
        }

    }
    addStatut() {
        this.add = true;
    }
    goStatut() {

        if (!this.newStatut.titleStatut) {
            return console.log("Vous n'avez pas ajouté de document")
        }
        this._amService.postStatut(this.newStatut).subscribe(() => {
            this.ngOnInit();
        })

    }
    navigate(link: string) {

        this.manipulatingLink.emit(link);

    }

}


