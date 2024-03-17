import aeropuertos from "../../public/aeropuerto (2).png";
import instalaciones from "../../public/almacen.png";
import servicios from "../../public/informacion.png";
import reparaciones from "../../public/sistema.png";
import aviones from "../../public/avion.png";

import SideBarItem from "./SideBarItem";

export default function SideBar(){
    return (
        <aside className="w-[15vw] h-full border-r-2 shadow-[inset_-9px_10px_20px_-15px_rgba(0,0,0,0.3)]">
            <ul className="w-full p-2">
                <SideBarItem text="Aeropuertos" icon={aeropuertos}/>
                <SideBarItem text="Instalaciones" icon={instalaciones}/>
                <SideBarItem text="Servicios" icon={servicios}/>
                <SideBarItem text="Reparciones" icon={reparaciones}/>
                <SideBarItem text="Clientes" icon={aviones}/>
                <SideBarItem text="Naves" icon={aviones}/>
            </ul>
        </aside>
    );
}
