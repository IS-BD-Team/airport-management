"use client";
import { useState } from "react";
import { usePathname, useRouter } from "next/navigation";

export default function Header() {
    const [showDropDown, SetDropdown] = useState(false);
    const path = usePathname();
    const router = useRouter();
    // Obtener todas las cookies como una cadena de texto
    const cookies = document.cookie;

    // Dividir la cadena en un array de cookies individuales
    const cookiesArray = cookies.split("; ");

    // Buscar una cookie específica por su nombre
    const emailCookie = cookiesArray.find((cookie) =>
        cookie.startsWith("UserEmail=")
    );
    const nameCookie = cookiesArray.find((cookie) =>
        cookie.startsWith("UserName=")
    );

    // Extraer el valor de la cookie (si existe)
    const email = emailCookie ? emailCookie.split("=")[1] : null;
    const name = nameCookie ? nameCookie.split("=")[1] : null;
    const initial = name ? name[0] : "";
    const logout = () => {
        document.cookie =
            "UserName" + "=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/";
        document.cookie =
            "UserEmail" + "=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/";
        document.cookie =
            "UserToken" + "=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/";
        router.push("/login");
    };

    return (
        <div
            className="lg:w-full lg:flex lg:justify-between hidden pl-3 py-3 h-12 align-middle
        text-white bg-[#005b7f]"
        >
            <div className="text-xl">Aeropuertos</div>
            <div className="flex flex-row">
                {/* <label htmlFor="search">Search:</label>
                <input type="text" name="search" className="mr-2" /> */}
                {!path.includes("login") && (
                    <div className="relative animate-bounce w-6 h-6 mr-4 hover:animate-none z-50">
                        <div
                            onClick={() => {
                                SetDropdown(!showDropDown);
                            }}
                            className="cursor-pointer bg-blue-500 text-black rounded-[9999px] w-6 h-6 text-center"
                        >
                            {initial}
                        </div>
                        {showDropDown && (
                            <div
                                className="absolute min-w-[300px] float-right right-0 top-[31px]  p-2 rounded-lg dropdownShadow
                bg-white text-black flex flex-col"
                            >
                                {/* <div className="p-2 border-b border-b-slate-500">
                            <input type="text" name="q" id="projects-quick-search" 
                            className="border border-slate-500 w-full"/>                        
                        </div> */}
                                <div className="flex flex-col p-2 rounded-lg">
                                    <p className="hover:bg-slate-300"/*border-b border-b-slate-500"*/>
                                        Name: {name}
                                    </p>
                                    <p className="hover:bg-slate-300" /*border-b border-b-slate-500"*/>
                                        Email: {email}
                                    </p>
                                    <button
                                        className="hover:bg-slate-300 bg-[#005b7f] text-white mt-2 rounded-lg" 
                                        onClick={() => logout()}
                                    >
                                        Logout
                                    </button>
                                </div>
                                {/* <div className="p-2 border-b border-b-slate-500">
                            <a href="/" className="dropdownLinks"><strong>All Projects</strong></a>
                        </div> */}
                            </div>
                        )}
                    </div>
                )}
            </div>
        </div>
    );
}
