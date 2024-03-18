import aeropuertos from "../../../../public/aeropuerto.png";
import instalaciones from "../../../../public/almacen.png";
import servicios from "../../../../public/informacion.png";
import reparaciones from "../../../../public/sistema.png";
import aviones from "../../../../public/avion.png";
import Image from "next/image";

type AddFormProps = {
    type: string;
    handleToggleEvent : ()=>void;
};

export default function AddForm(props: AddFormProps) {
    switch (props.type) {
        case "Aeropuertos":
            return (
                <form
                    action="none"
                    className="mt-6 relative rounded-lg px-[1%] py-[2%] flex flex-col w-[33%] m-auto shadow-[0px_5px_10px_rgba(0,0,0,0.3)]"
                >
                    <button className="absolute right-5 text-[#e3e5ec] hover:text-black" onClick={props.handleToggleEvent}>X</button>
                    <caption className="font-bold flex flex-row justify-center mb-6">Nuevo Aeropuerto <Image alt="aeropuertos_icon" className="ml-6 h-6 w-6" src={aeropuertos}/></caption>
                    <label htmlFor="Nombre">Nombre</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Nombre" type="text" />
                    <label htmlFor="Ubicacion">Ubicación</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Ubicacion" type="text" />
                    <label htmlFor="Posicion">Posición Geográfica</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Posicion" type="text" />
                    <button type="submit" className="bg-[#005b7f] text-white rounded-lg p-[2%] mt-6 w-[30%] self-end">Añadir</button>
                </form>
            );
        case "Instalaciones":
            return (
                <form
                    action=""
                    className="mt-6 relative rounded-lg px-[1%] py-[2%] flex flex-col w-[33%] m-auto shadow-[0px_5px_10px_rgba(0,0,0,0.3)]"
                >
                    <button className="absolute right-5 text-[#e3e5ec] hover:text-black" onClick={props.handleToggleEvent}>X</button>
                    <caption className="font-bold flex flex-row justify-center mb-6">Nueva Instalación<Image alt="instalaciones_icon" className="ml-6 h-6 w-6" src={instalaciones}/></caption>
                    <label htmlFor="Nombre">Nombre</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Nombre" type="text" />
                    <label htmlFor="Tipo">Tipo</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Tipo" type="text" />
                    <label htmlFor="Ubicacion">Ubicacion</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Ubicacion" type="text" />
                    <button type="submit" className="bg-[#005b7f] text-white rounded-lg p-[2%] mt-6 w-[30%] self-end">Añadir</button>
                </form>
            );
        case "Servicios":
            return (
                <form
                    action=""
                    className="mt-6 relative rounded-lg px-[1%] py-[2%] flex flex-col w-[33%] m-auto shadow-[0px_5px_10px_rgba(0,0,0,0.3)]"
                >
                    <button className="absolute right-5 text-[#e3e5ec] hover:text-black" onClick={props.handleToggleEvent}>X</button>
                    <caption className="font-bold flex flex-row justify-center mb-6">Nuevo Servicio<Image alt="servicios_icon" className="ml-6 h-6 w-6" src={servicios}/></caption>
                    <label htmlFor="Descripcion">Descripcion</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Descripcion" type="text" />
                    <label htmlFor="Precio">Precio</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Precio" type="text" />
                    <button type="submit" className="bg-[#005b7f] text-white rounded-lg p-[2%] mt-6 w-[30%] self-end">Añadir</button>
                </form>
            );
        case "Reparciones":
            return (
                <form
                    action=""
                    className="mt-6 relative rounded-lg px-[1%] py-[2%] flex flex-col w-[33%] m-auto shadow-[0px_5px_10px_rgba(0,0,0,0.3)]"
                >
                    <button className="absolute right-5 text-[#e3e5ec] hover:text-black" onClick={props.handleToggleEvent}>X</button>
                    <caption className="font-bold flex flex-row justify-center mb-6">Nueva Reparacion<Image alt="reparaciones_icon" className="ml-6 h-6 w-6" src={reparaciones}/></caption>
                    <label htmlFor="Descripcion">Descripcion</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Descripcion" type="text" />
                    <label htmlFor="Precio">Precio</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Precio" type="text" />
                    <label htmlFor="Tipo">Tipo</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Tipo" type="text" />
                    <button type="submit" className="bg-[#005b7f] text-white rounded-lg p-[2%] mt-6 w-[30%] self-end">Añadir</button>
                </form>
            );
        case "Clientes":
            return (
                <form
                    action=""
                    className="mt-6 relative rounded-lg px-[1%] py-[2%] flex flex-col w-[33%] m-auto shadow-[0px_5px_10px_rgba(0,0,0,0.3)]"
                >
                    <button className="absolute right-5 text-[#e3e5ec] hover:text-black" onClick={props.handleToggleEvent}>X</button>
                    <caption className="font-bold flex flex-row justify-center mb-6">Nuevo Cliente<Image alt="reparaciones_icon" className="ml-6 h-6 w-6" src={aviones}/></caption>
                    <label htmlFor="Nombre">Nombre</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Nombre" type="text" />
                    <label htmlFor="Nacionalidad">Nacionalidad</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Nacionalidad" type="text" />
                    <label htmlFor="Tipo">Tipo</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Tipo" type="text" />
                    <label htmlFor="HasNave">HasNave</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="HasNave" type="text" />
                    <button type="submit" className="bg-[#005b7f] text-white rounded-lg p-[2%] mt-6 w-[30%] self-end">Añadir</button>
                </form>
            );
        case "Naves":
            return (
                <form
                    action=""
                    className="mt-6 relative rounded-lg px-[1%] py-[2%] flex flex-col w-[33%] m-auto shadow-[0px_5px_10px_rgba(0,0,0,0.3)]"
                >
                    <button className="absolute right-5 text-[#e3e5ec] hover:text-black">X</button>
                    <caption className="font-bold flex flex-row justify-center mb-6">Nueva Nave<Image alt="naves_icon" className="ml-6 h-6 w-6" src={aviones}/></caption>
                    <label htmlFor="Matricula">Matricula</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Matricula" type="text" />
                    <label htmlFor="Plazas">Plazas</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Plazas" type="text" />
                    <label htmlFor="Clasificacion">Clasificacion</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Clasificacion" type="text" />
                    <label htmlFor="Tripulantes">Tripulantes</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Nombre" type="text" />
                    <label htmlFor="Capacidad">Capacidad</label>
                    <input className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]" name="Capacidad" type="text" />
                    <button type="submit" className="bg-[#005b7f] text-white rounded-lg p-[2%] mt-6 w-[30%] self-end">Añadir</button>
                </form>
            );
    }
}
