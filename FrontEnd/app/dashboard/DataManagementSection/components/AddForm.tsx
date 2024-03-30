import AddFormBase from "./AddForms/AddFormBase";
import AddFormClients from "./AddForms/AddFormClients";
import AddFormAirplane from "./AddForms/AddFormAirplane";
import AddFormPlaneRepair from "./AddForms/AddFormPlaneRepair";
import AddFormFacility from "./AddForms/AddFormFacility";
import AddFormService from "./AddForms/AddFormService";
import AddFormRepair from "./AddForms/AddFormRepair";
import AddFormStays from "./AddForms/AddFormStays";


export type AddFormProps = {
    type: string;
    options?: { value: number | string; name: number | string }[][];
    handleToggleEvent: () => void;
    handleOnClickAddButton: () => void;
};

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
