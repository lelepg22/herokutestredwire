import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ApplicationManagerService } from '../applicationmanager.service';

@Component({
    selector: 'app-entreprises-component',
    templateUrl: './entreprises.component.html',
    styleUrls: ['../home/home.component.css']

})
export class EntreprisesComponent implements OnInit {
    public entreprises: [any];

    @Output() manipulatingLink = new EventEmitter<string>();

    @Output() manipulateWithId = new EventEmitter<{ id: number, link: string }>();

    constructor(private router: Router, private _amService: ApplicationManagerService) {

    }
    ngOnInit(): void {
        this._amService.goEntreprise().subscribe(result => {
            console.log(result);
            this.entreprises = result;
            this.entreprises.shift();
            this.do();
        }, error => console.error(error));

    }
    goCardEntreprise(x: any) {

        this.router.navigateByUrl('/cardEntreprise/' + x)
    }

    navigate(link: string) {

        this.manipulatingLink.emit(link);

    }

    navigateWithId(linkSent: string, idSent: number) {

        this.manipulateWithId.emit({ link: linkSent, id: idSent });

    }

    do() {
        let link2 = ['/'];
        this.router.navigate(link2);

    }

}

