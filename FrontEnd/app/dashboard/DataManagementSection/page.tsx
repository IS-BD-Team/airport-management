"use client";

import { useSearchParams } from "next/navigation";
import CustomTable from "./components/CustomTable";
import AddForm from "./components/AddForm";
import { useState, useEffect } from "react";
import { FaRegArrowAltCircleRight } from "react-icons/fa";
import { FaRegArrowAltCircleDown } from "react-icons/fa";
import { getTableWdths } from "@/app/utils/EntityConfigs";

export default function DataManagement() {
    const [toggleForm, setToogleForm] = useState(false);
    const [data, setData] = useState(null);
    const [toogleFilters, setFilters] = useState(false);
    const [refetch, setRefetch] = useState(true);

    const searchParams = useSearchParams();
    const entity = searchParams.get("entity");

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
        console.log(response);
        /*console.log("setData")
        console.log(response);*/
        setData(response.airports);
        console.log(data);
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
                            setTimeout(() => setToogleForm(false), 1000);
                        }}
                    />
                )}

                <fieldset id="filters" className="my-4">
                    <div className="flex flex-row gap-1 py-[auto] transition-all hover:gap-2 w-fit">
                        <h2 className="text-2xl cursor-pointer">Filters</h2>
                        <button onClick={() => setFilters(!toogleFilters)}>
                            {!toogleFilters && <FaRegArrowAltCircleRight />}
                            {toogleFilters && <FaRegArrowAltCircleDown />}
                        </button>
                    </div>
                    {toogleFilters && (
                        <div>
                            <div>
                                <select
                                    name="filtersSelect"
                                    id="filtersSelect"
                                    className="float-right mx-1
                                border-2"
                                >
                                    <option value="">&nbsp;</option>
                                    <option value="1">Option 1</option>
                                    <option value="2">Option 2</option>
                                    <option value="3">Option 3</option>
                                    <option value="4">Option 4</option>
                                    <option value="5">Option 5</option>
                                </select>
                                <label
                                    htmlFor="filtersSelect"
                                    className="float-right"
                                >
                                    Select a filter
                                </label>
                            </div>
                            <div id="filterTable"></div>
                        </div>
                    )}
                </fieldset>
                <section>
                    {data != null && (
                        <CustomTable
                            data={data}
                            columnWidths={getTableWdths(entity)}
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
