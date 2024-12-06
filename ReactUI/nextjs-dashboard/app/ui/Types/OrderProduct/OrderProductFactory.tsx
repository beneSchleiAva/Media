import { Product } from '../Product/Product';
import { OrderProduct } from './OrderProduct';
import { ProductTableEntry } from '../Product/ProductTableEntry';
import { ProductId } from '../Product/ProductId';
import { ProductPrice } from '../Product/ProductPrice';
import { OrderProductTableEntry } from './OrderProductTableEntry';
export class OrderProductFactory {

    static FromProduct(product: Product) {
        var orderProduct = new OrderProduct();
        orderProduct.productIdUIDto = product.productIdUIDto;
        orderProduct.productPriceUIDto = product.productPriceUIDto;
        orderProduct.name = product.name;
        orderProduct.description = product.description;
        orderProduct.Quantity = 0;
        return orderProduct;
    }
    static FromOrderProductTableEntry(tableEntry: OrderProductTableEntry) {
        var orderProduct = new OrderProduct();
        orderProduct.productIdUIDto = new ProductId(tableEntry.id);
        orderProduct.productPriceUIDto = new ProductPrice(tableEntry.price);
        orderProduct.name = tableEntry.name;
        orderProduct.description = tableEntry.description;
        orderProduct.Quantity = tableEntry.quantity;
        orderProduct.EffectivePrice = tableEntry.effectivePrice;
        return orderProduct;
    }

}