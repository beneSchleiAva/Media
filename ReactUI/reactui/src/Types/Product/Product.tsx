import {IProduct} from '../../Interfaces/Product/IProduct';
import {ProductPrice} from './ProductPrice';
import {ProductId} from './ProductId';
export class Product implements IProduct{
    "productIdUIDto": ProductId;
    "productPriceUIDto": ProductPrice;
    "name": string;
    "description": string;
}