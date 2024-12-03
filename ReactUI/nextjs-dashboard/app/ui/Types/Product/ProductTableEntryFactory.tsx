import { ProductPrice } from './ProductPrice';
import { ProductTableEntry } from './ProductTableEntry';
import { Product } from './Product';

export class ProductTableEntryFactory {

    static FromProduct(product: Product) {
        var tableEntry = new ProductTableEntry();
        if (typeof product.productIdUIDto !== undefined)
            tableEntry.id = product.productIdUIDto.value;
        if (typeof product.productPriceUIDto !== undefined)
            tableEntry.price=  product.productPriceUIDto.value;
        if (typeof product.name !== undefined)
            tableEntry.name =product.name;
        if (typeof product.description !== undefined)
            tableEntry.description = product.description;
        return tableEntry;
    }
}