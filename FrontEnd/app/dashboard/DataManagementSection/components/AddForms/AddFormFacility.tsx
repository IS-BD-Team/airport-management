import { AddFormProps } from "../AddForm";
import { useState, useEffect } from "react";
import { Aeropuerto } from "@/app/utils/types";
import genericFetch from "@/app/utils/genericFetch";
import { getEndpoint } from "@/app/utils/EntityConfigs";
import AddFormBase from "./AddFormBase";

export default function AddFormFacility(props: AddFormProps) {
    const [airports, setAirports] = useState<Aeropuerto[]>([]);

    async function getAirports() {
        const data = await genericFetch(getEndpoint("Aeropuertos"));
        console.log("useEffect data: ", data);

        setAirports(data);
        console.log("useEffect airports: ", airports);
    }

    useEffect(() => {
        getAirports();
    }, []);

    return (
        <AddFormBase
            type="Instalaciones"
            options={[
                airports.map((airport) => {
                    return { value: airport.id, name: airport.name };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}
