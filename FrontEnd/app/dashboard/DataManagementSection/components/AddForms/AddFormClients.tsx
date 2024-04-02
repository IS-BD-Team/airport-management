import { AddFormProps } from "../AddForm";
import AddFormBase from "./AddFormBase";
import { countries } from "@/app/utils/countries";

export default function AddFormClients(props: AddFormProps) {
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
