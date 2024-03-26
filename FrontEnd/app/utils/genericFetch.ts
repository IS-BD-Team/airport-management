export default async function genericFetch(url: string) {
    try {
        const response = await fetch(url, {
            method: "GET",
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token"),
            },
            // next: { tags: ["Airports"] },
        });
        //console.log(response);
        //revalidateServerTag("Airports");
        return response.json();
    } catch (err) {
        console.log(err);
    }
}
