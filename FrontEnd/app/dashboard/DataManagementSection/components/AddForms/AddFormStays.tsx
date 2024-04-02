import { AddFormProps } from "../AddForm";
import { useState, useEffect } from "react";
import { Nave, Aeropuerto } from "@/app/utils/types";
import genericFetch from "@/app/utils/genericFetch";
import { getEndpoint } from "@/app/utils/EntityConfigs";
import AddFormBase from "./AddFormBase";

export default function AddFormStays(props: AddFormProps) {
    const [airplanes, setAirplanes] = useState<Nave[]>([]);
    const [airports, setAirports] = useState<Aeropuerto[]>([]);

    async function getAirplanes() {
        const data = await genericFetch(getEndpoint("Naves"));
        console.log("useEffect data: ", data);

        setAirplanes(data);
        console.log("useEffect Stays: ", airplanes);
    }

    async function getAirports() {
        const data = await genericFetch(getEndpoint("Aeropuertos"));
        console.log("useEffect data: ", data);

        setAirports(data);
        console.log("useEffect Stay: ", airports);
    }

    //(TODO) añadir fetch pa los Clasificaciones

    useEffect(() => {
        getAirplanes();
        getAirports();
    }, []);

    return (
        <AddFormBase
            type="Estancias"
            options={[
                airports.map((airport) => {
                    return { value: airport.id, name: airport.name };
                }),
                airplanes.map((airplane) => {
                    return { value: airplane.id, name: airplane.planePlate };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}