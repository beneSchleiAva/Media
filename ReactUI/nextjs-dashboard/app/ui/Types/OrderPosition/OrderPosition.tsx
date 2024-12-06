import { OrderCurrentProductUnitPrice } from "../Order/OrderCurrentProductUnitPrice";
import { OrderDescription } from "../Order/OrderDescription";
import { ProductId } from "../Product/ProductId";

export type OrderPosition ={
    "productIdUIDto": ProductId;
    "productBookUnitPriceDto": OrderCurrentProductUnitPrice;
    "orderDescriptionDto": OrderDescription;
}