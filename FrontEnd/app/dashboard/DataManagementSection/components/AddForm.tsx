import Image from "next/image";
import { getEndpoints, getFormConfigs } from "../../../utils/EntityConfigs";
import AddFormInput from "./AddFormInput";
import { useRouter } from "next/navigation";
import resolveGenericFetch from "@/app/utils/genericFetch";
import { useEffect, useState } from "react";
import genericFetch from "@/app/utils/genericFetch";
import { Aeropuerto } from "@/app/utils/types";

type AddFormProps = {
    type: string;
    options?: [{ value: number | string; name: number | string }[]];
    handleToggleEvent: () => void;
    handleOnClickAddButton: () => void;
};
function AddFormBase(props: AddFormProps) {
    console.log("base: ", props.options);
    const router = useRouter();
    const formConfig = getFormConfigs(props.type);

    async function createInstance(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        const name = event.currentTarget["Nombre"].value;
        const address = event.currentTarget["Ubicación"].value;
        const geographicLocation = event.currentTarget["Posición"].value;

        try {
            const response = await fetch(getEndpoints(props.type), {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
                body: JSON.stringify({ name, address, geographicLocation }),
            });
            console.log(response);
            //router.push(`/dashboard/DataManagementSection?entity=${props.type}`);
            // return response.json();
        } catch (err) {
            console.log(err);
        }
    }

    return (
        <form
            action="none"
            className="mt-6 relative rounded-lg px-[1%] py-[2%] flex flex-col w-[33%] m-auto shadow-[0px_5px_10px_rgba(0,0,0,0.3)]"
            onSubmit={createInstance}
        >
            <button
                className="absolute right-5 text-[#e3e5ec] hover:text-black"
                onClick={props.handleToggleEvent}
            >
                X
            </button>
            <caption className="font-bold flex flex-row justify-center mb-6">
                {formConfig.caption}{" "}
                <Image
                    alt="aeropuertos_icon"
                    className="ml-6 h-6 w-6"
                    src={formConfig.icon}
                />
            </caption>
            {formConfig.inputs.map((value, index) => {
                return <AddFormInput data={value} key={index} options={value.type == "select" && props.options != undefined ?  props.options[index-2]: []}/>;
            })}
            <button
                type="submit"
                className="bg-[#005b7f] text-white rounded-lg p-[2%] mt-6 w-[30%] self-end"
                onClick={props.handleOnClickAddButton}
            >
                Añadir
            </button>
        </form>
    );
}


export function AddFormFacility(props: AddFormProps) {
    const [airports, setAirports] = useState<Aeropuerto[]>([]);

    async function getAirports() {
        const data = await genericFetch(getEndpoints("Aeropuertos"));
        console.log("useEffect data: ", data);

        setAirports(data.airports);
        console.log("useEffect airports: ", airports);
    }

    useEffect(() => {
        getAirports();
    }, []);

    return(
        <AddFormBase 
            type="Instalaciones"
            options={[airports.map((airport) => {return {value: airport.id, name: airport.name}})]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}

export function AddFormService(props: AddFormProps) {
    const [facilities, setFacilities] = useState<Aeropuerto[]>([]);

    async function getAirports() {
        const data = await genericFetch(getEndpoints("Instalaciones"));
        console.log("useEffect data: ", data);

        setFacilities(data);
        console.log("useEffect airports: ", facilities);
    }

    useEffect(() => {
        getAirports();
    }, []);

    return(
        <AddFormBase 
            type="Instalaciones"
            options={[facilities.map((facility) => {return {value: facility.id, name: facility.name}})]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}

export default function AddForm(props: AddFormProps) {
    switch (props.type) {
        case "Instalaciones":
            return <AddFormFacility {...props} />;
        case "Servicios":
            return <AddFormService {...props} />;
        default:
            return <AddFormBase {...props} />;
    }
}