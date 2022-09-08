import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApplicationManagerService } from '../applicationmanager.service';
import { Router } from '@angular/router';
import { ApplicationEntreprisePerson } from '../models/ApplicationEntreprisePerson';
import { Entreprises } from '../models/Entreprises';
import { Persons } from '../models/Persons';
import { PersonsList } from '../models/PersonsList';
import { PersonSent } from '../models/PersonSent';

@Component({
    selector: 'app-formEntreprise-component',
    templateUrl: './formEntreprise.component.html',
    styleUrls: ['../home/home.component.css']

})
export class FormEntrepriseComponent implements OnInit {

    @Input() application: ApplicationEntreprisePerson;
    @Input() entreprise: Entreprises;
    @Input() formInfo: [any, any, any, any];
    @Input() person: Persons;
    @Input() personList: PersonsList;
    @Input() personSent: PersonSent;

    @Output() manipulatingLink = new EventEmitter<string>();

    inputPerson: string = "Personne";
    applicId: number = 0;
    entrepriId: number = 0;

    ngOnInit() {
        this.application = new ApplicationEntreprisePerson();
        this.entreprise = new Entreprises();
        this.person = new Persons();
        this.personList = new PersonsList();
        this.personSent = new PersonSent();

        this._amService.goEntreprise().subscribe(data => {
            console.log("debuga");
            console.log(data);
            this.entrepriId = data[data.length - 1].entrepriseId;


        })

        this._amService.goHome().subscribe(data => {
            console.log("debuga");
            console.log(data);
            this.applicId = data[data.length - 1].applicationId;

        })

        this._amService.getPersonDocEntreprise().subscribe(data => {
            this.formInfo = data;
            console.log('etaMenino');
            console.log(this.formInfo);
        })
    }
    constructor(
        private _amService: ApplicationManagerService,
        private router: Router) { }
    onSubmit(): void {

        console.log(this.entreprise);
        if (!this.entreprise.TelEntreprise) {
            this.entreprise.TelEntreprise = "Non informé";
        }
        if (!this.entreprise.EmailEntreprise) {
            this.entreprise.EmailEntreprise = "Non informé";

        }
        
        this._amService.postEntreprise(this.entreprise).subscribe(() => {
            let link = ['/entreprise'];
            this.router.navigate(link);
        })
    }
    setPerson(x: any) {

        this.person = x;
        this.inputPerson = x.firstNamePerson + " " + x.lastNamePerson;
        console.log(this.person);
    }

    navigate(link: string) {

        this.manipulatingLink.emit(link);

    }
    /* IF I ADD OPTION TO ADD PERSON That works on the Entreprise directly on the form Entreprise (to Fix)
    addContactToList() {

        console.log(this.person);

        if (!this.person.id) {
            return console.log("Vous n'avez pas choisi une personne");
        }
        console.log(this.application);

        //this.personSent.person.push({PersonId: this.person.id, ApplicationId: (this.applicId) });
             
        this.personList.person.push(this.person);
        this.person.entrepriseId = this.entrepriId;
        this._amService.updatePerson(this.person);
        this.application.personSent.push({ PersonId: this.person.id, ApplicationId: (this.applicId) });
        console.log(this.personList.person)
        console.log('macaco');


    }
    
    removeFromPersonList(id: number) {
        for (var i = 0; i < this.personList.person.length; i++) {
            if (this.personList.person[i].id == id) {
                this._amService.updatePerson(this.personList.person[i]);
                console.log(this.personList.person[i].id + " - " + id);
                this.personList.person.splice(i, 1);


            }
        }
        

    }*/

}
