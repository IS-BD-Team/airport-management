import { StaticImageData } from "next/image";

export type Aeropuerto = {
    id: string;
    nombre: string;
    direccion: string;
    posicionGeografica: string;
    picture: StaticImageData;
}
export type Instalacion = {
    ida: string;
    idi: string;
    nombre: string;
    tipo: string;
    ubicacion: string;
    picture: StaticImageData;
}
export type Servicio = {
    id: string;
    descripcion: string;
    precio: number;
    picture: StaticImageData;
}
export type Reparcion = {
    id: string;
    descripcion: string;
    precio: number;
    tipo: string;
    picture: StaticImageData;
}
export type Cliente = {
    id: string;
    nombre: string;
    nacionalidad: string; 
    tipo: string;
    hasNave: boolean;
    picture: StaticImageData;
}
export type Nave = {
    matricula: string;
    plazas: number;
    clasificacion: string; 
    tripulantes: number;
    capacidad: string;
    picture: StaticImageData;
}
export type Estancia = {
    matricula: string;
    fechaInicio: string;
    idA: string;
    valoracion: number;
    fechaPropuestaFin: string;
    picture: StaticImageData;
}
export type ReparacionNave = {
    matricula: string;
    fechaInicio: string;
    codigo: string;
    tiempo: number;
    fechaFin: string;
    picture: StaticImageData;
}
export type TestingType = {
    nombre: string, 
    grupo: string, 
    num: string, 
    description: string, 
    fecha: string,
    picture: StaticImageData,
}
export type Instance = Aeropuerto | Instalacion | Servicio | Reparcion | Cliente | Nave | Estancia | ReparacionNave | TestingType; 