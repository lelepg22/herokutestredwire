import { Pipe, PipeTransform } from '@angular/core';



@Pipe({ name: 'appFilter' })

export class FilterPipe implements PipeTransform {

    /**
  
     * Pipe filters the list of elements based on the search text provided
  
     *
  
     * @param items list of elements to search in
  
     * @param searchText search string
  
     * @returns list of elements filtered by search text or []
  
     *type 1 : TitleApplicatio -- type 2 : Entreprise -- type 3 : Status;
     */

    transform(items: any[], searchText: string, type: number): any[] {

        if (!items) {

            return [];

        }

        if (!searchText) {

            return items;

        }

        searchText = searchText.toLocaleLowerCase();



        return items.filter(it => {
          // * type 1 : TitleApplicatio-- type 2 : Entreprise-- type 3 : Status;
            if (type == 1) {
                console.log(type)
                return it.titleApplication.toLocaleLowerCase().includes(searchText);
            }
            if (type == 2) {
                return it.entreprise.titleEntreprise.toLocaleLowerCase().includes(searchText);
            }
            if (type == 3) {
                return it.statusApplication.toLocaleLowerCase().includes(searchText);
            }

        });

    }

}


