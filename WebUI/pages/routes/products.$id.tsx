import { LoaderFunctionArgs } from "@remix-run/node";
import { Link, useLoaderData } from "@remix-run/react";
import React from "react";
import { useFormatter } from "../hooks/useFormatter";

export async function loader({params}: LoaderFunctionArgs) {
  return {id: params.id, name: "Notebook 4GB", image:"/notebook.jpg", price:999.00, description: "Notebook muito bom" };
}

export default function ProductDetails() {
  const data = useLoaderData<typeof loader>();
  const {currencyFormat} = useFormatter();

  return (
    <div className="flex justify-center mt-20 mb-20">
      <div className="w-80 mx-10">
        <img src={data.image} className="w-full" />
      </div>
      <div className="w-96 mx-10">
       <h3 className="text-3xl font-bold text-gray-800">{data.name}</h3>
       <h5 className="text-xl">{data.description}</h5>
       <h5 className="text-5xl mt-6 font-bold text-gray-700">{currencyFormat(data.price)}</h5>
      <button className="bg-[#613AD0] text-white  px-4 py-2 rounded mt-8 flex" onClick={() => alert("Fica pra depois")}>
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="#fff" viewBox="0 0 24 24"><path d="M21.822 7.431A1 1 0 0 0 21 7H7.333L6.179 4.23A1.994 1.994 0 0 0 4.333 3H2v2h2.333l4.744 11.385A1 1 0 0 0 10 17h8c.417 0 .79-.259.937-.648l3-8a1 1 0 0 0-.115-.921z"></path><circle cx="10.5" cy="19.5" r="1.5"></circle><circle cx="17.5" cy="19.5" r="1.5"></circle></svg>
        <p className="ml-2">Adicionar ao carrinho</p>
      </button>
      </div>
    </div>
  )
}