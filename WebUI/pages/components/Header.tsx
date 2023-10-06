import { Link } from "@remix-run/react";
import React from "react";
import { useEffect, useState } from 'react'

export function Header() {
  let [userName, setUserName] = useState('Login');

  useEffect(() => {
    setUserName(localStorage.getItem('name') ?? 'Login')
  }, [])

  return (
    <header className="bg-white px-10 py-8 flex items-center justify-between border-b">
      <Link to={'/'}>
        <img src="/logo.png" alt="logo" className="h-16" />
      </Link>
      <div className="flex justify-between w-80">
        <Link to={'/cart'}>
          <button className="bg-[#613AD0] text-white min-w-full py-1 px-4 flex justify-center rounded items-center">
          <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="#fff" viewBox="0 0 24 24"><path d="M21.822 7.431A1 1 0 0 0 21 7H7.333L6.179 4.23A1.994 1.994 0 0 0 4.333 3H2v2h2.333l4.744 11.385A1 1 0 0 0 10 17h8c.417 0 .79-.259.937-.648l3-8a1 1 0 0 0-.115-.921z"></path><circle cx="10.5" cy="19.5" r="1.5"></circle><circle cx="17.5" cy="19.5" r="1.5"></circle></svg>
            <p className="ml-3 text-sm">Carrinho</p>
          </button>
        </Link>
        <Link to={'/login'}>
          <button className="bg-[#613AD0] text-white min-w-full py-1 px-4 flex justify-center items-center rounded">
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="#fff"><path d="M7.5 6.5C7.5 8.981 9.519 11 12 11s4.5-2.019 4.5-4.5S14.481 2 12 2 7.5 4.019 7.5 6.5zM20 21h1v-1c0-3.859-3.141-7-7-7h-4c-3.86 0-7 3.141-7 7v1h17z"></path></svg>          
            <p className="ml-3 text-sm">{userName}</p>
          </button>
        </Link>
      </div>
    </header>
  )
}