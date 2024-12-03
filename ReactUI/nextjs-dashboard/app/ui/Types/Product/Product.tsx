import { IProduct } from '../../Interfaces/Product/IProduct';
import { ProductPrice } from './ProductPrice';
import { ProductId } from './ProductId';
import { ProductTableEntry } from './ProductTableEntry';
export class Product implements IProduct {
    "productIdUIDto": ProductId;
    "productPriceUIDto": ProductPrice;
    "name": string;
    "description": string;
}