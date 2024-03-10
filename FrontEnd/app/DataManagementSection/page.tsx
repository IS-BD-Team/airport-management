import { TestingType } from "../utils/types";
import CustomTable from "./components/CustomTable";

type DataManagementProps = {
    section: string;
};



export default function DataManagement(props: DataManagementProps) {
    const data = [
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
    ]

    return (
        <div>
            <header className="flex justify-between">
                <h2 className="text-2xl font-bold">
                    {/*props.section*/}
                    Secciones
                </h2>
                <button className="bg-gray-200 px-3 py-1 rounded-md">
                    + Add
                </button>
            </header>

            <fieldset>
                <legend>Filtros</legend>
            </fieldset>
            <section>
                <CustomTable data={data} columnWidths={["20%", "10%", "10%", "50%", "10%"]}/>
            </section>
        </div>
    );
}
