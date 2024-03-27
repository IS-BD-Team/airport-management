import Image from "next/image";
import { getEndpoint, getFormConfigs } from "../../../utils/EntityConfigs";
import AddFormInput from "./AddFormInput";
import { useRouter } from "next/navigation";
import resolveGenericFetch from "@/app/utils/genericFetch";
import { useEffect, useState } from "react";
import genericFetch from "@/app/utils/genericFetch";
import { Aeropuerto, Cliente, Instalacion, Nave, ReparacionNave } from "@/app/utils/types";
import { countries } from "@/app/utils/countries";

type AddFormProps = {
    type: string;
    options?: { value: number | string; name: number | string }[][];
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
            const response = await fetch(getEndpoint(props.type), {
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
                return (
                    <AddFormInput
                        data={value}
                        key={index}
                        options={
                            value.type == "select" && props.options != undefined
                                ? props.options[index - 2]
                                : []
                        }
                    />
                );
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

function AddFormFacility(props: AddFormProps) {
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

function AddFormService(props: AddFormProps) {
    const [facilities, setFacilities] = useState<Instalacion[]>([]);

    async function getAirports() {
        const data = await genericFetch(getEndpoint("Instalaciones"));
        console.log("useEffect data: ", data);

        setFacilities(data);
        console.log("useEffect airports: ", facilities);
    }

    useEffect(() => {
        getAirports();
    }, []);

    return (
        <AddFormBase
            type="Servicios"
            options={[
                facilities.map((facility) => {
                    return { value: facility.id, name: facility.name };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}

function AddFormRepair(props: AddFormProps) {
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
                    return { value: facility.id, name: facility.name };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}

function AddFormClients(props: AddFormProps) {
    //const [facilities, setFacilities] = useState<Aeropuerto[]>([]);

    /*async function getAirports() {
        const data = await genericFetch(getEndpoint("Instalaciones"));
        console.log("useEffect data: ", data);

        setFacilities(data);
        console.log("useEffect repair: ", facilities);
    }*/

    //(TODO) añadir fetch pa los tipos
    /*
    useEffect(() => {
        getAirports();
    }, []);*/

    return (
        <AddFormBase
            type="Reparaciones"
            options={[
                countries.map((country) => {
                    return { value: country, name: country };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}

function AddFormAirplane(props: AddFormProps) {
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
            options={[
                { values: "A", name: "A" },
                { values: "B", name: "B" },
            ]}
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

function AddFormStays(props: AddFormProps) {
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
                    return { value: airplane.id, name: airplane.id };
                }),
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}

function AddFormPlaneRepair(props: AddFormProps) {
    const [airplanes, setAirplanes] = useState<Nave[]>([]);
    const [repairs, setRepairs] = useState<ReparacionNave[]>([]);

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
                    return { value: airplane.id, name: airplane.id };
                }),
                repairs.map((repair) => {
                    return { value: repair.codigo, name: repair.codigo };
                }),
            ]}
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
        case "Reparaciones":
            return <AddFormRepair {...props} />;
        case "Clientes":
            return <AddFormClients {...props} />;
        case "Naves":
            return <AddFormAirplane {...props} />;
        case "Estancias":
            return <AddFormStays {...props} />;
        case "Reparaciones a Naves":
            return <AddFormPlaneRepair {...props} />;
        default:
            return <AddFormBase {...props} />;
    }
}
