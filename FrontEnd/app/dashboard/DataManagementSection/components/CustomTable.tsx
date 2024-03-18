import { Aeropuerto, Instalacion, Cliente, Servicio, TestingType } from "@/app/utils/types";
import Link from "next/link";

type CustomTableProps = {   
    data: Aeropuerto[] | Instalacion[] | Cliente[] | Servicio[] | TestingType[];
    columnWidths: string[];
}

export default function CustomTable(props: CustomTableProps) {
    return (
        <table className="w-full">
            <thead className="border-b-[2px] border-solid border-[#e3e5ec] w-full" style={{backgroundColor: "#fff !important"}}>
                <tr>
                    {Object.keys(props.data[0]).map((item, index) => {
                        return <th style={{width: props.columnWidths[index]}} className="text-left p-[1vw] " key={index}>{item}</th>;
                    })}
                </tr>
            </thead>
            <tbody>
                {props.data.map((row, i) => {
                    return (
                        <tr key={i} className="h-[4vw]">
                            {Object.values(row).map((val, j) => {
                                return <td key={i + " " + j} className="p-[1vw]">{val}</td>;
                            })}
                            
                        </tr>
                    );
                })}
            </tbody>
        </table>
    );
}
