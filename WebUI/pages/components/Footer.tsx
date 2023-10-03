import React from "react";

export function Footer() {
  return (
    <footer className="border-t w-full p-8 mt-6 flex justify-between">
        <p>&copy; FIAP STORE {new Date().getFullYear()}</p>
        <p>Made with &#9829; using .NET and React</p>
    </footer>
  )
}