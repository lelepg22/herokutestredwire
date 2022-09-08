import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ApplicationManagerService } from '../applicationmanager.service';
import { Persons } from '../models/Persons';


@Component({
    selector: 'app-cardPerson-component',
    templateUrl: './cardPerson.component.html',
    styleUrls: ['../home/home.component.css']

})
export class CardPersonComponent implements OnInit {

    public entreprises: [any];
    public entreprise: [any] = [{}];
    public persons: [any];
    public person: [Persons];
    public edit: boolean = false;
    public comment: string;
    public statut: [any]; 

    @Input() id: number;

    @Output() manipulatingLink = new EventEmitter<string>();
    

    constructor(private router: Router, private _amService: ApplicationManagerService, private route: ActivatedRoute,) {

    }
    ngOnInit(): void {
        
        this._amService.getPerson(this.id).subscribe(result => {

            console.log('person');
            console.log(result);
            this.person = result;
            console.log(this.person);
            this._amService.getEntreprise(this.person[0].entrepriseId).subscribe(result => {

                if (result.length < 1) {
                    this._amService.getEntrepriseNoApplication(this.person[0].entrepriseId).subscribe(result => {

                        console.log('fefe');
                        console.log(result);

                        this.entreprise = result;                        

                        console.log(this.entreprise);
                    });
                    return

                }
                console.log("linda");
                
                this.entreprises = result;
                console.log(this.entreprises);
              
               


            }, error => console.error(error));
            this._amService.getStatut(this.person[0].statutId).subscribe(result => {

                console.log('statut');
                console.log(result);
                this.statut = result;
                console.log(this.persons);
            })
            
        })
        this._amService.getEntreprisePerson(this.id).subscribe(result => {
            
            console.log('batato');
            console.log(result);
            this.persons = result;
            console.log(this.persons);
        })
       

    }


    editPerson() {
        this.edit = true;

    }
    updateEntreprisePerson(id: number) {
        this._amService.updateEntreprisePerson(id).subscribe(() => {
            this.navigate('contacts'); 
        })

    }
    updateComment() {
        this.entreprise[0].EntrepriseId = this.id;       
        this.entreprise[0].CommentsEntreprise = this.comment; 
        this._amService.updateCommentEntreprise(this.entreprise[0]).subscribe(() => {
            this.navigate('contacts'); 
        })
    }
    goEditPerson() {
        this._amService.updatePerson(this.person[0]).subscribe(() => {
            this.navigate('contacts'); 
        })
    }
    deletePerson() {
        let text = "Supprimer ?";

        if (confirm(text) == true) {

            this._amService.deletePerson(this.person[0].id).subscribe(() => {
                this.navigate('contacts');                
            })          

        } else {
           return

        }
    }
    navigate(link: string) {

        this.manipulatingLink.emit(link);

    }

}
