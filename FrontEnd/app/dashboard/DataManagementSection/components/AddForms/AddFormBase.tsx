import { AddFormProps } from "../AddForm";
import { useRouter } from "next/navigation";
import createInstance from "@/app/utils/createInstance";
import { getFormConfigs } from "@/app/utils/EntityConfigs";
import Image from "next/image";
import AddFormInput from "../AddFormInput";

export default function AddFormBase(props: AddFormProps) {
    console.log("base: ", props.options);
    const router = useRouter();
    const formConfig = getFormConfigs(props.type);

    return (
        <form
            action="none"
            className="mt-6 relative rounded-lg px-[1%] py-[2%] flex flex-col w-[33%] m-auto shadow-[0px_5px_10px_rgba(0,0,0,0.3)]"
            onSubmit={(e) => createInstance(e, props.type)}
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