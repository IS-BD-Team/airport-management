import { AddFormProps } from "../AddForm";
import { useState, useEffect } from "react";
import { Nave, Reparacion } from "@/app/utils/types";
import genericFetch from "@/app/utils/genericFetch";
import { getEndpoint } from "@/app/utils/EntityConfigs";
import AddFormBase from "./AddFormBase";

export default function AddFormPlaneRepair(props: AddFormProps) {
    const [airplanes, setAirplanes] = useState<Nave[]>([]);
    const [repairs, setRepairs] = useState<Reparacion[]>([]);

    async function getAirplanes() {
        const data = await genericFetch(getEndpoint("Naves"));
        console.log("useEffect data: ", data);

        setAirplanes(data);
        console.log("useEffect Stays: ", airplanes);
    }

    async function getRepairs() {
        const data = await genericFetch(getEndpoint("Reparaciones"));
        console.log("useEffect data: ", data);

        setRepairs(data);
        console.log("useEffect PlaneRepairs: ", repairs);
    }

    //(TODO) añadir fetch pa los Clasificaciones

    useEffect(() => {
        getAirplanes();
        getRepairs();
    }, []);

    return (
        <AddFormBase
            type="Reparaciones a Naves"
            options={[
                airplanes.map((airplane) => {
                    return { value: airplane.id, name: airplane.planePlate };
                }),
                repairs.map((repair) => {
                    return { value: repair.id, name: repair.id };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}