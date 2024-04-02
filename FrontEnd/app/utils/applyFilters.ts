'use client'
import buildQuery from 'odata-query'
export default function applyFilters(fieldnames: string[]) {
    const filterContainer = document.getElementById('filterTable');
    const filters = filterContainer?.getElementsByTagName('select');
    const queryfilters:any = {};
    // const queryfilters: any[] = [];
    const expand:string[] = [];
    if (filters) {
        for (let index = 0; index < filters.length; index++) {
            const Instancename = filters[index].name;
            const data = filters[index].selectedOptions[0].innerText;
            const fieldname = fieldnames[index];
            queryfilters[Instancename] = {any:{[fieldname]: data}};
            // queryfilters.push({path: Instancename, field: fieldname, value: data});
            expand.push(Instancename);
        }
    const query = buildQuery({filter: queryfilters /*, expand: expand*/});
        console.log({filter: queryfilters, expand: expand});
        console.log(query);
        localStorage.setItem('query', query);        
    }
}


//Airports?$expand=Facilities($filter=Type eq 'Almacén')
