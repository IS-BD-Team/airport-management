export type Aeropuerto = {
    id: number;
    name: string;
    address: string;
    geographicLocation: string;
    //picture: StaticImageData;
}
export type Instalacion = {
    airportId: number;
    id: number;
    name: string;
    type: string;
    location: string;
   // picture: StaticImageData;
}
export type Servicio = {
    id: number;
    facilityId: number;
    description: string;
    price: number;
   // picture: StaticImageData;
}
export type Reparcion = {
    id: number;
    facilityId: number;
    description: string;
    price: number;
    type: string;
    //picture: StaticImageData;
}
export type Cliente = {
    ci: number;
    name: string;
    country: string; 
    clientType: string;
    hasNave: boolean; //todo: decirle a rafa
    //picture: StaticImageData;
}
export type Nave = {
    id: number;
    clientId: number
    passengersCapacity: number;
    classification: string; 
    crewMembers: number;
    maxLoad: number;
    //picture: StaticImageData;
}
export type Estancia = {
    airplaneId: string;
    arrivalDate: string;
    airportId: string;
    valoracion: number;
    departureDate: string;
    //picture: StaticImageData;
}
export type ReparacionNave = {
    matricula: string;
    fechaInicio: string;
    codigo: string;
    tiempo: number;
    fechaFin: string;
    //picture: StaticImageData;
}
export type TestingType = {
    nombre: string, 
    grupo: string, 
    num: string, 
    description: string, 
    fecha: string,
    //picture: StaticImageData,
}
export type Instance = Aeropuerto | Instalacion | Servicio | Reparcion | Cliente | Nave | Estancia | ReparacionNave | TestingType; 