"use client";

import { useSearchParams } from "next/navigation";
import CustomTable from "./components/CustomTable";
import AddForm from "./components/AddForm";
import { Instance } from "@/app/utils/types";

export default function DataManagement() {
    const data = [
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
        {
            nombre: "Emrys",
            grupo: "C311",
            num: "NaN",
            description: "a",
            fecha: "12/12/12",
        },
    ];

    const searchParams = useSearchParams();
    const entity = searchParams.get("entity");

    if (entity == null) {
        return (
            <div className="m-5 relative">
                <header className="flex justify-between">
                    <h2 className="text-2xl font-bold">
                        No se proporciono una entidad!!!
                    </h2>
                </header>
            </div>
        );
        /*pedir a la bd */
    } else {
        return (
            <div className="m-5 relative">
                <header className="flex justify-between">
                    <h2 className="text-2xl font-bold">{entity}</h2>
                    <button className="bg-gray-200 px-3 py-1 rounded-md">
                        + Add
                    </button>
                </header>

                <AddForm type={entity} />

                <fieldset>
                    <legend>Filtros</legend>
                </fieldset>
                <section>
                    <CustomTable
                        data={data}
                        columnWidths={["20%", "10%", "10%", "50%", "10%"]}
                    />
                </section>
            </div>
        );
    }
}
