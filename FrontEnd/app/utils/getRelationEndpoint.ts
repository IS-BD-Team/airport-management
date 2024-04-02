var relationsEndpoints = new Map();
relationsEndpoints.set('Administradores', new Map());

relationsEndpoints.set('Aeropuertos', new Map());
relationsEndpoints.get('Aeropuertos').set('Instalaciones', 'Facilities?$filter=AirportId eq ');
relationsEndpoints.get('Aeropuertos').set('Servicios', '/Airports?$expand=Facilities');
relationsEndpoints.get('Aeropuertos').set('Reparaciones', '/aeropuertos/reparaciones');
relationsEndpoints.get('Aeropuertos').set('Estancias', 'Stays?$filter=AirportId eq ');
relationsEndpoints.get('Aeropuertos').set('Clientes con naves', '/aeropuertos/naves');

relationsEndpoints.set('Instalaciones', new Map());
relationsEndpoints.get('Instalaciones').set('Servicios', 'Services?$filter=facilityID eq ');
relationsEndpoints.get('Instalaciones').set('Reparaciones', 'RepairServices?$filter=facilityID eq ');

relationsEndpoints.set('Servicios', new Map());
relationsEndpoints.get('Servicios').set('Naves', '/servicios/aeropuertos');

relationsEndpoints.set('Reparaciones', new Map());
relationsEndpoints.get('Reparaciones').set('Naves', '/reparaciones/nave');

relationsEndpoints.set('Clientes', new Map());
relationsEndpoints.get('Clientes').set('Naves', 'Airplanes?$filter=clientID eq ');

relationsEndpoints.set('Naves', new Map());
relationsEndpoints.get('Naves').set('Servicios', '/naves/clientes');
relationsEndpoints.get('Naves').set('Reparaciones a Naves', 'AirplaneRepairServices?$filter=AirplaneID eq ');
relationsEndpoints.get('Naves').set('Estancias', 'Stays?$filter=AirportID eq ');

relationsEndpoints.set('Estancias', new Map());
relationsEndpoints.get('Estancias').set('Servicios', '/estancias/clientes');

relationsEndpoints.set('Reparaciones a Naves', new Map());
relationsEndpoints.get('Reparaciones a Naves').set('Reparaciones', '');

export default function getRelationEndpoint(entity: string, relation: string, id: string): string {
    return relationsEndpoints.get(entity).get(relation) + + id;
}