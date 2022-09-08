import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApplicationManagerService } from '../applicationmanager.service';
import { Router } from '@angular/router';
import { Persons } from '../models/Persons';
import { Statut } from '../models/Statut';

@Component({
  selector: 'app-contacts-component',
    templateUrl: './contacts.component.html',
    styleUrls: ['../home/home.component.css']

})
export class ContactsComponent implements OnInit {
    @Input() formInfo: [any];
    @Input() person: Persons;

    @Output() manipulatingLink = new EventEmitter<string>();

    @Output() manipulateWithId = new EventEmitter<{ id: number, link: string }>();

    public contacts: [any];
    public statutList: [any];

    constructor(private router: Router, private _amService: ApplicationManagerService) {
      
    }
    ngOnInit(): void {

       

        this._amService.goContact().subscribe(result => {
            console.log('BELEZA');
            this.contacts = result;
            this.contacts.shift();
            //this.contacts.forEach(x=> 
            console.log(this.contacts);
            this._amService.goStatuts().subscribe(result => {
                console.log('statuts');
                this.statutList = result;

                this.contacts.forEach(x => {
                    this.statutList.forEach(y => {
                        if (y.statutId == x.statutId) {
                            x.statutId = y.titleStatut                           
                        }
                        })
                    })
                console.log(this.statutList);
                console.log('new');
                console.log(this.contacts);

            }, error => console.error(error));
        }, error => console.error(error));
    }
    personNavigate(id: number) {
        this.router.navigateByUrl('/cardPerson/' + id)
    }
    navigate(link: string) {

        this.manipulatingLink.emit(link);

    }
    navigateWithId(linkSent: string, idSent: number) {

        this.manipulateWithId.emit({ link: linkSent, id: idSent });

    }
}


