import { AddFormProps } from "../AddForm";
import AddFormBase from "./AddFormBase";
import { countries } from "@/app/utils/countries";

export default function AddFormClients(props: AddFormProps) {
    return (
        <AddFormBase
            type="Clientes"
            options={[
                countries.map((country) => {
                    return { value: country, name: country };
                }),
                [
                    { value: "true", name: "true" },
                    { value: "false", name: "false" },
                ],
            ]}
            handleOnClickAddButton={props.handleOnClickAddButton}
            handleToggleEvent={props.handleToggleEvent}
        />
    );
}
