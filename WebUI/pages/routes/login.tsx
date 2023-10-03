import React from "react";

export default function Login() {
  return (
    <>
      <p className="text-center text-xl pt-10">Fazer Login</p>
      <form method="post" className="flex flex-col items-center mt-6 mb-20 shadow-xl w-80 mx-auto p-10">
      <img src="/logo.png" className="w-full px-10 mb-8" />
      <div className="w-full">
        <label htmlFor="cpf">CPF</label>  
      </div>
      <div className="w-full">
        <input type="text" name="cpf" className="w-full border rounded py-1 px-2" />
      </div>
      <div className="w-full mt-2">
        <label htmlFor="passoword">Senha</label>  
      </div>
      <div className="w-full">
        <input type="text" name="password" className="w-full border rounded py-1 px-2" />
      </div>
      <button className="bg-[#613AD0] mt-6 text-white px-4 py-2 rounded">ENTRAR</button>
    </form>
    </>
  )
}