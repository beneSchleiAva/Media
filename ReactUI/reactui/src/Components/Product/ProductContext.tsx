import { createContext } from "react";
import { Product } from "../../Types/Product/Product";

export type ProductContextType = {
    products: Product[];
}

const initialProductContext: ProductContextType = {
    products: []
}

export const ProductContext = createContext(initialProductContext);
