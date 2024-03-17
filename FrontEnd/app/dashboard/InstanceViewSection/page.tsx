"use client";

import { Instance } from "../../utils/types";
import havana from "../../../public/HavanAirport.jpg";
import Image from "next/image";
import { useSearchParams } from "next/navigation";

export default function InstanceViewSection() {
    const searchParams = useSearchParams();
    const entity = searchParams.get("entity");
    const id = searchParams.get("id");

    {
        /*pedir a la bd */
    }
    const instance: Instance = {
        id: "1",
        nombre: "Aeropuerto José Martí",
        direccion: "Boyeros, Herradura",
        posicionGeografica: "222.1w 212.2n",
    };

    return (
        <div>
            <header className="w-full h-[10vw] bg-gray-700 text-white text-2xl text-center relative">
                <Image
                    src={havana}
                    alt=""
                    className="w-full h-full object-cover absolute z-0"
                />
                <h1 className="h-full flex items-center justify-around z-10 relative bg-slate-900 bg-opacity-40">
                    {instance.nombre}
                </h1>
            </header>

            <main className="m-5">
                {Object.entries(instance).map((value, index) => {
                    if(index > 1){
                    return (
                        <section key={index}>
                            <h2 className="text-2xl capitalize border-b-[2px] border-solid border-[#e3e5ec] mb-5">
                                {value[0]}
                            </h2>
                            <p className="mb-3">{value[1]}</p>
                        </section>
                    );
                    }
                })}
            </main>
        </div>
    );
}
