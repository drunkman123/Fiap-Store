import { Link } from "@remix-run/react"
import { useFormatter } from "../hooks/useFormatter";
import React from "react"

export interface ProductResponse {
  id: number,
  name: string,
  image: string,
  price: number,
  description?: string
}

export function Product({id, name, image, price}: ProductResponse) {
  const { currencyFormat } = useFormatter();

  return (
    <Link to={`/products/${id}`}>
      <div className="m-6 shadow">
        <img src={image} alt={name} className="h-48 w-72 object-cover p-6" />
        <div className="p-4 flex justify-between">
          <p>{name}</p>
          <p className="font-bold">{currencyFormat(price)}</p>
        </div>
        <button className="bg-[#613AD0] text-white min-w-full py-1 flex justify-center">
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="#fff"><path d="M20 3H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V5a2 2 0 0 0-2-2zm-9 14H5v-2h6v2zm8-4H5v-2h14v2zm0-4H5V7h14v2z"></path></svg>
          <p className="ml-2">Ver detalhes</p>
        </button>
      </div>
    </Link>
  )
}