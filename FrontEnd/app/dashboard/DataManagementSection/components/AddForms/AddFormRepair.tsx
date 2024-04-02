import { AddFormProps } from "../AddForm";
import { useState, useEffect } from "react";
import { Instalacion } from "@/app/utils/types";
import genericFetch from "@/app/utils/genericFetch";
import { getEndpoint } from "@/app/utils/EntityConfigs";
import AddFormBase from "./AddFormBase";

export default function AddFormRepair(props: AddFormProps) {
    const [facilities, setFacilities] = useState<Instalacion[]>([]);

    async function getAirports() {
        const data = await genericFetch(getEndpoint("Instalaciones"));
        console.log("useEffect data: ", data);

        setFacilities(data);
        console.log("useEffect repair: ", facilities);
    }

    //(TODO) añadir fetch pa los tipos

    useEffect(() => {
        getAirports();
    }, []);

    return (
        <AddFormBase
            type="Reparaciones"
            options={[
                facilities.map((facility) => {
                    console.log(facility);
                    return { value: facility.id, name: facility.name };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}