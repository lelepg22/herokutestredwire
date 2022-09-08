;

export class ApplicationEntreprisePerson {

    Id: number;
    TitleApplication: string;
    CommentsApplication: string;
    ExternalLinkApplication: string;
    StatusApplication: string = "ouvert";
    TimeApplication: Date = new Date();
    EntrepriseId: number = 1 ;    
    documentSent: [{DocumentId:number, ApplicationId:number}] = [{DocumentId:0, ApplicationId:0}];
    personSent: [{PersonId:number, ApplicationId: number }] = [{PersonId:0, ApplicationId:0}];    
    

}