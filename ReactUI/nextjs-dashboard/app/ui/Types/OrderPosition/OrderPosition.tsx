import { OrderProductId } from "../OrderProduct/OrderProductId";
import { OrderBilledProductUnitPrice } from "../Order/OrderBilledProductUnitPrice"
import { OrderCurrentProductUnitPrice } from "../Order/OrderCurrentProductUnitPrice"
import { OrderDescription } from "../Order/OrderDescription"


export type OrderPosition ={
    "referenceProduct": OrderProductId;
    "referenceBilledProductUnitPrice": OrderBilledProductUnitPrice;
    "referenceCurrentProductBookUnitPrice": OrderCurrentProductUnitPrice;
    "referenceOrderDescription": OrderDescription;
}