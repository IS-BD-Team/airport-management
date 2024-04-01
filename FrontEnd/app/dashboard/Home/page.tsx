import QueryCard from "./components/QueryCard";

export default function Home() {
  return (
    <div className="grid grid-cols-3 w-full p-5 gap-4">
      <QueryCard
        text="Obtener los nombres y el tipo de los clientes del aeropuerto internacional José Martí que han arribado a la misma en sus propias naves como capitanes. "
        to="http://localhost:5258/dashboard/DataManagementSection?entity=Clientes"
      />
      <QueryCard
        text="Obtener los nombres de los aeropuertos y la cantidad de servicios que brinda cada uno de ellos, para aquéllos que hayan recibido el menor número de naves después del año 2010. "
        to="http://localhost:5258/dashboard/DataManagementSection?entity=Clientes"
      />
      <QueryCard
        text="Obtener el monto promedio por cada uno de los servicios de reparación del aeropuerto internacional José Martí que han sido ineficientes en el último año transcurrido y cuya valoración por los clientes tenga un promedio menor a 5 puntos."
        to="http://localhost:5258/dashboard/DataManagementSection?entity=Clientes"
      />
      <QueryCard
        text="Obtener los nombres y la posición geográfica de los aeropuertos que brinden servicio de reparación a las naves."
        to="http://localhost:5258/dashboard/DataManagementSection?entity=Clientes"
      />
      <QueryCard
        text="Obtener la cantidad de reparaciones capitales que se han realizado en cada aeropuerto."
        to="http://localhost:5258/dashboard/DataManagementSection?entity=Clientes"
      />
      <QueryCard
        text="Obtener los servicios de reparación deficientes."
        to="http://localhost:5258/dashboard/DataManagementSection?entity=Clientes"
      />
    </div>
  );
}
