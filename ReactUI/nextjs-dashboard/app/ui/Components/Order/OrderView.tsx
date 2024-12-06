"use client"
import Paper from '@mui/material/Paper';
import { Order } from '../../Types/Order/Order';
import { CardContent } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import { TableColumns } from '../../Types/Product/TableColumns';
import { OrderPositionTableEntryFactory } from '../../Types/OrderPosition/OrderPositionTableEntryFactory';

export interface OrderViewProperties {
    order: Order;
}

export const OrderView = (props: OrderViewProperties) => {

    const columns = TableColumns.GetOrderPositionTableColumns();

    const data = props.order.orderPositions.map((orderPosition) => {
        return (
            OrderPositionTableEntryFactory.FromOrderPosition(orderPosition)
        );
    });

    return (

        <Paper>
            <CardContent>
                    <DataGrid
                        style={{ minWidth:"100px", width: '100%', height: props.order.orderPositions.length * 50 + 100 }}
                        rows={data}
                        editMode="row"
                        columns={columns}
                        hideFooter
                    />
            </CardContent>
        </Paper>
    )
} 