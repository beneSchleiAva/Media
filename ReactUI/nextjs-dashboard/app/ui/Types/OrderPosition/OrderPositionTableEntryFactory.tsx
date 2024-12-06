import { OrderPosition } from './OrderPosition';
import { OrderPositionTableEntry } from './OrderPositionTableEntry';

export class OrderPositionTableEntryFactory {

    static FromOrderPosition(orderPosition: OrderPosition) {
        var tableEntry = new OrderPositionTableEntry();
        tableEntry.id = crypto.randomUUID();

        tableEntry.ProductId = orderPosition?.productIdUIDto.value;

        tableEntry.Price_Book = orderPosition.productBookUnitPriceDto.value;

        tableEntry.Price_Sold = orderPosition.orderDescriptionDto.effectivePrice;
        tableEntry.Quantity = orderPosition.orderDescriptionDto.quantity;
        console.log(tableEntry);
        return tableEntry;
    }
}

