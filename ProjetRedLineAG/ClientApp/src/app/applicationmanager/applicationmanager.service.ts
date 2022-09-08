import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Application } from './models/Application';
import { ApplicationEntreprisePerson } from './models/ApplicationEntreprisePerson';
import { Entreprises } from './models/Entreprises';
import { Persons } from './models/Persons';
import { PersonSent } from './models/PersonSent';
import { PersonsList } from './models/PersonsList';
import { DocumentSent } from './models/DocumentSent';
import { Statut } from './models/Statut';
//import { debug } from 'console';

@Injectable({
  providedIn: 'root'
})
export class ApplicationManagerService {

    private url = '/home';
    private url2 = '';


    constructor(private http: HttpClient) {
    }
    //main-page
    goHome(): Observable<[any]> {
        this.url = '/home'
        return this.http.get<[any]>(this.url);
    }
    goEntreprise(): Observable<[any]> {
        this.url = '/entreprises' 
        return this.http.get<[any]>(this.url);
    }
    goContact(): Observable<[any]> {
        this.url = '/contacts'
        return this.http.get<[any]>(this.url);
    }
    goDocuments(): Observable<[any]> {
        this.url = '/documents'
        return this.http.get<[any]>(this.url);
    }
    goStatuts(): Observable<[any]> {
        this.url = '/contacts/statuts'
        return this.http.get<[any]>(this.url);
    }
    //get's by id
    getApplicationDocSent(id: any): Observable<[any]> {
        this.url = '/home/documentsent?id=' + id;
        return this.http.get<[any]>(this.url);
        
    }
    getApplicationPersonSent(id: any): Observable<[any]> {
        this.url = '/contacts/personsent?id=' + id;
        return this.http.get<[any]>(this.url);

    }
    
    getEntrepriseNoApplication(id: any): Observable<[any]> {
        this.url = '/entreprises/get?id=' + id;
        return this.http.get<[any]>(this.url);
    }
    getEntreprisePerson(id: any): Observable<[any]> {        
        this.url = '/contacts/get?id=' + id;
        return this.http.get<[any]>(this.url);
    }
    getEntreprise(id: number): Observable<[any]> {
        this.url = 'home/entreprise?id=' + id;

        return this.http.get<[any]>(this.url);

    }
    getPerson(id: number): Observable<[any]> {
        this.url = 'contacts/persons?id=' + id;

        return this.http.get<[any]>(this.url);

    }
    getStatut(id: number): Observable<[any]> {
        this.url = 'contacts/statut?id=' + id;

        return this.http.get<[any]>(this.url);
    }
    
    getApplication(id: number): Observable<ApplicationEntreprisePerson> {
        this.url = 'home/application?id=' + id;

        return this.http.get<any>(this.url);

    }
    //Data-filler
    getContacts(): Observable<[any]> {
        this.url = 'contacts/person';
        return this.http.get<[any]>(this.url);
    }

    getDocs():  Observable<[any]> {
        this.url = 'home/docs';
        return this.http.get<[any]>(this.url);
    }
    getPersonDocEntreprise(): Observable<[any, any, any,any]> {
        this.url = 'home/form';
        return this.http.get<[any,any,any,any]>(this.url);
    }
    //delete
    deletePerson(id: number) {
        this.url = 'contacts/delete?id=' + id;
        return this.http.delete<any>(this.url);
    }

    deleteApplication(id: number) {
        this.url = 'home/delete?id=' + id;
        return this.http.delete<any>(this.url);
    }
    deleteDocumentSent(id: number) {        
        this.url = 'documents/sent/delete?id=' + id;
        return this.http.delete<any>(this.url);
    }
    deleteDocument(id: number) {
        this.url = 'documents/delete?id=' + id;
        return this.http.delete<any>(this.url);
    }
    deleteStatut(id: number) {
        this.url = 'contacts/statut/delete?id=' + id;
        return this.http.delete<any>(this.url);
    }
    deletePersonSent(id: number) {
        this.url = 'contacts/sent/delete?id=' + id;
        return this.http.delete<any>(this.url);
    }
    deleteEntreprise(id: number) {
        this.url = 'entreprises/delete?id=' + id;
        return this.http.delete<any>(this.url);
    }


    //put

    updateApplication(data: ApplicationEntreprisePerson) {     
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
       
        this.url = '/home';
        console.log(data);
        console.log('dapplic');
        
        return this.http.put<ApplicationEntreprisePerson>(this.url, data[0], httpOptions);
    }

    updateCommentEntreprise(data: Entreprises) {
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }

        this.url = '/entreprises/comment';
        console.log(data);
        console.log('dapplic');        

        return this.http.put<Entreprises>(this.url, data, httpOptions);
    }
    updateEntreprisePerson(id: number) {
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        this.url = '/entreprises/persons?id=' + id; 
        console.log(id);
        console.log('dapplic');

        return this.http.put<number>(this.url, id, httpOptions);
    }
    updatePerson(data: Persons) {
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }        
        
        this.url = '/contacts/update';
        console.log(data);
        console.log('dapplic');

        return this.http.put<Persons>(this.url, data, httpOptions);

    }

    // Posts
    postApplication(data: ApplicationEntreprisePerson) {
        this.url = 'home/';
       //this.url2 = 'contacts/personSent';
        console.log(data);
        console.log('dada submit');
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http.post<ApplicationEntreprisePerson>(this.url, data, httpOptions);

       // this.http.post<PersonSent>(this.url2, person, httpOptions);     
    
    }
    postEntreprise(data: Entreprises): Observable<ApplicationEntreprisePerson> {
        this.url = 'entreprises';
        console.log(data);
        console.log('dada submit');
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
       
        return this.http.post<ApplicationEntreprisePerson>(this.url, data, httpOptions);

    }
    postPerson(data: Persons): Observable<ApplicationEntreprisePerson> {
        this.url = '/contacts';
        console.log(data);
        console.log('dada submit');
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http.post<ApplicationEntreprisePerson>(this.url, data, httpOptions);

    }

    postPersonSent(data: PersonSent): Observable<PersonSent> {      
        
        this.url = '/Contacts/sent';
        console.log(data);
        console.log('dada submit');
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http.post<PersonSent>(this.url, data, httpOptions);

    }
    postStatut(data: Statut): Observable<Statut> {

        this.url = '/Contacts/statut';
        console.log(data);
        console.log('dada submit');
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http.post<Statut>(this.url, data, httpOptions);

    }
    postDocSent(data: DocumentSent): Observable<DocumentSent> {

        this.url = '/documents/sent';
        console.log(data);
        console.log('dada submit');
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http.post<DocumentSent>(this.url, data, httpOptions);

    }
    postDocument(data: Document): Observable<Document> {

        this.url = '/documents';
        console.log(data);
        console.log('dada submit');
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        }
        return this.http.post<Document>(this.url, data, httpOptions);

    }
}
