export function getFilters(event: React.ChangeEvent<HTMLSelectElement>) {
    event.preventDefault();
    let names: any[] = [];
    let labelText: string;
    let valid = true;
    const entry:string = event.currentTarget.value;
    console.log(entry);
    switch (entry) {
        case "Instalaciones":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona una instalacion';
            break;
        case "Brindado en: Instalaciones":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona una instalacion';
            break; 
        case "Servicios":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona un servicio';
            break;
        case "Reparaciones":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona una reparacion';
            break;
        case "Reparaciones Impilcadas":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona una reparacion';
            break;
        case "Estancias":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona una estancia';
            break;
        case "Clientes con naves":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona un cliente con nave';
            break;
        case "Aeropuerto":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona un aeropuerto';;
            break;
        case "Brindado en: Aeropuertos":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona un aeropuerto';
            break;
        case "Naves":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona una nave';
            break;
        case "Brindado a":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona una nave';
            break;
        case "Dueño":
            names = [1, 2, 3, 4];
            labelText = 'Selecciona un cliente';
            break;
        default:
            names = [1, 2, 3, 4];
            labelText = '';
            valid = false;
            console.log('Invalid');
            break;
    }
    if (valid) {
        const filterContainer = document.getElementById('filterTable');
        if (filterContainer) {
            const selectElement = document.createElement('select');
            selectElement.className = "border-2";
            names.forEach((val) => {
                const optionElement = document.createElement('option');
                optionElement.value = "";
                optionElement.textContent = val.toString();
                selectElement.appendChild(optionElement);
            });

            const labelElement = document.createElement('label');
            labelElement.textContent = labelText;

            const divElement = document.createElement('div');
            divElement.className = "flex flex-row gap-1 py-auto w-fit";

            divElement.appendChild(labelElement);
            divElement.appendChild(selectElement);


            filterContainer.appendChild(divElement);
        }
    }
}