"use client";

import { Instance } from "@/app/utils/types";
import Image from "next/image";
import { useSearchParams } from "next/navigation";
import { useState, useEffect } from "react";
import editar from "@/public/editar.png";
import { useRouter } from "next/navigation";
import {
  getRelations,
  getFormConfigs,
  getEndpoint,
} from "@/app/utils/EntityConfigs";
import mapProps from "@/app/utils/mapProps";
//import dataFormater, {FormatedData} from "@/app/utils/dataFormater";

export default function InstanceViewSection() {
  const [edit, setEdit] = useState(false);

  const searchParams = useSearchParams();
  const entity = searchParams.get("entity");
  const id = searchParams.get("id");
  const router = useRouter();
  const formConfig = getFormConfigs(entity ?? "");

  const [name, setName] = useState("");
  const [data, setData] = useState<Instance>({
    id: 0,
    name: "",
    address: "",
    geographicLocation: "",
    //picture: havana,
  });
  //const [formatedData, setFormatedData] = useState<FormatedData>();

  const getAirport = async () => {
    try {
      const response = await fetch(`${getEndpoint(entity ?? "")}/${id}`, {
        method: "GET",
        headers: {
          Authorization: "Bearer " + localStorage.getItem("token"),
        },
      });
      console.log(response);
      return response.json();
    } catch (err) {
      console.log(err);
    }
  };

  const editAirport = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    console.log(event.currentTarget);
    const name = event.currentTarget["name"];
    const address = event.currentTarget["address"];
    const geographicLocation = event.currentTarget["geographicLocation"];

    const response = await fetch(`${getEndpoint(entity ?? "")}/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + localStorage.getItem("token"),
      },
      body: JSON.stringify({ name, address, geographicLocation }),
    });
    router.push("/dashboard/DataManagementSection");
  };

  const getAirportData = async () => {
    const response = await getAirport();
    /*console.log("setData")
        console.log(response);*/
    setData(response);
    console.log(response);
  };

  useEffect(() => {
    getAirportData();
    setData({ ...data /*, picture: havana */ });
    //setFormatedData(dataFormater(data, entity ?? ""));
    //console.log("formated: ", formatedData);
  }, []);
  
  const instance: Instance = {
    id: 1,
    name: "Aeropuerto José Martí",
    address: "Boyeros, Herradura",
    geographicLocation: "222.1w 212.2n",
    // picture: havana,
  };

  return (
    <div className="overflow-y-auto">
      <header className="w-full h-[10vw] bg-gray-700 text-white text-2xl text-center relative">
        <Image
          src={formConfig.icon}
          alt=""
          className={`w-full h-full p-2 absolute z-0 object-contain`}
        />
        {data != null && (
          <h1 className="h-full flex items-center justify-around z-10 relative bg-slate-900 bg-opacity-40">
            {name}
          </h1>
        )}
      </header>
      <button
        className="p-2 h-10 w-10 float-right hover:animate-pulse"
        onClick={() => setEdit(!edit)}
      >
        <Image src={editar} alt="editar_icon"></Image>
      </button>
      {data != null && !edit && (
        <main className="m-5">
          {Object.entries(data).map((value, index) => {
            if (value[0] !== "picture") {
              return (
                <section key={index}>
                  <h2 className="text-2xl capitalize border-b-[2px] border-solid border-[#e3e5ec] mb-5">
                    {mapProps(value[0].toString())}
                  </h2>
                  <p className="mb-3">{value[1] ===null? '': mapProps(value[1].toString())}</p>
                </section>
              );
            }
          })}
        </main>
      )}
      {data != null && edit && (
        <form
          action="none"
          onSubmit={(e) => {
            setEdit(!edit);
            editAirport(e);
          }}
          className="flex flex-col m-5"
        >
          {Object.entries(data).map((value, index) => {
            if (value[0] !== "picture") {
              return (
                <>
                  <label
                    className="text-2xl capitalize border-b-[2px] border-solid border-[#e3e5ec] mb-2"
                    htmlFor={value[0]}
                  >
                    {mapProps(value[0])}
                  </label>
                  <input
                    className="border-[2px] border-solid rounded-lg border-[#e3e5ec] mb-1 p-3"
                    name={value[0]}
                    defaultValue={value[1] ===null? '': value[1].toString()}
                    type="text"
                  />
                </>
              );
            }
          })}
          <button
            type="submit"
            className="bg-[#005b7f] text-white rounded-lg p-2 mt-6 w-[10%] self-end"
          >
            Guardar
          </button>
        </form>
      )}
      <hr />
      {entity != null && (
        <section className="m-5">
          <h2 className="text-2xl capitalize mb-1">Relaciones de interes</h2>
          <div className="flex gap-2">
            {getRelations(entity).map((relation, index) => {
              return (
                <button
                  key={index}
                  className="flex bg-[#005b7f] text-white rounded-lg p-2 mt-6"
                >
                  {relation.name}{" "}
                  {relation.icon != null && (
                    <Image
                      className="ml-4 h-6 w-6 invert"
                      src={relation.icon}
                      alt="ralation_icon"
                    />
                  )}
                </button>
              );
            })}
          </div>
        </section>
      )}
    </div>
  );
}
