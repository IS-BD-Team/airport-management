'use client'
export default function TopMenu() {
    // Obtener todas las cookies como una cadena de texto
    const cookies = document.cookie;

    // Dividir la cadena en un array de cookies individuales
    const cookiesArray = cookies.split('; ');

    // Buscar una cookie específica por su nombre
    const tokenCookie = cookiesArray.find(cookie => cookie.startsWith('UserEmail='));

    // Extraer el valor de la cookie (si existe)
    const email = tokenCookie ? tokenCookie.split('=')[1] : null;

    return (
        <div className="lg:w-full lg:flex lg:justify-between lg:text-[12px] 
        bg-[#002951] text-white px-2 hidden">

            <ul className="flex flex-row ">
                <li className="mr-2 list-none">
                    <a href="/dashboard/Home">Home</a>
                </li>
                {/* <li className="mr-2 list-none">
                    <a href="/dashboard/DataManagementSection">Data</a>
                </li>
                 <li className="mr-2 list-none">
                    <a href="/">Project</a>
                </li>
                <li className="list-none">
                    <a href="/">Report Server</a>
                </li>  */}
            </ul>
            <div className="flex flex-row ">
                <div className="flex flex-row justify-between">
                    <p className="mr-1.5">
                        Logged in as:
                    </p>
                    <p className="cursor-pointer">
                        {email}
                    </p>
                </div>
                <ul className="flex flex-row">
                    {/* <li className="ml-4 list-none">
                        <a href="/">My Account</a>
                    </li> */}
                    <li className="ml-4 list-none">
                        <a href="/">Sign Out</a>
                    </li>
                </ul>
            </div>
        </div>
    )
}