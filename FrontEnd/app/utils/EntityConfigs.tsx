import aeropuertos from "../../public/aeropuerto.png";
import instalaciones from "../../public/almacen.png";
import servicios from "../../public/informacion.png";
import reparaciones from "../../public/sistema.png";
import aviones from "../../public/avion.png";
import clientes from "../../public/cliente.png";
import administradores from "../../public/adminstrador.png";

export const allEntityConfigs = {
    Administradores: {
        formConfig: {
            caption: "Nuevo Administrador",
            icon: administradores,
            inputs: [
                { name: "Nombre", label: "Nombre", type: "text" },
                { name: "Ubicación", label: "Ubicación", type: "text" },
                {
                    name: "Posición Geográfica",
                    label: "Posición",
                    type: "text",
                },
            ],
        },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    Aeropuertos: {
        formConfig: {
            caption: "Nuevo Aeropuerto",
            icon: aeropuertos,
            inputs: [
                { name: "Nombre", label: "Nombre", type: "text" },
                { name: "Ubicación", label: "Ubicación", type: "text" },
                {
                    name: "Posición Geográfica",
                    label: "Posición",
                    type: "text",
                },
            ],
            endPoints: { post: "http://localhost:5258/airports" },
        },
        tableWidths: ["5%", "25%", "30%", "30%", "10%"],
    },
    //add same shape to every type below
    Instalaciones: {
        formConfig: {
            caption: "Nueva Instalación",
            icon: instalaciones,
            inputs: [
                { name: "Nombre", label: "Nombre", type: "text" },
                { name: "Ubicación", label: "Ubicación", type: "text" },
                { name: "Tipo", label: "Tipo", type: "select" },
            ],
            endPoints: { post: "http://localhost:5258/airports" },
        },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    Servicios: {
        formConfig: {
            caption: "Nuevo Servicio",
            icon: servicios,
            inputs: [
                { name: "Descripción", label: "Descripción", type: "text" },
                { name: "Precio", label: "Precio", type: "text" },
            ],
            endPoints: { post: "http://localhost:5258/airports" },
        },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    Reparciones: {
        formConfig: {
            caption: "Nueva Reparación",
            icon: reparaciones,
            inputs: [
                { name: "Descripción", label: "Descripción", type: "text" },
                { name: "Precio", label: "Precio", type: "text" },
                { name: "Tipo", label: "Tipo", type: "select" },
            ],
            endPoints: { post: "http://localhost:5258/airports" },
        },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    Clientes: {
        formConfig: {
            caption: "Nuevo Cliente",
            icon: clientes,
            inputs: [
                { name: "Nombre", label: "Nombre", type: "text" },
                { name: "Nacionalidad", label: "Nacionalidad", type: "select" },
                { name: "Tipo", label: "Tipo", type: "select" },
                {
                    name: "Dueño de nave",
                    label: "DueñoDeNave",
                    type: "checkbox",
                },
            ],
            endPoints: { post: "http://localhost:5258/airports" },
        },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    Naves: {
        formConfig: {
            caption: "Nueva Nave",
            icon: aviones,
            inputs: [
                { name: "Matrícula", label: "Matrícula", type: "text" },
                {
                    name: "Clasificación",
                    label: "Clasificación",
                    type: "select",
                },
                {
                    name: "Cant. de Plazas",
                    label: "CantDePlazas",
                    type: "number",
                },
                {
                    name: "Cant. de Tripulantes",
                    label: "CantDeTripulantes",
                    type: "number",
                },
            ],
            endPoints: { post: "http://localhost:5258/airports" },
        },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    default: {
        formConfig: {
            caption: "No se que hacer",
            icon: aviones,
            inputs: [],
            endPoints: {},
        },
        tableWidths: ["100%"],
    },
};

export function getFormConfigs(entity: string) {
    switch (entity) {
        case "Administradores":
            return allEntityConfigs.Administradores.formConfig;
        case "Aeropuertos":
            return allEntityConfigs.Aeropuertos.formConfig;
        case "Instalaciones":
            return allEntityConfigs.Instalaciones.formConfig;
        case "Servicios":
            return allEntityConfigs.Servicios.formConfig;
        case "Reparciones":
            return allEntityConfigs.Reparciones.formConfig;
        case "Clientes":
            return allEntityConfigs.Clientes.formConfig;
        case "Naves":
            return allEntityConfigs.Naves.formConfig;
        default:
            return allEntityConfigs.default.formConfig;
    }
}

export function getTableWdths(entity: string) {
    switch (entity) {
        case "Administradores":
            return allEntityConfigs.Administradores.tableWidths;
        case "Aeropuertos":
            return allEntityConfigs.Aeropuertos.tableWidths;
        case "Instalaciones":
            return allEntityConfigs.Instalaciones.tableWidths;
        case "Servicios":
            return allEntityConfigs.Servicios.tableWidths;
        case "Reparciones":
            return allEntityConfigs.Reparciones.tableWidths;
        case "Clientes":
            return allEntityConfigs.Clientes.tableWidths;
        case "Naves":
            return allEntityConfigs.Naves.tableWidths;
        default:
            return allEntityConfigs.default.tableWidths;
    }
}
