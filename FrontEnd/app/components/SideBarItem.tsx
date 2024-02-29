import { StaticImageData } from "next/image";
import Image from "next/image";

export type NavBarItemProps = {
    text: string;
    icon: StaticImageData;
}

export default function SideBarItem(props: NavBarItemProps){
    return (
        <li className="p-3 justify-between flex border-b-2 border-[white] hover:border-b-2 hover:border-[lightgray] cursor-pointer">
            {props.text}
            <Image src={props.icon} className="h-6 w-6" alt="icono del item"/>
        </li>
    );   
}