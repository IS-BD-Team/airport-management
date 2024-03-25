import { Instance } from "@/app/utils/types";
import Link from "next/link";
import Image from "next/image";
import ojo from "@/public/ojo.png";
import editar from "@/public/editar.png";
import eliminar from "@/public/eliminar.png";
import Sort from "@/app/utils/sort";
import { useState } from "react";
import { useRouter } from "next/navigation";

type CustomTableProps = {
    entity: string;
    data: Instance[];
    columnWidths: string[];
    handleOnClickDeleteButton: () => void;
}

export default function CustomTable(prop: CustomTableProps) {
    console.log("inside CustomTable");
    console.log(prop.data);
    const [props, SetProps] = useState(prop);
    const router = useRouter();
    const deleteInstance = async (id: string) => {

        try {
            const response = await fetch(
                `http://localhost:5258/Airports/${id}`,
                {
                    method: "DELETE",
                    headers: {
                        Authorization:
                            "Bearer " + localStorage.getItem("token"),
                    },
                }
            );
            console.log(response);
            //router.push('/dashboard/DataManagementSection')
            // return response.json();
        } catch (err) {
            console.log(err);
        }
    }

    return (
        <table className="w-full">
            <thead className="border-b-[2px] border-solid border-[#e3e5ec] w-full" style={{ backgroundColor: "#fff !important" }}>
                <tr>
                    {props.data.length>0&& Object.keys(props.data[0]).map((item, index) => {
                        return <th style={{ width: props.columnWidths[index] }}
                            className="text-left p-[1vw] cursor-pointer" key={index}
                            onClick={() =>{
                                SetProps({
                                    ...props,
                                    data: Sort(props.data as any, item),
                                })
                            }}>
                            {item}
                        </th>;
                    })}
                    <th>Opciones</th>
                </tr>
            </thead>
            <tbody>
                {props.data.length>0&& props.data.map((row, i) => {
                    return (
                        <tr key={i} className="h-[4vw]">
                            {Object.values(row).map((val, j) => {
                                return <td key={i + " " + j} className="p-[1vw]">{val}</td>;
                            })}
                            <td className="text-center">
                                <Link href={`/dashboard/InstanceViewSection?id=${Object.values(row)[0]}&entity=${props.entity}`}>
                                    <button className="hover:bg-[#005b7f] rounded-lg mr-2"><Image src={ojo} alt="ver_icon" className="hover:invert p-2 h-10 w-10"></Image></button>
                                </Link>
                                <button className="hover:bg-red-600 rounded-lg"><Image src={eliminar} alt="eliminar_icon" className="hover:invert p-2 h-10 w-10"
                                    onClick={() => deleteInstance(Object.values(row)[0])}></Image></button>
                            </td>
                        </tr>
                    );
                })}
            </tbody>
        </table>
    );
}
