type DataManagementProps = {
    section: string;
}

export default function DataManagement(props: DataManagementProps){
    return (
        <main className="w-[85vw]">
            <h1>{props.section}</h1>
            <section>
                Filtros
            </section>
            <section>
                Tabla de datos
                <table>
                    <thead>
                        <tr>
                            <th>Columna 1</th>
                            <th>Columna 2</th>
                            <th>Columna 3</th>
                            <th>Columna 4</th>
                            <th>Columna 5</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Valor 1</td>
                            <td>Valor 2</td>
                            <td>Valor 3</td>
                            <td>Valor 4</td>
                            <td>Valor 5</td>
                        </tr>
                    </tbody>
                </table>
            </section>
        </main>
    );
}