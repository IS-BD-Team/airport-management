export type Administradores = {
  id: number;
  FirstName: string;
  LastName: string;
  Email: string;
  Password: string;
  IsSuperAdmin: boolean;
}
export type Aeropuerto = {
  id: number;
  name: string;
  address: string;
  geographicLocation: string;
  //picture: StaticImageData;
};
export type Instalacion = {
  id: number;
  airportId: number;
  name: string;
  type: string;
  location: string;
  // picture: StaticImageData;
};
export type Servicio = {
  id: number;
  facilityId: number;
  description: string;
  price: number;
  // picture: StaticImageData;
};
export type Reparacion = {
  id: number;
  facilityId: number;
  description: string;
  price: number;
  type: string;
  //picture: StaticImageData;
};
export type Cliente = {
  id: number;
  ci: number;
  name: string;
  country: string;
  clientType: string;
   //todo: decirle a rafa
  //picture: StaticImageData;
};
export type Nave = {
  id: number;
  planePlate: string;
  clientId: number;
  passengersCapacity: number;
  classification: string;
  crewMembers: number;
  maxLoad: number;
  //picture: StaticImageData;
};
export type Estancia = {
  airplaneId: string;
  arrivalDate: string;
  airportId: string;
  rating: number;
  departureDate: string;
  //picture: StaticImageData;
};
export type ReparacionNave = {
    airPlaneId: string;
  startDate: string;
  repairServiceId: string;
  elapsedHours: number;
  endDate: string;
  //picture: StaticImageData;
};
export type Instance =
  | Aeropuerto
  | Instalacion
  | Servicio
  | Reparacion
  | Cliente
  | Nave
  | Estancia
  | ReparacionNave;
