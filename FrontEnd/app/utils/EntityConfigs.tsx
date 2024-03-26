import aeropuertos from "../../public/aeropuerto.png";
import instalaciones from "../../public/almacen.png";
import servicios from "../../public/informacion.png";
import reparaciones from "../../public/sistema.png";
import aviones from "../../public/avion.png";
import clientes from "../../public/cliente.png";
import administradores from "../../public/adminstrador.png";
import estancias from "../../public/estancia.png";
import reparacionesNaves from "../../public/reparacionNave.png"

//(TODO) como modelar el costo de los servicios brindados

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
        relations: [
            { name: "Instalaciones", icon: instalaciones },
            { name: "Servicios", icon: servicios },
            { name: "Reparaciones", icon: reparaciones },
            { name: "Estancias", icon: null },
            { name: "Clientes con naves", icon: null },
        ],
        endPoints: { post: "http://localhost:5258/airports" },
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
        },
        relations: [
            { name: "Instalaciones", icon: instalaciones },
            { name: "Servicios", icon: servicios },
            { name: "Reparaciones", icon: reparaciones },
            { name: "Estancias", icon: estancias },
            { name: "Clientes con naves", icon: clientes },
        ],
        endPoints: { post: "http://localhost:5258/Airports" },
        tableWidths: ["5%", "25%", "30%", "30%", "10%"],
    },
    Instalaciones: {
        formConfig: {
            caption: "Nueva Instalación",
            icon: instalaciones,
            inputs: [
                { name: "Nombre", label: "Nombre", type: "text" },
                { name: "Ubicación", label: "Ubicación", type: "text" },
                { name: "Tipo", label: "Tipo", type: "select" },
            ],
        },
        relations: [
            { name: "Aeropuerto", icon: aeropuertos },
            { name: "Servicios", icon: servicios },
            { name: "Reparaciones", icon: reparaciones },
        ],
        endPoints: { post: "http://localhost:5258/airports" },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    Servicios: {
        formConfig: {
            caption: "Nuevo Servicio",
            icon: servicios,
            inputs: [
                { name: "Código", label: "Código", type: "number" },
                { name: "Descripción", label: "Descripción", type: "text" },
                { name: "Precio", label: "Precio", type: "text" },
            ],
        },
        relations: [
            { name: "Brindado a", icon: aviones },
            { name: "Brindado en: Aeropuertos", icon: aeropuertos },
            { name: "Brindado en: Instalaciones", icon: instalaciones },
        ],
        endPoints: { post: "http://localhost:5258/services" },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    Reparciones: {
        formConfig: {
            caption: "Nueva Reparación",
            icon: reparaciones,
            inputs: [
                { name: "Código", label: "Código", type: "number" },
                { name: "Descripción", label: "Descripción", type: "text" },
                { name: "Precio", label: "Precio", type: "text" },
                { name: "Tipo", label: "Tipo", type: "select" },
            ],
        },
        relations: [
            { name: "Brindado a", icon: aviones },
            { name: "Brindado en: Aeropuertos", icon: aeropuertos },
            { name: "Brindado en: Instalaciones", icon: instalaciones },
        ],
        endPoints: { post: "http://localhost:5258/airports" },
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
        },
        relations: [{ name: "Naves", icon: aviones }],
        endPoints: { post: "http://localhost:5258/Clients" },
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
        },
        relations: [
            { name: "Servicios", icon: servicios },
            { name: "Reparaciones", icon: reparaciones },
            { name: "Estancias", icon: estancias },
            { name: "Dueño", icon: clientes },
        ],
        endPoints: { post: "http://localhost:5258/Airplanes" },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    Estancias: {
        formConfig: {
            caption: "Nueva Estancia",
            icon: estancias,
            inputs: [
                {
                    name: "Fecha de Inicio",
                    label: "FechaDeInicio",
                    type: "date",
                },
                {
                    name: "Fecha Planificad de Fin",
                    label: "FechaDeFin",
                    type: "date",
                },
                { name: "Id de Aeropuerto", label: "IdA", type: "select" },
                { name: "Matrícula", label: "Matrícula", type: "select" },
                { name: "Valoración", label: "Valoración", type: "number" },
            ],
        },
        relations: [
            { name: "Nave", icon: aviones },
            { name: "Aeropuerto", icon: aeropuertos },
            { name: "Servicios", icon: servicios },
        ],
        endPoints: { post: "http://localhost:5258/airports" },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    ReparacionesNaves: {
        formConfig: {
            caption: "Nueva Reparación a Nave",
            icon: reparacionesNaves,
            inputs: [
                {
                    name: "Fecha de Inicio",
                    label: "FechaDeInicio",
                    type: "date",
                },
                {
                    name: "Fecha de Fin",
                    label: "FechaDeFin",
                    type: "date",
                },
                { name: "Matrícula", label: "Matrícula", type: "select" },
                { name: "Código", label: "Código", type: "select" },
                { name: "Tiempo", label: "Tiempo", type: "number" },
            ],
        },
        relations: [
            { name: "Reparaciones Impilcadas", icon: reparaciones },
            { name: "Nave", icon: aviones },
            { name: "Reparacion", icon: reparaciones },
        ],
        endPoints: { post: "http://localhost:5258/airports" },
        tableWidths: ["5%", "25%", "60%", "10%"],
    },
    default: {
        formConfig: {
            caption: "No se que hacer",
            icon: aviones,
            inputs: [],
        },
        relations: [],
        endPoints: {},
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
        case "Estancias":
            return allEntityConfigs.Estancias.formConfig;
        case "ReparacionesNaves":
            return allEntityConfigs.ReparacionesNaves.formConfig;
        default:
            return allEntityConfigs.default.formConfig;
    }
}

export function getTableWidths(entity: string) {
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
        case "Estancias":
            return allEntityConfigs.Estancias.tableWidths;
        case "ReparacionesNaves":
            return allEntityConfigs.ReparacionesNaves.tableWidths;
        default:
            return allEntityConfigs.default.tableWidths;
    }
}

export function getEndpoints(entity: string) {
    switch (entity) {
        case "Administradores":
            return allEntityConfigs.Administradores.endPoints;
        case "Aeropuertos":
            return allEntityConfigs.Aeropuertos.endPoints;
        case "Instalaciones":
            return allEntityConfigs.Instalaciones.endPoints;
        case "Servicios":
            return allEntityConfigs.Servicios.endPoints;
        case "Reparciones":
            return allEntityConfigs.Reparciones.endPoints;
        case "Clientes":
            return allEntityConfigs.Clientes.endPoints;
        case "Naves":
            return allEntityConfigs.Naves.endPoints;
        case "Estancias":
            return allEntityConfigs.Estancias.endPoints;
        case "ReparacionesNaves":
            return allEntityConfigs.ReparacionesNaves.endPoints;
        default:
            return allEntityConfigs.default.endPoints;
    }
}

export function getRelations(entity: string) {
    switch (entity) {
        case "Administradores":
            return allEntityConfigs.Administradores.relations;
        case "Aeropuertos":
            return allEntityConfigs.Aeropuertos.relations;
        case "Instalaciones":
            return allEntityConfigs.Instalaciones.relations;
        case "Servicios":
            return allEntityConfigs.Servicios.relations;
        case "Reparciones":
            return allEntityConfigs.Reparciones.relations;
        case "Clientes":
            return allEntityConfigs.Clientes.relations;
        case "Naves":
            return allEntityConfigs.Naves.relations;
        case "Estancias":
            return allEntityConfigs.Estancias.relations;
        case "ReparacionesNaves":
            return allEntityConfigs.ReparacionesNaves.relations;
        default:
            return allEntityConfigs.default.relations;
    }
}

//`reparation-services`
