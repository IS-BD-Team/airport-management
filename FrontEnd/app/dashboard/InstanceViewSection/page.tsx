import {Instance} from "../../utils/types"
import havana from "../../../public/HavanAirport.jpg";
import Image from "next/image";
import { useSearchParams } from 'next/navigation'

export default function InstanceViewSection(){
    const searchParams = useSearchParams();
    const entity = searchParams.get("entity");
    const id = searchParams.get("id");
    
    {/*pedir a la bd */}
    const instance = {
        nombre: "Aeropuerto José Martí",
        ubi
    }

    return(
        <div>
            <div className="w-full h-[10vw] bg-gray-700 text-white text-2xl text-center relative">
                <Image src={havana} alt="" className="w-full h-full object-cover" />   
                <h1 className="h-full flex items-center justify-around absolute top-0 ">Nombre Instancia</h1>
            </div>

            {Object.entries(instance).forEach((key,value) => {
                return(
                    <>
                        <h2>{key}</h2>
                        <p>{value}</p>
                    </>
                )
            })}
        </div>
    )
}