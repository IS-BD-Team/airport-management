export default function mapProps(field:string) {
     switch (field) {
        case 'name':
            return 'Nombre';
        case 'address':
            return 'Dirección';
        case 'geographicLocation':
            return 'Posición Geográfica';
        case 'type':
            return 'Tipo';
        case 'location':
            return 'Ubicación';
        case 'description':
            return 'Descripción';
        case 'price':
            return 'Precio';
        case 'country':
            return 'Pais';
        case 'clientType':
            return 'Tipo de cliente';
        case 'hasNave':
            return 'Tiene nave';
        case 'passengersCapacity':
            return 'Capacidad de pasajeros';
        case 'classification':
            return 'Clasificación';
        case 'crewMembers':
            return 'Número de tripulantes';
        case 'maxLoad':
            return 'Carga maxima';
        case 'matricula':
            return 'Matricula';
        case 'fechaInicio':
            return 'Fecha de inicio';
        case 'valoracion':
            return 'Valoración';
        case 'fechaPropuestaFin':
            return 'Fecha propuesta de fin';
        case 'matrícula':
            return 'Matrícula';
        case 'codigo':
            return 'Código';
        case 'fechaDeInicio':
            return 'Fecha de inicio';
        case 'fechaDeFin':
            return 'Fecha de fin';
        case 'tiempo':
            return 'Tiempo';     
        case 'id':
            return 'Id';
        case 'airportId':
            return 'ID de aeropuerto';
        case 'facilityId':
            return 'ID de instalación';
        case 'services':
            return 'Servicios';
        case 'serviceId':
            return 'ID de servicio';
        case 'facility':
            return 'Instalación';
        case 'planePlate':
            return 'Placa del avión';
        case 'clientId':
            return 'ID de cliente';
        case 'hasReceivedMaintenance':
            return 'Tiene mantenimiento';
        case 'client':
            return 'Cliente';
        case 'arrivalRole':
            return 'Rol de llegada';
        case 'airPlaneId':
            return 'ID de avión';
        case 'repairServiceId':
            return 'ID de servicio de reparación';
        case 'startDate':
            return 'Fecha de inicio';
        case 'endDate':
            return 'Fecha de fin';
        case 'elapsedHours':
            return 'Horas transcurridas';
        default:
            return field;
            break;
     }
}