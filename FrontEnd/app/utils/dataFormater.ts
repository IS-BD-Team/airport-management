/*import {
    Instance,
    Aeropuerto,
    Cliente,
    Estancia,
    Instalacion,
    Nave,
    ReparacionNave,
    Reparcion,
    Servicio,
} from "./types";

export type FormatedData = {
    name: string;
    id: string;
    picture: any;
};

export default function dataFormater(data: Instance, entity: string) {
    let formatedData = { name: "", id: "", picture: undefined };
    switch (entity) {
        case "Administradores":
            return formatedData;
        case "Aeropuertos":
            Object.defineProperty(formatedData, "id", {
                value: (data as Aeropuerto).id,
            });
            Object.defineProperty(formatedData, "name", {
                value: (data as Aeropuerto).nombre,
            });
            Object.entries(data as Aeropuerto).forEach(([key, value]) => {
                if (key === "id" || key === "nombre") return;
                Object.defineProperty(formatedData, key, { value: value });
            });
            return formatedData;
        case "Instalaciones":
            Object.defineProperty(formatedData, "id", {
                value:
                    (data as Instalacion).ida + " " + (data as Instalacion).idi,
            });
            Object.defineProperty(formatedData, "name", {
                value: (data as Instalacion).nombre,
            });
            Object.entries(data as Instalacion).forEach(([key, value]) => {
                if (key === "idi" || key === "ida" || key === "nombre") return;
                Object.defineProperty(formatedData, key, { value: value });
            });
            return formatedData;
        case "Servicios":
            Object.defineProperty(formatedData, "id", {
                value: (data as Servicio).id,
            });
            Object.defineProperty(formatedData, "name", {
                value: "Servicio: " + (data as Servicio).id,
            });
            Object.entries(data as Servicio).forEach(([key, value]) => {
                if (key === "id") return;
                Object.defineProperty(formatedData, key, { value: value });
            });
            return formatedData;
        case "Reparciones":
            Object.defineProperty(formatedData, "id", {
                value: (data as Reparcion).id,
            });
            Object.defineProperty(formatedData, "name", {
                value: "Reparcion: " + (data as Reparcion).id,
            });
            Object.entries(data as Reparcion).forEach(([key, value]) => {
                if (key === "id") return;
                Object.defineProperty(formatedData, key, { value: value });
            });
            return formatedData;
        case "Clientes":
            Object.defineProperty(formatedData, "id", {
                value: (data as Cliente).id,
            });
            Object.defineProperty(formatedData, "name", {
                value: (data as Cliente).nombre,
            });
            Object.entries(data as Cliente).forEach(([key, value]) => {
                if (key === "id" || key === "nombre") return;
                Object.defineProperty(formatedData, key, { value: value });
            });
            return formatedData;
        case "Naves":
            Object.defineProperty(formatedData, "id", {
                value: (data as Nave).matricula,
            });
            Object.defineProperty(formatedData, "name", {
                value: "Nave: " + (data as Nave).matricula,
            });
            Object.entries(data as Nave).forEach(([key, value]) => {
                if (key === "id") return;
                Object.defineProperty(formatedData, key, { value: value });
            });
            return formatedData;
        case "Estancias":
            Object.defineProperty(formatedData, "id", {
                value:
                    (data as Estancia).matricula +
                    " " +
                    (data as Estancia).idA +
                    " " +
                    (data as Estancia).fechaInicio,
            });
            Object.defineProperty(formatedData, "name", {
                value:
                    "Estancia de: " +
                    (data as Estancia).matricula +
                    " en: " +
                    (data as Estancia).idA +
                    " desde: " +
                    (data as Estancia).fechaInicio,
            });
            Object.entries(data as Estancia).forEach(([key, value]) => {
                if (key === "id") return;
                Object.defineProperty(formatedData, key, { value: value });
            });
            return formatedData;
        case "ReparacionesNaves":
            Object.defineProperty(formatedData, "id", {
                value:
                    (data as ReparacionNave).matricula +
                    " " +
                    (data as ReparacionNave).codigo +
                    " " +
                    (data as ReparacionNave).fechaInicio,
            });
            Object.defineProperty(formatedData, "name", {
                value:
                    "Reparacion: " +
                    (data as ReparacionNave).codigo +
                    " de: " +
                    (data as ReparacionNave).matricula +
                    " en: " +
                    (data as ReparacionNave).fechaInicio,
            });
            Object.entries(data as ReparacionNave).forEach(([key, value]) => {
                if (key === "id") return;
                Object.defineProperty(formatedData, key, { value: value });
            });
            return formatedData;
        default:
            return formatedData;
    }
}
*/