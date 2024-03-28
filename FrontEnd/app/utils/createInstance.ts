import { getEndpoint } from "./EntityConfigs";

export default async function createInstance(
    event: React.FormEvent<HTMLFormElement>,
    entity: string
) {
    event.preventDefault();
    var name,
        address,
        geographicLocation,
        airportId,
        location,
        type,
        description,
        price,
        facilityId,
        ci,
        country,
        clientType,
        hasNave,
        classification,
        clientId,
        maxLoad,
        passengersCapacity,
        crewMembers;
    var body = {};

    switch (entity) {
        case "Administradores":
            break;
        case "Aeropuertos":
            name = event.currentTarget["name"].value;
            address = event.currentTarget["adress"].value;
            geographicLocation = event.currentTarget["geographicLocation"].value;
            body = { name, address, geographicLocation };
            break;
        case "Instalaciones":
            airportId = event.currentTarget["adress"];
            name = event.currentTarget["name"];
            location = event.currentTarget["location"];
            type = event.currentTarget["type"];
            body = { name, type, location, airportId };
        case "Servicios":
            facilityId = event.currentTarget["facilityId"];
            description = event.currentTarget["description"];
            price = event.currentTarget["price"];
            body = { facilityId, description, price };
        case "Reparaciones":
            facilityId = event.currentTarget["facilityId"];
            description = event.currentTarget["description"];
            price = event.currentTarget["price"];
            type = event.currentTarget["type"];
            body = { facilityId, description, price, type };
        case "Clientes":
            name = event.currentTarget["name"];
            ci = event.currentTarget["ci"];
            country = event.currentTarget["country"];
            clientType = event.currentTarget["clientType"];
            hasNave = event.currentTarget["hasNave"];
            body = { name, ci, country, clientType };
        case "Naves":
            classification = event.currentTarget["classification"];
            clientId = event.currentTarget["clasclientIdsification"];
            maxLoad = event.currentTarget["maxLoad"];
            passengersCapacity = event.currentTarget["passengersCapacity"];
            crewMembers = event.currentTarget["crewMembers"];
            body = {
                classification,
                clientId,
                maxLoad,
                passengersCapacity,
                crewMembers,
            };
        case "Estancias":

        case "ReparacionesNaves":

        default:
    }

    console.log(`new ${entity}`, body);

    try {
        const response = await fetch(getEndpoint(entity), {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + localStorage.getItem("token"),
            },
            body: JSON.stringify(body),
        });
        console.log(response);
        window.location.reload();
        //router.push(`/dashboard/DataManagementSection?entity=${props.type}`);
        // return response.json();
    } catch (err) {
        console.log(err);
    }
}
