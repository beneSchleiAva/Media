import {IProductId} from '../../Interfaces/Product/IProductId';
export class ProductId implements IProductId{
    value: string;
    constructor(){
        this.value = "";
    }
}