import buildQuery from 'odata-query'
export default function applyFilters() {
    const filterContainer = document.getElementById('filterTable');
    const filters = filterContainer?.getElementsByTagName('select');
    const queryfilters = [];
    if (filters) {
        for (let index = 0; index < filters.length; index++) {
            const name = filters[index].name;
            const data = filters[index].value;
            queryfilters.push({ [name]: data });
        }
        const query = buildQuery(queryfilters);
    }
}