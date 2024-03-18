"use client";

import { useSearchParams } from "next/navigation";
import CustomTable from "./components/CustomTable";
import AddForm from "./components/AddForm";
import { Instance } from "@/app/utils/types";
import { useState } from "react";

export default function DataManagement() {

    const getAirportsData = async () => {
        try {
            const response = await fetch('http://localhost:5258/Airports/airports', {
                method: 'GET',
                headers: {
                    'Authorization':''
                }
            })

            return await response.json();
        }
        catch (err) {
            console.log(err)
        }
    }
    //const data = getAirportsData();
    const data = [
        {
        "id": "1",
        "nombre": "A",
        "ubicacion": "a",
        "posicionGeografica": "a"
    },
]
    const [toggleForm, setToogleForm] = useState(false);
    /*const data = [{
        id:"1",
        nombre: "A",
        ubicacion: "a",
        posicionGeografica: "a",    
    }];*/
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
                    <button className="bg-gray-200 px-3 py-1 rounded-md" onClick={()=>setToogleForm(true)}>
                        + Add
                    </button>
                </header>

                {toggleForm && <AddForm type={entity} handleToggleEvent={()=>{
                    setToogleForm(false)
                    }}/>}

                <fieldset>
                    <legend>Filtros</legend>
                </fieldset>
                <section>
                    {data != null && <CustomTable
                        data={data}
                        columnWidths={["20%", "10%", "10%", "50%", "10%"]}
                    />}
                    {data == null && <h2 className="text-2xl font-bold">
                        No hay datos
                    </h2>}
                </section>
            </div>
        );
    }
}

