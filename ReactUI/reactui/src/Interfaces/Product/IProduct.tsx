import { IProductPrice } from "./IProductPrice";
import { IProductId } from "./IProductId";

export interface IProduct {
    "productIdUIDto": IProductId,
    "productPriceUIDto": IProductPrice,
    "name": string,
    "description": string,
}