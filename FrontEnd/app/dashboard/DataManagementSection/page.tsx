"use client";

import { useSearchParams } from "next/navigation";
import CustomTable from "./components/CustomTable";
import AddForm from "./components/AddForm";
import { useState, useEffect } from "react";
import { getTableWidths, getEndpoint } from "@/app/utils/EntityConfigs";
import { Instance } from "@/app/utils/types";
import getRelationEndpoint from "@/app/utils/getRelationEndpoint";


export default function DataManagement() {
    const [toggleForm, setToogleForm] = useState(false);
    const [data, setData] = useState<Instance[] | null>(null);
    const [toogleFilters, setFilters] = useState(false);
    const [refetch, setRefetch] = useState(true);
    const [isLoading, setIsLoading] = useState(false);

    const searchParams = useSearchParams();
    const entity = searchParams.get("entity");
    const relation = searchParams.get("relation");
    const id = searchParams.get("id");

    const getEntitys = async (entity: string) => {
        try {
            const response = await fetch(
                relation ? ("http://localhost:5258/" + getRelationEndpoint(relation ?? "", entity, id ?? "")) : getEndpoint(entity),
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
        setFilters(false);        
    },[entity])

    useEffect(() => {
        setIsLoading(false);
    }, [data]);

    const [query, setQuery] = useState(false);
    
    useEffect(() => {
        if (localStorage.getItem('query') != null) {
            console.log('filtrando');
            const resp:any = fetch(`${getEndpoint(entity as string)}${localStorage.getItem('query')}`, {
                method: "GET",
                headers: {
                    Authorization: "Bearer " + localStorage.getItem("token"),
                },
            }
            ).then(res => res.json().then(data => {
                setData(data);
            }))            
        }
    }, [query])

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
