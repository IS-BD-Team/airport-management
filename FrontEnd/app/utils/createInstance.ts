import { getEndpoint } from "./EntityConfigs";

export default async function createInstance(
    event: React.FormEvent<HTMLFormElement>,
    entity: string
) {
    event.preventDefault();

    const form = new FormData(event.currentTarget);

    try {
        const response = await fetch(getEndpoint(entity), {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: "Bearer " + localStorage.getItem("token"),
            },
            body: JSON.stringify(Object.fromEntries(form.entries())),
        });
        console.log(response);
        window.location.reload();
        //router.push(`/dashboard/DataManagementSection?entity=${props.type}`);
        // return response.json();
    } catch (err) {
        console.log(err);
    }
}
