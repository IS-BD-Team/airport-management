type AddFormProps = {
    type: string;
};

export default function AddForm(props: AddFormProps) {
    switch (props.type) {
        case "Aeropuertos":
            return (
                <form
                    action=""
                    className="rounded-lg border-[2px] border-solid border-[#e3e5ec]"
                >
                    <label htmlFor="Nombre">Nombre</label>
                    <input name="Nombre" type="text" />
                    <label htmlFor="Ubicacion">Ubicación</label>
                    <input name="Ubicacion" type="text" />
                    <label htmlFor="Posicion">Posición Geográfica</label>
                    <input name="Posicion" type="text" />
                </form>
            );
        case "Instalaciones":
            return (
                <form
                    action=""
                    className="rounded-lg border-[2px] border-solid border-[#e3e5ec]"
                >
                    <label htmlFor="Nombre">Nombre</label>
                    <input name="Nombre" type="text" />
                    <label htmlFor="Tipo">Tipo</label>
                    <input name="Tipo" type="text" />
                    <label htmlFor="Ubicacion">Ubicacion</label>
                    <input name="Ubicacion" type="text" />
                </form>
            );
        case "Servicios":
            return (
                <form
                    action=""
                    className="rounded-lg border-[2px] border-solid border-[#e3e5ec]"
                >
                    <label htmlFor="Descripcion">Descripcion</label>
                    <input name="Descripcion" type="text" />
                    <label htmlFor="Precio">Precio</label>
                    <input name="Precio" type="text" />
                </form>
            );
        case "Reparciones":
            return (
                <form
                    action=""
                    className="rounded-lg border-[2px] border-solid border-[#e3e5ec]"
                >
                    <label htmlFor="Descripcion">Descripcion</label>
                    <input name="Descripcion" type="text" />
                    <label htmlFor="Precio">Precio</label>
                    <input name="Precio" type="text" />
                    <label htmlFor="Tipo">Tipo</label>
                    <input name="Tipo" type="text" />
                </form>
            );
        case "Clientes":
            return (
                <form
                    action=""
                    className="rounded-lg border-[2px] border-solid border-[#e3e5ec]"
                >
                    <label htmlFor="Nombre">Nombre</label>
                    <input name="Nombre" type="text" />
                    <label htmlFor="Nacionalidad">Nacionalidad</label>
                    <input name="Nacionalidad" type="text" />
                    <label htmlFor="Tipo">Tipo</label>
                    <input name="Tipo" type="text" />
                    <label htmlFor="HasNave">HasNave</label>
                    <input name="HasNave" type="text" />
                </form>
            );
        case "Naves":
            return (
                <form
                    action=""
                    className="rounded-lg border-[2px] border-solid border-[#e3e5ec]"
                >
                    <label htmlFor="Matricula">Matricula</label>
                    <input name="Matricula" type="text" />
                    <label htmlFor="Plazas">Plazas</label>
                    <input name="Plazas" type="text" />
                    <label htmlFor="Clasificacion">Clasificacion</label>
                    <input name="Clasificacion" type="text" />
                    <label htmlFor="Tripulantes">Tripulantes</label>
                    <input name="Nombre" type="text" />
                    <label htmlFor="Capacidad">Capacidad</label>
                    <input name="Capacidad" type="text" />
                </form>
            );
    }
}
