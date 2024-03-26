import Image from "next/image";
import { getFormConfigs } from "../../../utils/EntityConfigs";
import AddFormInput from "./AddFormInput";
import { useRouter } from "next/navigation";

type AddFormProps = {
    type: string;
    handleToggleEvent: () => void;
    handleOnClickAddButton: () => void;
};
export default function AddForm(props: AddFormProps) {
    console.log(props.type);
    const router = useRouter();
    const formConfig = getFormConfigs(props.type);

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
                return <AddFormInput data={value} key={index} />;
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
