import { getEndpoint } from "./EntityConfigs";
export async function getFilters(event: React.ChangeEvent<HTMLSelectElement>) {
    event.preventDefault();
    let names: any[] = [];
    let labelText: string;
    let selectName:string;
    let valid = true;
    const entry:string = event.currentTarget.value;
    console.log(entry);
    let data: any[] = []
    switch (entry) {
        case "Instalaciones":
            data = await fetch(getEndpoint(entry), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.name);
            })
            labelText = 'Selecciona una instalacion';
            selectName = 'Facilities';
            break;
        case "Brindado en: Instalaciones":
            data = await fetch(getEndpoint('Instalaciones'), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.name);
            })
            labelText = 'Selecciona una instalacion';
            selectName = 'Facilities';
            break;
        case "Servicios":
            data = await fetch(getEndpoint(entry), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.description);
            })
            labelText = 'Selecciona un servicio';
            selectName = 'Services';
            break;
        case "Reparaciones":
            data = await fetch(getEndpoint(entry), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.description);
            })
            labelText = 'Selecciona una reparacion';
            selectName = 'RepairServices';
            break;
        case "Reparaciones Impilcadas":
            data = await fetch(getEndpoint('Reparaciones'), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.description);
            })
            labelText = 'Selecciona una reparacion';
            selectName = 'RepairServices';
            break;
        case "Estancias":
            valid = false;
            labelText = 'Selecciona una estancia';
            selectName = 'PlaneStay';
            break;
        case "Clientes con naves":
            data = await fetch(getEndpoint('Clientes'), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.name);
            })
            labelText = 'Selecciona un cliente con nave';
            selectName = 'Clients';
            break;
        case "Aeropuerto":
            data = await fetch(getEndpoint('Aeropuertos'), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.name);
            })
            labelText = 'Selecciona un aeropuerto';
            selectName = 'Airports';
            break;
        case "Brindado en: Aeropuertos":
            data = await fetch(getEndpoint('Aeropuertos'), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.name);
            })
            labelText = 'Selecciona un aeropuerto';
            selectName = 'Airports';
            break;
        case "Naves":
            data = await fetch(getEndpoint(entry), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.planePlate);
            })
            labelText = 'Selecciona una nave';
            selectName = 'Airplanes';
            break;
        case "Brindado a":
            data = await fetch(getEndpoint('Naves'), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.planePlate);
            })
            labelText = 'Selecciona una nave';
            selectName = 'Airplanes';
            break;
        case "Dueño":
            data = await fetch(getEndpoint('Clientes'), {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }).then(res => res.json())
            console.log(data);
            data.forEach((element: any) => {
                names.push(element.name);
            })
            labelText = 'Selecciona un cliente';
            selectName = 'Clients';
            break;
        default:
            names = [];
            labelText = '';
            selectName = '';
            valid = false;
            console.log('Invalid');
            break;
    }
    if (valid) {
        const filterContainer = document.getElementById('filterTable');
        if (filterContainer) {
            const selectElement = document.createElement('select');
            selectElement.className = "border-2";
            selectElement.name = selectName;
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