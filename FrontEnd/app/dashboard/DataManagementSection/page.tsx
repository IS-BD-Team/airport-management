"use client";

import { useSearchParams } from "next/navigation";
import CustomTable from "./components/CustomTable";

export default function DataManagement() {
    
    const data = [
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
        {nombre: "Emrys", grupo:"C311", num:"NaN", description:"a", fecha: "12/12/12"},
    ]

    const searchParams = useSearchParams();
    const entity = searchParams.get("entity");

    {
        /*pedir a la bd */
    }
    
    return (
        <div className="m-5">
            <header className="flex justify-between">
                <h2 className="text-2xl font-bold">
                    {entity}
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
