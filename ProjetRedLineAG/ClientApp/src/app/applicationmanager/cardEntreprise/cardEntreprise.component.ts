import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ApplicationManagerService } from '../applicationmanager.service';


@Component({
    selector: 'app-cardEntreprise-component',
    templateUrl: './cardEntreprise.component.html',
    styleUrls: ['../home/home.component.css']

})
export class CardEntrepriseComponent implements OnInit {

    public entreprises: [any];
    public entreprise: [any] = [{}];
    public persons: [any];
    public edit: boolean = false;
    public comment: string;
    public statutList: [any];
    public personsList: [any];

    @Input() id: number;

    @Output() manipulatingLink = new EventEmitter<{ id: number, link: string }>();
    
    
    


    constructor(private router: Router, private _amService: ApplicationManagerService, private route: ActivatedRoute,) {

    }
    ngOnInit(): void {
        
        this._amService.getEntreprisePerson(this.id).subscribe(result => {
            
            console.log('batato');
            console.log(result);
            this.persons = result;            
            
            if (this.persons.length > 0) {
                this._amService.goStatuts().subscribe(result => {
                    console.log('statuts');
                    this.statutList = result;

                    this.persons.forEach(x => {
                        this.statutList.forEach(y => {
                            if (y.statutId == x.statutId) {
                                x.statutId = y.titleStatut
                            }
                        })
                    })
                    console.log(this.statutList);
                    console.log('new');
                    console.log(this.persons);
                    

                }, error => console.error(error));
            }
            console.log(this.persons);
        })
        this._amService.getEntreprise(this.id).subscribe(result => {
          

            if (result.length < 1) {
                 this._amService.getEntrepriseNoApplication(this.id).subscribe(result => {
                  
                     this.entreprise = result;
                   
                     console.log('biito');
                    console.log(this.entreprise);
                 });
                return 

            }
            console.log("oxi");
            
            this.entreprises = result;
            if (this.entreprises[0].entreprise.entrepriseId == 1) {
                
            }
            console.log(this.entreprises)


        }, error => console.error(error));


    }
    editEntreprise() {
        this.edit = true;

    }
    deleteEntreprise(id: number) {
        let text = "Supprimer ?";
        
        if (confirm(text) == true) {
            if (this.persons.length > 0) {
                this.persons.forEach(x => {
                    this.statutList.forEach(y => {
                        if (y.titleStatut == x.statutId) {
                            x.statutId = y.statutId
                        }
                    })
                })
               
                this.persons.forEach(x => {
                    x.entrepriseId = 1;
                    this._amService.updatePerson(x).subscribe(() => {
                        let link = ['/'];
                        this.router.navigate(link);
                       
                        this._amService.deleteEntreprise(id).subscribe(() => {
                            let link = ['/'];
                            this.router.navigate(link);
                        })
                        
                    })                    
                })
            } 
            if (this.persons.length < 1) {
                this._amService.deleteEntreprise(id).subscribe(() => {
                    let link = ['/applications'];
                    this.router.navigate(link);
                })
            }

        } else {
            return
        }


    }
    updateEntreprisePerson(id: number) {
        this._amService.updateEntreprisePerson(id).subscribe(() => {
            let link = ['/applications'];
            this.router.navigate(link);
        })

    }
    updateEntreprise() {
        this.entreprise[0].EntrepriseId = this.id;
        this.entreprise[0].CommentsEntreprise = this.comment; 
        
        this._amService.updateCommentEntreprise(this.entreprise[0]).subscribe(() => {
            let link = ['/applications'];
            this.router.navigate(link);
        })
    }
    navigateWithId(linkSent: string, idSent: number) {

        this.manipulatingLink.emit({ link: linkSent, id: idSent });

    }
    reloadComponent() {

        let link = ['/applications'];
        this.router.navigate(link);

    }

}
