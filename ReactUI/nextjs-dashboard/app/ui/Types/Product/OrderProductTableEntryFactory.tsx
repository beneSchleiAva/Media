import { OrderProduct } from './OrderProduct';
import { OrderProductTableEntry } from './OrderProductTableEntry';
import { Product } from './Product';

export class OrderProductTableEntryFactory {

    static FromOrderProduct(orderProduct: OrderProduct) {
        var tableEntry = new OrderProductTableEntry();
        if (typeof orderProduct.productIdUIDto !== undefined)
            tableEntry.id = orderProduct.productIdUIDto.value;
        if (typeof orderProduct.productPriceUIDto !== undefined)
            tableEntry.price = orderProduct.productPriceUIDto.value;
        if (typeof orderProduct.name !== undefined)
            tableEntry.name = orderProduct.name;
        if (typeof orderProduct.description !== undefined)
            tableEntry.description = orderProduct.description;
        if (typeof orderProduct.Quantity !== undefined)
            tableEntry.quantity = orderProduct.Quantity;
        if (typeof orderProduct.EffectivePrice !== undefined)
            tableEntry.effectivePrice = orderProduct.EffectivePrice;
        return tableEntry;
    }

    static FromProduct(product: Product) {
        var tableEntry = new OrderProductTableEntry();
        if (typeof product.productIdUIDto !== undefined)
            tableEntry.id = product.productIdUIDto.value;
        if (typeof product.productPriceUIDto !== undefined)
            tableEntry.price = product.productPriceUIDto.value;
        if (typeof product.name !== undefined)
            tableEntry.name = product.name;
        if (typeof product.description !== undefined)
            tableEntry.description = product.description;
        tableEntry.quantity = 0;
        tableEntry.effectivePrice = 0;
        return tableEntry;
    }
}