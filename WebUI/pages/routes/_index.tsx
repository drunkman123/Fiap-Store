import type { MetaFunction } from "@remix-run/node";
import React from "react";
import { Product } from "../components/Product";

export const meta: MetaFunction = () => {
  return [
    { title: "New Remix App" },
    { name: "description", content: "Welcome to Remix!" },
  ];
};

export default function Index() {
  return (
    <div>
      <div>
        <img src="/bg.jpeg" alt="Ecommerce" className="h-96 w-full object-fill" />
      </div>
      <div className="mt-8 flex flex-wrap justify-around max-w-[1030px] mx-auto">
        <Product id={1} name="Notebook 4GB" image="notebook.jpg" price={999.00} />
        <Product id={1} name="Notebook 4GB" image="notebook.jpg" price={750.00} />
        <Product id={1} name="Notebook 4GB" image="notebook.jpg" price={600.00} />
        <Product id={1} name="Notebook 4GB" image="notebook.jpg" price={999.00} />
        <Product id={1} name="Notebook 4GB" image="notebook.jpg" price={750.00} />
        <Product id={1} name="Notebook 4GB" image="notebook.jpg" price={600.00} />
      </div>
    </div>
  );
}
