import {
  Estancia,
  Instalacion,
  Instance,
  Nave,
  ReparacionNave,
  Reparcion,
  Servicio,
} from "./types";

export default function getComputedLink(link: string, data: Instance) {
  const words = link.split(",");
  const entity = words[0];
  const relation = words[1];

  console.log(entity + " " + relation)
  console.log(data);

  switch (relation) {
    case "Instalaciones":
      return (
        "/dashboard/InstanceViewSection?entity=Aeropuertos&id=" +
        (data as Instalacion).airportId
      );
    case "Servicios":
      switch (entity) {
        case "Aeropuertos":
          return "/dashboard/InstanceViewSection?entity=Aeropuertos&id=";
        case "Instalaciones":
          return (
            "/dashboard/InstanceViewSection?entity=Instalaciones&id=" +
            (data as Servicio).facilityId
          );
        default:
          break;
      }
    case "Reparaciones":
      switch (entity) {
        case "Aeropuertos":
          return "/dashboard/InstanceViewSection?entity=Aeropuertos&id=";
        case "Instalaciones":
          return (
            "/dashboard/InstanceViewSection?entity=Instalaciones&id=" +
            (data as Reparcion).facilityId
          );
        default:
          break;
      }
    case "Naves":
      return (
        "/dashboard/InstanceViewSection?entity=Clientes&id=" +
        (data as Nave).clientId
      );
    case "Estancias":
      switch (entity) {
        case "Naves":
          return (
            "/dashboard/InstanceViewSection?entity=Naves&id=" +
            (data as Estancia).airplaneId
          );
        case "Aeropuertos":
          return (
            "/dashboard/InstanceViewSection?entity=Aeropuertos&id=" +
            (data as Estancia).airportId
          );
        default:
          break;
      }
    case "Reparaciones a Naves":
      switch (entity) {
        case "Naves":
          return (
            "/dashboard/InstanceViewSection?entity=Naves&id=" +
            (data as ReparacionNave).matricula
          );
        case "Reparaciones":
          return (
            "/dashboard/InstanceViewSection?entity=Reparaciones&id=" +
            (data as ReparacionNave).codigo
          );
        default:
          break;
      }
    default:
        break;
  }
}
