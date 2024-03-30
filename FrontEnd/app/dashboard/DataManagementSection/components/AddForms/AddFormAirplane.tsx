import { AddFormProps } from "../AddForm";
import { useState, useEffect } from "react";
import { Cliente } from "@/app/utils/types";
import genericFetch from "@/app/utils/genericFetch";
import { getEndpoint } from "@/app/utils/EntityConfigs";
import AddFormBase from "./AddFormBase";

export default function AddFormAirplane(props: AddFormProps) {
    const [clients, setClients] = useState<Cliente[]>([]);

    async function getClients() {
        const data = await genericFetch(getEndpoint("Clientes"));
        console.log("useEffect data: ", data);

        setClients(data);
        console.log("useEffect Airplane: ", clients);
    }

    //(TODO) añadir fetch pa los Clasificaciones

    useEffect(() => {
        getClients();
    }, []);

    return (
        <AddFormBase
            type="Naves"
            options={[
                clients.map((client) => {
                    return { value: client.ci, name: client.name };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}