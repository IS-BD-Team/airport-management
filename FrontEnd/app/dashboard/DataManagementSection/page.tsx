"use client";

import { useSearchParams } from "next/navigation";
import CustomTable from "./components/CustomTable";
import AddForm from "./components/AddForm";
import { Instance } from "@/app/utils/types";
import { useEffect, useState } from "react";
import { get } from "http";

export default function DataManagement() {
    const [toggleForm, setToogleForm] = useState(false);
    const [data, setData] = useState(null);

    const getAirports = async () => {
        try {
            const response = await fetch(
                "http://localhost:5258/Airports/airports",
                {
                    method: "GET",
                    headers: {
                        Authorization:
                            "Bearer " + localStorage.getItem("token"),
                    },
                }
            );

            return response.json();
        } catch (err) {
            console.log(err);
        }
    };

    const getAirportsData = async () => {
        const response = await getAirports();
        console.log(response);
        setData(response);
    };

    useEffect(() => {
        getAirportsData();
    }, []);

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
                <header className="flex justify-between border-b-[1px] border-[#666] pb-1 border-solid">
                    <h2 className="text-2xl font-bold">{entity}</h2>
                    <button
                        className="bg-gray-200 px-3 py-1 rounded-md"
                        onClick={() => setToogleForm(true)}
                    >
                        + Add
                    </button>
                </header>

                {toggleForm && (
                    <AddForm
                        type={entity}
                        handleToggleEvent={() => {
                            setToogleForm(false);
                        }}
                    />
                )}

                <fieldset>
                    <legend>Filtros</legend>
                </fieldset>
                <section>
                    {data != null && (
                        <CustomTable
                            data={data}
                            columnWidths={["20%", "10%", "10%", "50%", "10%"]}
                        />
                    )}
                    {data == null && (
                        <h2 className="text-2xl font-bold text-center">No hay datos</h2>
                    )}
                </section>
            </div>
        );
    }
}
