"use client"
import * as React from 'react';
import { DataGrid } from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';
import { Button, Grid2 } from '@mui/material';
import { OrderProductTableEntryFactory } from '@/app/ui/Types/OrderProduct/OrderProductTableEntryFactory';
import { OrderProductFactory } from '@/app/ui/Types/OrderProduct/OrderProductFactory';
import { OrderProductTableEntry } from '@/app/ui/Types/OrderProduct/OrderProductTableEntry';
import { TableColumns } from '@/app/ui/Types/Product/TableColumns';
import { OrderProduct } from '@/app/ui/Types/OrderProduct/OrderProduct';

export interface OrderSelectionViewProps {
    providedOrderProducts: OrderProduct[],
    CreateFunction: (OrderProducts: OrderProduct[]) => void;
}
export const OrderSelectionView = (props: OrderSelectionViewProps) => {

    const [orderProducts, SetOrderProducts] = React.useState<OrderProductTableEntry[]>([]);
    React.useEffect(() => {
        SetOrderProducts(props.providedOrderProducts.map((providedOrderProduct) => {
            return OrderProductTableEntryFactory.FromOrderProduct(providedOrderProduct);
        }));
    }, [props.providedOrderProducts.length]);

    const columns = TableColumns.GetOrderTableColumns();
    const paginationModel = { page: 0, pageSize: 20 };

    const OnEdit = (newProduct: OrderProductTableEntry) => {
        let tempOrderProducts: Array<OrderProductTableEntry>;

        let index = orderProducts.findIndex((product) => product.id == newProduct.id);
        if (index != -1) {
            {
                tempOrderProducts = orderProducts.map((c, i) => {
                    if (i === index) {
                        return newProduct;
                    } else {
                        return c;
                    }
                });
            }
        } else {
            tempOrderProducts = [...orderProducts, newProduct];
        }
        SetOrderProducts(tempOrderProducts);
        return newProduct;
    }



    return (
        <Paper sx={{ width: '100%' }}>
            <Grid2 container spacing={3}>
                <Grid2 size={12}>
                    <DataGrid
                        rows={orderProducts}
                        editMode="row"
                        columns={columns}
                        initialState={{ pagination: { paginationModel } }}
                        pageSizeOptions={[5, 10, 15, 20]}
                        sx={{ border: 1 }}
                        processRowUpdate={(newRow, oldRow, params) => {
                            return OnEdit(newRow);
                        }}
                        onProcessRowUpdateError={(params) => { console.log(params); }}
                        localeText={{
                            MuiTablePagination: {
                                labelRowsPerPage: 'Zeilen pro Seite',
                                labelDisplayedRows: ({ from, to, count }) =>
                                    `Anzeige der Zeilen ${from} bis ${to} von insgesamt ${count === -1 ? `mehr als ${to} Zeilen` : count} Zeilen`,
                            }
                        }
                        }
                    />
                </Grid2>
                <Grid2 size={12}>
                    <div className="flex justify-end">
                        <Button variant='outlined' onClick={() => {
                            console.log(orderProducts[0]);
                            var products = orderProducts.map((order => OrderProductFactory.FromOrderProductTableEntry(order)));
                            props.CreateFunction(products)
                        }
                        }>Confirm Order</Button>
                    </div>
                </Grid2>
            </Grid2>
        </Paper >
    )
}
