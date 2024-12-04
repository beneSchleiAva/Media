import { OrderBilledProductUnitPrice } from "./OrderBilledProductUnitPrice"
import { OrderCurrentProductUnitPrice } from "./OrderCurrentProductUnitPrice"
import { OrderDescription } from "./OrderDescription"
import { OrderPosition } from "./OrderPosition"
import { OrderProductId } from "./OrderProductId"

export type Order ={
    "orderPositions": OrderPosition[];
}