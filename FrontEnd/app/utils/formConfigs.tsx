import aeropuertos from "../../../../public/aeropuerto.png";
import instalaciones from "../../../../public/almacen.png";
import servicios from "../../../../public/informacion.png";
import reparaciones from "../../../../public/sistema.png";
import aviones from "../../../../public/avion.png";
import clientes from "../../../../public/cliente.png";
import administradores from "../../../../public/adminstrador.png";

export const allFormConfigs = {
    Administradores: {
        caption: "Nuevo Administrador",
        icon: administradores,
        inputs: [
            { name: "Nombre", label: "Nombre", type: "text" },
            { name: "Ubicación", label: "Ubicación", type: "text" },
            { name: "Posición Geográfica", label: "Posición", type: "text" },
        ],
    },
    Aeropuertos: {
        caption: "Nuevo Aeropuerto",
        icon: aeropuertos,
        inputs: [
            { name: "Nombre", label: "Nombre", type: "text" },
            { name: "Ubicación", label: "Ubicación", type: "text" },
            { name: "Posición Geográfica", label: "Posición", type: "text" },
        ],
    },
    Instalaciones: {
        caption: "Nueva Instalación",
        icon: instalaciones,
        inputs: [
            { name: "Nombre", label: "Nombre", type: "text" },
            { name: "Ubicación", label: "Ubicación", type: "text" },
            { name: "Tipo", label: "Tipo", type: "select" },
        ],
    },
    Servicios: {
        caption: "Nuevo Servicio",
        icon: servicios,
        inputs: [
            { name: "Descripción", label: "Descripción", type: "text" },
            { name: "Precio", label: "Precio", type: "text" },
        ],
    },
    Reparciones: {
        caption: "Nueva Reparación",
        icon: reparaciones,
        inputs: [
            { name: "Descripción", label: "Descripción", type: "text" },
            { name: "Precio", label: "Precio", type: "text" },
            { name: "Tipo", label: "Tipo", type: "select" },
        ],
    },
    Clientes: {
        caption: "Nuevo Cliente",
        icon: clientes,
        inputs: [
            { name: "Nombre", label: "Nombre", type: "text" },
            { name: "Nacionalidad", label: "Nacionalidad", type: "select" },
            { name: "Tipo", label: "Tipo", type: "select" },
            { name: "Dueño de nave", label: "DueñoDeNave", type: "checkbox" },
        ],
    },
    Naves: {
        caption: "Nueva Nave",
        icon: aviones,
        inputs: [
            { name: "Matrícula", label: "Matrícula", type: "text" },
            { name: "Clasificación", label: "Clasificación", type: "select" },
            { name: "Cant. de Plazas", label: "CantDePlazas", type: "number" },
            { name: "Cant. de Tripulantes", label: "CantDeTripulantes", type: "number" },
        ],
    },
    default: {
        caption: "No se que hacer",
        icon: aviones,
        inputs: [],
    }
};

