import {IProductPrice} from '../../Interfaces/Product/IProductPrice';
export class ProductPrice implements IProductPrice{
    value: number;
    constructor(value:number){
        this.value = value;
    }

}