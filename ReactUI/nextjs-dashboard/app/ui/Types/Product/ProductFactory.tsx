import { IProduct } from '../../Interfaces/Product/IProduct';
import { ProductPrice } from './ProductPrice';
import { ProductId } from './ProductId';
import { ProductTableEntry } from './ProductTableEntry';
import { Product } from './Product';
import { table } from 'console';
export class ProductFactory {

    static FromTableEntry(tableEntry: ProductTableEntry) {
        var product = new Product();
        product.productIdUIDto = new ProductId(tableEntry.id);
        product.productPriceUIDto = new ProductPrice(tableEntry.price);
        product.name = tableEntry.name;
        product.description = tableEntry.description;
        return product;
    }
}