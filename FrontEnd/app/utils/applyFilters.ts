'use client'
import buildQuery from 'odata-query'
export default function applyFilters(fieldnames: string[]) {
    const filterContainer = document.getElementById('filterTable');
    const filters = filterContainer?.getElementsByTagName('select');
    const queryfilters = [];
    if (filters) {
        for (let index = 0; index < filters.length; index++) {
            const Instancename = filters[index].name;
            const data = filters[index].selectedOptions[0].innerText;
            const fieldname = fieldnames[index];
            queryfilters.push({ [Instancename]: data });
        }
        const query = buildQuery({filter: queryfilters});
        console.log(query);
        localStorage.setItem('query', query);
    }
}

//Airports?$expand=Facilities($filter=Type eq 'Almacén')
