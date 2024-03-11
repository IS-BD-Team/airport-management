export type Aeropuerto = {
    id: string;
    nombre: string;
    direccion: string;
    posicionGeografica: string;
}
export type Instalacion = {
    ida: string;
    idi: string;
    nombre: string;
    tipo: string;
    ubicacion: string;
}
export type Servicio = {
    id: string;
    descripcion: string;
    precio: number;
}
export type Reparcion = {
    id: string;
    descripcion: string;
    precio: number;
    tipo: string;
}
export type Cliente = {
    id: string;
    nombre: string;
    nacionalidad: string; 
    tipo: string;
    hasNave: boolean;
}
export type Nave = {
    matricula: string;
    plazas: number;
    clasificacion: string; 
    tripulantes: number;
    capacidad: string;
}

export type TestingType = {
    nombre: string, 
    grupo: string, 
    num: string, 
    description: string, 
    fecha: string,
}
export type Instance = Aeropuerto | Instalacion | Servicio | Reparcion | Cliente | Nave; 