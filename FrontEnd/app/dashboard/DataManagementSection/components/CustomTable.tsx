import { Aeropuerto, Instalacion, Cliente, Servicio, TestingType } from "@/app/utils/types";
import Link from "next/link";
import Image from "next/image";
import ojo from "@/public/ojo.png";
import editar from "@/public/editar.png";
import eliminar from "@/public/eliminar.png";

type CustomTableProps = {   
    data: Aeropuerto[] | Instalacion[] | Cliente[] | Servicio[] | TestingType[];
    columnWidths: string[];
}

export default function CustomTable(props: CustomTableProps) {
    console.log("inside CustomTable");
    console.log(props.data);
    return (
        <table className="w-full">
            <thead className="border-b-[2px] border-solid border-[#e3e5ec] w-full" style={{backgroundColor: "#fff !important"}}>
                <tr>
                    {Object.keys(props.data[0]).map((item, index) => {
                        return <th style={{width: props.columnWidths[index]}} className="text-left p-[1vw] " key={index}>{item}</th>;
                    })}
                    <th>Opciones</th>               
                </tr>
            </thead>
            <tbody>
                {props.data.map((row, i) => {
                    return (
                        <tr key={i} className="h-[4vw]">
                            {Object.values(row).map((val, j) => {
                                return <td key={i + " " + j} className="p-[1vw]">{val}</td>;
                            })}
                            <td className="text-center">
                                <Link href={"/dashboard/InstanceViewSection?id=" + Object.values(row)[0]}>
                                <button className="hover:bg-[#005b7f] rounded-lg mr-2"><Image src={ojo} alt="ver_icon" className="hover:invert p-2 h-10 w-10"></Image></button>
                                </Link>
                                <button className="hover:bg-red-600 rounded-lg"><Image src={eliminar} alt="eliminar_icon" className="hover:invert p-2 h-10 w-10" ></Image></button>
                            </td>
                        </tr>
                    );
                })}
            </tbody>
        </table>
    );
}
