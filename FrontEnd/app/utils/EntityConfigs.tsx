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
          label: "FirstName",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Apellidos",
          label: "LastName",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Super Admin",
          label: "IsSuperAdmin",
          type: "select",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Correo",
          label: "Email",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Contrasena",
          label: "Password",
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
        link: "Aeropuertos,Instalaciones",
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
    tableWidths: ["10%", "20%", "20%", "30%", "10%", "10%"],
  },
  Servicios: {
    formConfig: {
      caption: "Nuevo Servicio",
      icon: servicios,
      inputs: [
        {
          name: "Descripción",
          label: "Description",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Precio",
          label: "Price",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Instalación",
          label: "FacilityId",
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
        name: "Brindado en: Aeropuerto",
        icon: aeropuertos,
        link: "Aeropuertos,Servicios",
      },
      {
        name: "Brindado en: Instalacion",
        icon: instalaciones,
        link: "Instalaciones,Servicios",
      },
    ],
    endPoint: "http://localhost:5258/Services",
    tableWidths: ["10%", "50%", "15%", "15%", "10%"],
  },
  Reparaciones: {
    formConfig: {
      caption: "Nueva Reparación",
      icon: reparaciones,
      inputs: [
        {
          name: "Descripción",
          label: "Description",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Precio",
          label: "Price",
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
          label: "Type",
          type: "text",
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
        name: "Brindado en: Aeropuerto",
        icon: aeropuertos,
        link: "Aeropuertos,Reparaciones",
      },
      {
        name: "Brindado en: Instalacion",
        icon: instalaciones,
        link: "Instalaciones,Reparaciones",
      },
    ],
    endPoint: "http://localhost:5258/RepairServices",
    tableWidths: ["10%", "10%", "50%", "10%", "10%", "10%"],
  },
  Clientes: {
    formConfig: {
      caption: "Nuevo Cliente",
      icon: clientes,
      inputs: [
        {
          name: "Nombre",
          label: "name",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "CI",
          label: "CI",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Nacionalidad",
          label: "country",
          type: "select",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Tipo",
          label: "clientType",
          type: "text",
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
    tableWidths: ["10%", "20%", "15%", "15%", "15%", "15%", "10%"],
  },
  Naves: {
    formConfig: {
      caption: "Nueva Nave",
      icon: aviones,
      inputs: [
        {
          name: "Matrícula",
          label: "planePlate",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Clasificación",
          label: "classification",
          type: "text",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Dueño",
          label: "clientId",
          type: "select",
          options: {
            from: "http://localhost:5258/Clients",
            value: 0,
            name: 1,
          },
        },
        {
          name: "Cant. de Plazas",
          label: "passengersCapacity",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Cant. de Tripulantes",
          label: "crewMembers",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
        
        {
          name: "Capacidad de carga",
          label: "maxLoad",
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
        icon: reparacionesNaves,
        link: "/dashboard/DataManagementSection?entity=Reparaciones a Naves&relation=Naves&id=",
      },
      {
        name: "Estancias",
        icon: estancias,
        link: "/dashboard/DataManagementSection?entity=Estancias&relation=Naves&id=",
      },
      {
        name: "Dueño",
        icon: clientes,
        link: "Clientes,Naves",
      },
    ],
    endPoint: "http://localhost:5258/Airplanes",
    tableWidths: ["10%","20%", "20%", "10%", "10%", "10%", "10%", "10%"],
  },
  Estancias: {
    formConfig: {
      caption: "Nueva Estancia",
      icon: estancias,
      inputs: [
        {
          name: "Fecha de Inicio",
          label: "arrivalDate",
          type: "date",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Fecha Planificad de Fin",
          label: "departureDate",
          type: "date",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Id de Aeropuerto",
          label: "airportId",
          type: "select",
          options: {
            from: "http://localhost:5258/Airports",
            value: 0,
            name: 1,
          },
        },
        {
          name: "Matrícula",
          label: "airplaneId",
          type: "select",
          options: {
            from: "http://localhost:5258/Airplanes",
            value: 0,
            name: 0,
          },
        },
        {
          name: "Valoración",
          label: "rating",
          type: "number",
          options: { from: "", value: 0, name: 0 },
        },
      ],
    },
    relations: [
      {
        name: "Nave",
        icon: aviones,
        link: "Naves,Estancias",
      },
      {
        name: "Aeropuerto",
        icon: aeropuertos,
        link: "Aeropuertos,Estancias",
      },
      {
        name: "Servicios",
        icon: servicios,
        link: "/dashboard/DataManagementSection?entity=Servicios&relation=Estancias&id=",
      },
    ],
    endPoint: "http://localhost:5258/PlaneStay",
    tableWidths: ["15%", "15%", "20%", "20%", "20%", "10%"],
  },
  ReparacionesNaves: {
    formConfig: {
      caption: "Nueva Reparación a Nave",
      icon: reparacionesNaves,
      inputs: [
        {
          name: "Fecha de Inicio",
          label: "startDate",
          type: "date",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Fecha de Fin",
          label: "endDate",
          type: "date",
          options: { from: "", value: 0, name: 0 },
        },
        {
          name: "Matrícula",
          label: "airPlaneId",
          type: "select",
          options: {
            from: "http://localhost:5258/Airplanes",
            value: 0,
            name: 0,
          },
        },
        {
          name: "Código",
          label: "repairServiceId",
          type: "select",
          options: {
            from: "http://localhost:5258/RepairServices",
            value: 0,
            name: 0,
          },
        },
        {
          name: "Tiempo",
          label: "elapsedHours",
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
        link: "Naves,Reparaciones a Naves",
      },
      {
        name: "Reparacion",
        icon: reparaciones,
        link: "Reparaciones,Reparaciones a Naves",
      },
    ],
    endPoint: "http://localhost:5258/AirplaneRepairServices",
    tableWidths: ["5%", "15%", "15%", "20%", "20%", "15%", "10%"],
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
