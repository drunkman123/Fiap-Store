import React, { useState } from "react";
import { httpService} from '../services/http-service'
import { useLoaderData } from "@remix-run/react";
import { json, redirect } from "@remix-run/node";

// export const loader = async () => {
//   console.log("Ok")
//   return json({id: 1});
// };

export default function Login() {
  const { post } = httpService();
  const [showError, setShowError] = useState(false);

  const onSubmit = async (e: any) => {
    e.preventDefault();

    let cpf = e.target.cpf.value;
    let password = e.target.password.value;
    let response = await post('api/Login/Autenticar', {cpf, password})

    if (response.ok) {
      let data = await response.json();
      localStorage.setItem('token', data.token);
      localStorage.setItem('name', data.name);
      location.href = '/'
      return;
    }

    setShowError(true);
  }
  
  return (
    <>
      <p className="text-center text-xl pt-10">Fazer Login</p>
      <form method="post" onSubmit={onSubmit} className="flex flex-col items-center mt-6 mb-20 shadow-xl w-80 mx-auto p-10">
        <img src="/logo.png" className="w-full px-10 mb-8" />
        <div className="w-full">
          <label htmlFor="cpf">CPF</label>  
        </div>
        <div className="w-full">
          <input type="text" name="cpf" className="w-full border rounded py-1 px-2" />
        </div>
        <div className="w-full mt-2">
          <label htmlFor="password">Senha</label>  
        </div>
        <div className="w-full">
          <input type="text" name="password" className="w-full border rounded py-1 px-2" />
        </div>
        { showError && <p className="mt-4 text-red-500">Não foi possível efetuar o login, verifique os dados informados</p>}
        <button className="bg-[#613AD0] mt-6 text-white px-4 py-2 rounded">ENTRAR</button>
      </form>
    </>
  )
}
