import aeropuertos from "../../public/aeropuerto.png";
import instalaciones from "../../public/almacen.png";
import servicios from "../../public/informacion.png";
import reparaciones from "../../public/sistema.png";
import aviones from "../../public/avion.png";
import clientes from "../../public/cliente.png";
import administradores from "../../public/adminstrador.png";
import estancias from "../../public/estancia.png";
import reparacionesNaves from "../../public/reparacionNave.png";

//(TODO) como modelar el costo de los servicios brindados

export const allEntityConfigs = {
  Administradores: {
    formConfig: {
      caption: "Nuevo Administrador",
      icon: administradores,
      inputs: [
        {
          name: "Nombre",
          label: "Nombre",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Ubicación",
          label: "Ubicación",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Posición Geográfica",
          label: "Posición",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      { name: "Instalaciones", icon: instalaciones, link: "" },
      { name: "Servicios", icon: servicios, link: "" },
      { name: "Reparaciones", icon: reparaciones, link: "" },
      { name: "Estancias", icon: estancias, link: "" },
      { name: "Clientes con naves", icon: clientes, link: "" },
    ],
    endPoint: "http://localhost:5258/Airports",
    tableWidths: ["5%", "25%", "60%", "10%"],
  },
  Aeropuertos: {
    formConfig: {
      caption: "Nuevo Aeropuerto",
      icon: aeropuertos,
      inputs: [
        {
          name: "Nombre",
          label: "name",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Ubicación",
          label: "address",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Posición Geográfica",
          label: "geographicLocation",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      {
        name: "Instalaciones",
        icon: instalaciones,
        link: "/dashboard/DataManagementSection?entity=Instalaciones&relation=Aeropuertos&id=",
      },
      {
        name: "Servicios",
        icon: servicios,
        link: "/dashboard/DataManagementSection?entity=Servicios&relation=Aeropuertos&id=",
      },
      {
        name: "Reparaciones",
        icon: reparaciones,
        link: "/dashboard/DataManagementSection?entity=Reparaciones&relation=Aeropuertos&id=",
      },
      {
        name: "Estancias",
        icon: estancias,
        link: "/dashboard/DataManagementSection?entity=Estancias&relation=Aeropuertos&id=",
      },
      {
        name: "Clientes con naves",
        icon: clientes,
        link: "/dashboard/DataManagementSection?entity=Clientes con naves&relation=Aeropuertos&id=",
      },
    ],
    endPoint: "http://localhost:5258/Airports",
    tableWidths: ["5%", "25%", "30%", "30%", "10%"],
  },
  Instalaciones: {
    formConfig: {
      caption: "Nueva Instalación",
      icon: instalaciones,
      inputs: [
        {
          name: "Nombre",
          label: "name",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Ubicación",
          label: "location",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Aeropuerto",
          label: "airportId",
          type: "select",
          options: {
            from: "http://localhost:5258/Airports",
            value: 0,
            name: 1,
          },
        },
        {
          name: "Tipo",
          label: "type",
          type: "text", //(TODO) esto es un select falta el endpoint de rafa
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      {
        name: "Aeropuerto",
        icon: aeropuertos,
        link: "/dashboard/InstanceViewSection?entity=Aeropuertos&relation=Instalaciones&id=",
      },
      {
        name: "Servicios",
        icon: servicios,
        link: "/dashboard/DataManagementSection?entity=Servicios&relation=Instalaciones&id=",
      },
      {
        name: "Reparaciones",
        icon: reparaciones,
        link: "/dashboard/DataManagementSection?entity=Reparaciones&relation=Instalaciones&id=",
      },
    ],
    endPoint: "http://localhost:5258/Facilities",
    tableWidths: ["5%", "25%", "60%", "10%"],
  },
  Servicios: {
    formConfig: {
      caption: "Nuevo Servicio",
      icon: servicios,
      inputs: [
        {
          name: "Descripción",
          label: "Descripción",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Precio",
          label: "Precio",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Instalación",
          label: "facilityId",
          type: "select",
          options: {
            from: "http://localhost:5258/Facilities",
            value: 1,
            name: 2,
          },
        },
      ],
    },
    relations: [
      {
        name: "Brindado a",
        icon: aviones,
        link: "/dashboard/DataManagementSection?entity=Naves&relation=Servicios&id=",
      },
      {
        name: "Brindado en: Aeropuertos",
        icon: aeropuertos,
        link: "/dashboard/DataManagementSection?entity=Aeropuertos&relation=Servicios&id=",
      },
      {
        name: "Brindado en: Instalaciones",
        icon: instalaciones,
        link: "/dashboard/DataManagementSection?entity=Instalaciones&relation=Servicios&id=",
      },
    ],
    endPoint: "http://localhost:5258/Services",
    tableWidths: ["5%", "25%", "60%", "10%"],
  },
  Reparaciones: {
    formConfig: {
      caption: "Nueva Reparación",
      icon: reparaciones,
      inputs: [
        {
          name: "Descripción",
          label: "Descripción",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Precio",
          label: "Precio",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Instalación",
          label: "facilityId",
          type: "select",
          options: {
            from: "http://localhost:5258/Facilities",
            value: 1,
            name: 2,
          },
        },
        {
          name: "Tipo",
          label: "Tipo",
          type: "select",
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      {
        name: "Brindado a",
        icon: aviones,
        link: "/dashboard/DataManagementSection?entity=Naves&relation=Reparaciones&id=",
      },
      {
        name: "Brindado en: Aeropuertos",
        icon: aeropuertos,
        link: "/dashboard/DataManagementSection?entity=Aeropuertos&relation=Reparaciones&id=",
      },
      {
        name: "Brindado en: Instalaciones",
        icon: instalaciones,
        link: "/dashboard/DataManagementSection?entity=Instalaciones&relation=Reparaciones&id=",
      },
    ],
    endPoint: "http://localhost:5258/RepairServices",
    tableWidths: ["5%", "25%", "60%", "10%"],
  },
  Clientes: {
    formConfig: {
      caption: "Nuevo Cliente",
      icon: clientes,
      inputs: [
        {
          name: "Nombre",
          label: "Nombre",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Nacionalidad",
          label: "Nacionalidad",
          type: "select",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Tipo",
          label: "Tipo",
          type: "select",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Dueño de nave",
          label: "DueñoDeNave",
          type: "checkbox",
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      {
        name: "Naves",
        icon: aviones,
        link: "/dashboard/DataManagementSection?entity=Naves&relation=Clientes&id=",
      },
    ],
    endPoint: "http://localhost:5258/Clients",
    tableWidths: ["5%", "25%", "60%", "10%"],
  },
  Naves: {
    formConfig: {
      caption: "Nueva Nave",
      icon: aviones,
      inputs: [
        {
          name: "Matrícula",
          label: "Matrícula",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Clasificación",
          label: "Clasificación",
          type: "select",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Dueño",
          label: "Dueño",
          type: "select",
          options: {
            from: "http://localhost:5258/Clients",
            value: 0,
            name: 1,
          },
        },
        {
          name: "Cant. de Plazas",
          label: "CantDePlazas",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Cant. de Tripulantes",
          label: "CantDeTripulantes",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      {
        name: "Servicios",
        icon: servicios,
        link: "/dashboard/DataManagementSection?entity=Servicios&relation=Naves&id=",
      },
      {
        name: "Reparaciones",
        icon: reparaciones,
        link: "/dashboard/DataManagementSection?entity=Reparaciones&relation=Naves&id=",
      },
      {
        name: "Estancias",
        icon: estancias,
        link: "/dashboard/DataManagementSection?entity=Estancias&relation=Naves&id=",
      },
      {
        name: "Dueño",
        icon: clientes,
        link: "/dashboard/InstanceViewSection?entity=Dueño&relation=Naves&id=",
      },
    ],
    endPoint: "http://localhost:5258/Airplanes",
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
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Fecha Planificad de Fin",
          label: "FechaDeFin",
          type: "date",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Id de Aeropuerto",
          label: "IdA",
          type: "select",
          options: {
            from: "http://localhost:5258/Airports",
            value: 0,
            name: 1,
          },
        },
        {
          name: "Matrícula",
          label: "Matrícula",
          type: "select",
          options: {
            from: "http://localhost:5258/Airplanes",
            value: 0,
            name: 0,
          },
        },
        {
          name: "Valoración",
          label: "Valoración",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      {
        name: "Nave",
        icon: aviones,
        link: "/dashboard/InstanceViewSection?entity=Naves&relation=Estancias&id=",
      },
      {
        name: "Aeropuerto",
        icon: aeropuertos,
        link: "/dashboard/InstanceViewSection?entity=Aeropuertos&relation=Estancias&id=",
      },
      {
        name: "Servicios",
        icon: servicios,
        link: "/dashboard/DataManagementSection?entity=Servicios&relation=Estancias&id=",
      },
    ],
    endPoint: "http://localhost:5258/PlaneStay",
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
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Fecha de Fin",
          label: "FechaDeFin",
          type: "date",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Matrícula",
          label: "Matrícula",
          type: "select",
          options: {
            from: "http://localhost:5258/Airplanes",
            value: 0,
            name: 0,
          },
        },
        {
          name: "Código",
          label: "Código",
          type: "select",
          options: {
            from: "http://localhost:5258/RepairServices",
            value: 0,
            name: 0,
          },
        },
        {
          name: "Tiempo",
          label: "Tiempo",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      {
        name: "Reparaciones Implicadas",
        icon: reparacionesNaves,
        link: "/dashboard/DataManagementSection?entity=Reparaciones&relation=Reparaciones a Naves&id=",
      },
      {
        name: "Nave",
        icon: aviones,
        link: "/dashboard/InstanceViewSection?entity=Naves&relation=Reparaciones a Naves&id=",
      },
      {
        name: "Reparacion",
        icon: reparaciones,
        link: "/dashboard/InstanceViewSection?entity=Reparaciones&relation=Reparaciones a Naves&id=",
      },
    ],
    endPoint: "http://localhost:5258/AirplaneRepairServices",
    tableWidths: ["5%", "25%", "60%", "10%"],
  },
  default: {
    formConfig: {
      caption: "No se que hacer",
      icon: aviones,
      inputs: [],
    },
    relations: [],
    endPoint: "",
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
    case "Reparaciones":
      return allEntityConfigs.Reparaciones.formConfig;
    case "Clientes":
      return allEntityConfigs.Clientes.formConfig;
    case "Naves":
      return allEntityConfigs.Naves.formConfig;
    case "Estancias":
      return allEntityConfigs.Estancias.formConfig;
    case "Reparaciones a Naves":
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
    case "Reparaciones":
      return allEntityConfigs.Reparaciones.tableWidths;
    case "Clientes":
      return allEntityConfigs.Clientes.tableWidths;
    case "Naves":
      return allEntityConfigs.Naves.tableWidths;
    case "Estancias":
      return allEntityConfigs.Estancias.tableWidths;
    case "Reparaciones a Naves":
      return allEntityConfigs.ReparacionesNaves.tableWidths;
    default:
      return allEntityConfigs.default.tableWidths;
  }
}

export function getEndpoint(entity: string) {
  switch (entity) {
    case "Administradores":
      return allEntityConfigs.Administradores.endPoint;
    case "Aeropuertos":
      return allEntityConfigs.Aeropuertos.endPoint;
    case "Instalaciones":
      return allEntityConfigs.Instalaciones.endPoint;
    case "Servicios":
      return allEntityConfigs.Servicios.endPoint;
    case "Reparaciones":
      return allEntityConfigs.Reparaciones.endPoint;
    case "Clientes":
      return allEntityConfigs.Clientes.endPoint;
    case "Naves":
      return allEntityConfigs.Naves.endPoint;
    case "Estancias":
      return allEntityConfigs.Estancias.endPoint;
    case "Reparaciones a Naves":
      return allEntityConfigs.ReparacionesNaves.endPoint;
    default:
      return allEntityConfigs.default.endPoint;
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
    case "Reparaciones":
      return allEntityConfigs.Reparaciones.relations;
    case "Clientes":
      return allEntityConfigs.Clientes.relations;
    case "Naves":
      return allEntityConfigs.Naves.relations;
    case "Estancias":
      return allEntityConfigs.Estancias.relations;
    case "Reparaciones a Naves":
      return allEntityConfigs.ReparacionesNaves.relations;
    default:
      return allEntityConfigs.default.relations;
  }
}
 
