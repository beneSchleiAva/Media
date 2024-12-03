import { Product } from './Product';
import { OrderProduct } from './OrderProduct';
import { ProductTableEntry } from './ProductTableEntry';
import { ProductId } from './ProductId';
import { ProductPrice } from './ProductPrice';
import { OrderProductTableEntry } from './OrderProductTableEntry';
export class OrderProductFactory {

    static FromProduct(product: Product) {
        var orderProduct = new OrderProduct();
        orderProduct.productIdUIDto = product.productIdUIDto;
        orderProduct.productPriceUIDto = product.productPriceUIDto;
        orderProduct.name = product.name;
        orderProduct.description = product.description;
        orderProduct.quantity = 0;
        return orderProduct;
    }
    static FromOrderProductTableEntry(tableEntry: OrderProductTableEntry) {
        var orderProduct = new OrderProduct();
        orderProduct.productIdUIDto = new ProductId(tableEntry.id);
        orderProduct.productPriceUIDto = new ProductPrice(tableEntry.price);
        orderProduct.name = tableEntry.name;
        orderProduct.description = tableEntry.description;
        orderProduct.quantity = tableEntry.quantity;
        orderProduct.effectivePrice = tableEntry.effectivePrice;
        return orderProduct;
    }

}