import Image from "next/image";
import { allFormConfigs } from "../../../utils/formConfigs";
import AddFormInput from "./AddFormInput";
import { useRouter } from "next/navigation";

type AddFormProps = {
    type: string;
    handleToggleEvent: () => void;
};
export default function AddForm(props: AddFormProps) {
    console.log(props.type);
    const router = useRouter();
    let formConfig;
    switch (props.type) {
        case "Administradores":
            formConfig = allFormConfigs.Administradores;
            break;
        case "Aeropuertos":
            formConfig = allFormConfigs.Aeropuertos;
            break;
        case "Instalaciones":
            formConfig = allFormConfigs.Instalaciones;
            break;
        case "Servicios":
            formConfig = allFormConfigs.Servicios;
            break;
        case "Reparciones":
            formConfig = allFormConfigs.Reparciones;
            break;
        case "Clientes":
            formConfig = allFormConfigs.Clientes;
            break;
        case "Naves":
            formConfig = allFormConfigs.Naves;
            break;
        default:
            formConfig = allFormConfigs.default;
    }

    async function createInstance(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        const name = event.currentTarget["Nombre"].value;
        const address = event.currentTarget["Ubicación"].value;
        const geographicLocation = event.currentTarget["Posición"].value;

        try {
            const response = await fetch("http://localhost:5258/airports", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
                body: JSON.stringify({ name, address, geographicLocation }),
            });
            console.log(response);
            router.push('/dashboard/DataManagementSection')
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
            {formConfig.inputs.map((value, index) => {return(<AddFormInput data={value} key={index}/>)})}
            <button
                type="submit"
                className="bg-[#005b7f] text-white rounded-lg p-[2%] mt-6 w-[30%] self-end"
            >
                Añadir
            </button>
        </form>
    );
}