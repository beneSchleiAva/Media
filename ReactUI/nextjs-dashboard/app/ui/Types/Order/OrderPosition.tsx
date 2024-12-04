import { OrderBilledProductUnitPrice } from "./OrderBilledProductUnitPrice"
import { OrderCurrentProductUnitPrice } from "./OrderCurrentProductUnitPrice"
import { OrderDescription } from "./OrderDescription"
import { OrderProductId } from "./OrderProductId"

export type OrderPosition ={
    "referenceProduct": OrderProductId;
    "referenceBilledProductUnitPrice": OrderBilledProductUnitPrice;
    "referenceCurrentProductBookUnitPrice": OrderCurrentProductUnitPrice;
    "referenceOrderDescription": OrderDescription;
}