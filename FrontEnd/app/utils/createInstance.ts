import { getEndpoint } from "./EntityConfigs";

export default async function createInstance(event: React.FormEvent<HTMLFormElement>, entity: string) {
    event.preventDefault();
    const name = event.currentTarget["Nombre"].value;
    const address = event.currentTarget["Ubicación"].value;
    const geographicLocation = event.currentTarget["Posición"].value;

    try {
        const response = await fetch(getEndpoint(entity), {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + localStorage.getItem("token"),
            },
            body: JSON.stringify({ name, address, geographicLocation }),
        });
        console.log(response);
        window.location.reload();
        //router.push(`/dashboard/DataManagementSection?entity=${props.type}`);
        // return response.json();
    } catch (err) {
        console.log(err);
    }
}