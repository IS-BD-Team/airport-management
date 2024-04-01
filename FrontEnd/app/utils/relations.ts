var relationsEndpoints = new Map();
relationsEndpoints.set('Administradores', new Map());

relationsEndpoints.set('Aeropuertos', new Map());
relationsEndpoints.get('Aeropuertos').set('Instalaciones', '/facilities?filter=airportId = ');
relationsEndpoints.get('Aeropuertos').set('Servicios', '/aeropuertos/servicios');
relationsEndpoints.get('Aeropuertos').set('Reparaciones', '/aeropuertos/reparaciones');
relationsEndpoints.get('Aeropuertos').set('Estancias', '/aeropuertos/clientes');
relationsEndpoints.get('Aeropuertos').set('Clientes con naves', '/aeropuertos/naves');

relationsEndpoints.set('Instalaciones', new Map());
relationsEndpoints.get('Instalaciones').set('Aeropuertos', '/instalaciones/aeropuertos');
relationsEndpoints.get('Instalaciones').set('Servicios', '/instalaciones/servicios');
relationsEndpoints.get('Instalaciones').set('Reparaciones', '/instalaciones/reparaciones');

relationsEndpoints.set('Servicios', new Map());
relationsEndpoints.get('Servicios').set('Naves', '/servicios/aeropuertos');
relationsEndpoints.get('Servicios').set('Aeropuertos', '/servicios/aeropuertos');
relationsEndpoints.get('Servicios').set('Instalaciones', '/servicios/instalaciones');

relationsEndpoints.set('Reparaciones', new Map());
relationsEndpoints.get('Reparaciones').set('Naves', '/reparaciones/nave');
relationsEndpoints.get('Reparaciones').set('Aeropuertos', '/reparaciones/aeropuertos');
relationsEndpoints.get('Reparaciones').set('Instalaciones', '/reparaciones/instalaciones');

relationsEndpoints.set('Clientes', new Map());
relationsEndpoints.get('Clientes').set('Naves', '/clientes/naves');

relationsEndpoints.set('Naves', new Map());
relationsEndpoints.get('Naves').set('Servicios', '/naves/clientes');
relationsEndpoints.get('Naves').set('Reparaciones', '/naves/clientes');
relationsEndpoints.get('Naves').set('Estancias', '/naves/clientes');

relationsEndpoints.set('Estancias', new Map());
relationsEndpoints.get('Estancias').set('Servicios', '/estancias/clientes');

relationsEndpoints.set('Reparaciones a Naves', new Map());
relationsEndpoints.get('Reparaciones a Naves').set('Reparaciones', '/reparacionesNaves/naves');

export default function getRelationEndpoint(entity: string, relation: string, id: string): string {
    return relationsEndpoints.get(entity).get(relation) + + id;
}