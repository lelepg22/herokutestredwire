import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApplicationEntreprisePerson } from '../models/ApplicationEntreprisePerson';
import { Entreprises } from '../models/Entreprises';
import { Persons } from '../models/Persons';
import { ApplicationManagerService } from '../applicationmanager.service';
import { Router } from '@angular/router';
import { Statut } from '../models/Statut';

@Component({
    selector: 'app-formPerson-component',
    templateUrl: './formPerson.component.html',
    styleUrls: ['../home/home.component.css']

})
export class FormPersonComponent implements OnInit {
    @Input() application: ApplicationEntreprisePerson;
    @Input() entreprise: Entreprises;
    @Input() person: Persons;
    @Input() formInfo: [any,any, any, any];

    @Output() manipulatingLink = new EventEmitter<string>();

    statut: Statut;
    inputPerson: string = "prenom, nom";
    statutTitle: string = "Statuts";
    entrepriseTitle: string = "Entreprises";

    addNewStatut: boolean = false;

    ngOnInit() {
        this.application = new ApplicationEntreprisePerson();
        this.entreprise = new Entreprises();
        this.person = new Persons();
        this.statut = new Statut;
     

        this._amService.getPersonDocEntreprise().subscribe(data => {
            this.formInfo = data;
            this.formInfo[3].shift();
            this.formInfo[0].shift();
            console.log('etaMenino');
            console.log(this.formInfo);
        })
    }

    constructor(
        private _amService: ApplicationManagerService,
        private router: Router) { }

    onSubmit(): void {
        
        console.log(this.person);
        this._amService.postPerson(this.person).subscribe(() => {
            
            this.navigate('contacts'); 
        })
    }
    setStatut(x: any) { 
        this.statutTitle = x.titleStatut;
        this.person.statutId = x.statutId;
       /* this.person.Statut.shift();
        this.person.Statut.push({ TitleStatut: x });*/
        
    }
    setEntreprise(x: any, y: string) {
        
        this.person.entrepriseId = x;
        this.entrepriseTitle = y;

    }
    navigate(link: string) {

        this.manipulatingLink.emit(link);

    }

    addStatut() {
        this.addNewStatut = true;
    }
    goStatutNew() {
        this._amService.postStatut(this.statut).subscribe(() => {
            //this.ngOnInit();
            this.formInfo[3] = null;
            this._amService.getPersonDocEntreprise().subscribe(data => {
                this.formInfo = data;
                this.formInfo[3].shift();
                this.formInfo[0].shift();
                console.log('etaMenino');
                console.log(this.formInfo);
            })
        

            this.addNewStatut = false;
        })

    }
}
