"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ApplicationEntreprisePerson = void 0;
;
var ApplicationEntreprisePerson = /** @class */ (function () {
    function ApplicationEntreprisePerson() {
        this.StatusApplication = "ouvert";
        this.TimeApplication = new Date();
        this.EntrepriseId = 1;
        this.documentSent = [{ DocumentId: 0, ApplicationId: 0 }];
        this.personSent = [{ PersonId: 0, ApplicationId: 0 }];
    }
    return ApplicationEntreprisePerson;
}());
exports.ApplicationEntreprisePerson = ApplicationEntreprisePerson;
//# sourceMappingURL=ApplicationEntreprisePerson.js.map