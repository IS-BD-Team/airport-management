"use client";

import { useSearchParams } from "next/navigation";
import CustomTable from "./components/CustomTable";
import AddForm from "./components/AddForm";
import { useState, useEffect } from "react";
import { FaRegArrowAltCircleRight } from "react-icons/fa";
import { FaRegArrowAltCircleDown } from "react-icons/fa";
import { getTableWidths, getEndpoint } from "@/app/utils/EntityConfigs";
import { revalidateServerTag } from "@/app/utils/revalidate";
import { Instance } from "@/app/utils/types";
import { getRelations } from "@/app/utils/EntityConfigs";
import { getFilters } from "@/app/utils/filters";


export default function DataManagement() {
    const [toggleForm, setToogleForm] = useState(false);
    const [data, setData] = useState<Instance[] | null>(null);
    const [toogleFilters, setFilters] = useState(false);
    const [refetch, setRefetch] = useState(true);
    const [isLoading, setIsLoading] = useState(false);

    const searchParams = useSearchParams();
    const entity = searchParams.get("entity");
    
    const getEntitys = async (entity: string) => {
        try {
            const response = await fetch(
                getEndpoint(entity),
                {
                    method: "GET",
                    headers: {
                        Authorization:
                            "Bearer " + localStorage.getItem("token"),
                    },
                    // next: { tags: ["Airports"] },
                }
            );
            //revalidateServerTag("Airports");
            return response.json();
        } catch (err) {
            console.log(err);
        }
    };

    const getEntitysData = async (entity: string | null) => {
        if (entity == null) return;

        const response = await getEntitys(entity);
        console.log("response:" ,response);
      
        setData(response);
        console.log(data);
    };

    useEffect(() => {
        setIsLoading(true);
        getEntitysData(entity);
    }, [refetch]);
    
    useEffect(() => {
        console.log('Entity changed');
        setFilters(false);        
    },[entity])

    useEffect(() => {
        setIsLoading(false);
    }, [data]);

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
                            <div className="overflow-hidden">
                                <select
                                    name="filtersSelect"
                                    id="filtersSelect"
                                    className="float-right mx-1
                                border-2"
                                onChange={getFilters}
                                >                                   
                                    <option value="">&nbsp;</option>
                                    {getRelations(entity).map((relation, item) => (
                                        <option key={item} value={relation.name}>
                                            {relation.name}
                                        </option>
                                    ))}                                    
                                </select>
                                <label
                                    htmlFor="filtersSelect"
                                    className="float-right"
                                >
                                    Select a filter
                                </label>
                            </div>
                            <div id="filterTable">

                            </div>
                            <button className="bg-gray-200 px-3 py-1 rounded-md">Apply</button>
                        </div>
                    )}
                </fieldset>
                {isLoading && (
                    <h2 className="text-2xl font-bold">Loading...</h2>
                )}
                {!isLoading && (
                    <section>
                        {data != null && (
                            <CustomTable
                                entity={entity}
                                data={data}
                                columnWidths={getTableWidths(entity)}
                                handleOnClickDeleteButton={() => {
                                    setRefetch(!refetch);
                                }}
                            />
                        )}
                        {data == null && (
                            <h2 className="text-2xl font-bold">No hay datos</h2>
                        )}
                    </section>
                )}
            </div>
        );
    }
}
