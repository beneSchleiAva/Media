import { ProductPrice } from '../Product/ProductPrice';
import { ProductTableEntry } from '../Product/ProductTableEntry';
import { Product } from '../Product/Product';
import { OrderPosition } from './OrderPosition';
import { OrderTable } from '../../Components/Order/OrderTable';
import { OrderPositionTableEntry } from './OrderPositionTableEntry';
import { table } from 'console';

export class OrderPositionTableEntryFactory {

    static FromOrderPosition(orderPosition: OrderPosition) {
        var tableEntry = new OrderPositionTableEntry();
        tableEntry.id= crypto.randomUUID();
        tableEntry.description = orderPosition.referenceProduct.value;
        return tableEntry;
    }
}