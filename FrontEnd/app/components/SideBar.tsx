import aeropuertos from "../../public/aeropuerto (2).png";
import instalaciones from "../../public/almacen.png";
import servicios from "../../public/informacion.png";
import reparaciones from "../../public/sistema.png";
import aviones from "../../public/avion.png";

import SideBarItem from "./SideBarItem";

export default function SideBar(){
    return (
        <aside className="w-[15vw] h-full border-r-2">
            <ul className="w-full p-2">
                <SideBarItem text="Aeropuertos" icon={aeropuertos}/>
                <SideBarItem text="Instalaciones" icon={instalaciones}/>
                <SideBarItem text="Servicios" icon={servicios}/>
                <SideBarItem text="Reparciones" icon={reparaciones}/>
                <SideBarItem text="Naves" icon={aviones}/>
                <SideBarItem text="ETC..." icon={aviones}/>
            </ul>
        </aside>
    );
}
