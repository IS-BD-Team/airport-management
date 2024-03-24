"use client";

import { useSearchParams } from "next/navigation";
import CustomTable from "./components/CustomTable";
import AddForm from "./components/AddForm";
import { useState, useEffect } from "react";

export default function DataManagement() {
    const [toggleForm, setToogleForm] = useState(false);
    const [data, setData] = useState(null);
    const [refetch, setRefetch] = useState(true);

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
            //console.log(response);
            return response.json();
        } catch (err) {
            console.log(err);
        }
    };

    const getAirportsData = async () => {
        const response = await getAirports();
        /*console.log("setData")
        console.log(response);*/
        setData(response.airports);
    };

    useEffect(() => {
            getAirportsData();
            setRefetch(false);
    }, [refetch]);

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
                        handleOnClickAddButton={() => {
                            setRefetch(!refetch);
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
                            columnWidths={["20%", "10%", "60%", "10%"]}
                            handleOnClickDeleteButton={() => {
                                setRefetch(!refetch);
                            }}
                        />
                    )}
                    {data == null && (
                        <h2 className="text-2xl font-bold">No hay datos</h2>
                    )}
                </section>
            </div>
        );
    }
}
