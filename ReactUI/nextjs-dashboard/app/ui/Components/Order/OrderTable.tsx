"use client"
import * as React from 'react';
import Paper from '@mui/material/Paper';
import { Order } from '../../Types/Order/Order';
import { useEffect, useState } from 'react';
import axios from 'axios';
import { ApiConstants } from '../Constants/Constants';
import { Grid2 } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import { TableColumns } from '../../Types/Product/TableColumns';
import { OrderPositionTableEntryFactory } from '../../Types/OrderPosition/OrderPositionTableEntryFactory';

export interface OrderTableProperties {
  orders: Order[];
}

export const OrderTable = (props: OrderTableProperties) => {

  const columns = [
    { field: 'id', headerName: 'id', width: 200 },
    { field: 'description', headerName: 'description', width: 200 },
  ];

  const data = props.orders.map((order) => {
    return (order.orderPositions.map((orderPosition) => {
      return (
        OrderPositionTableEntryFactory.FromOrderPosition(orderPosition)
      )
    }))
  });

  console.log(data);

  // "": OrderProductId;
  // "": OrderBilledProductUnitPrice;
  // "referenceCurrentProductBookUnitPrice": OrderCurrentProductUnitPrice;
  // "referenceOrderDescription": OrderDescription;
  return (
    < Paper className='mt-5' sx={{ width: '100%' }}>
      {data.map((order, index) => {
    
        return (
          <Paper key={index} sx={{ width: '100%' }}>
            <p>Order {index}</p>
            <Grid2 container spacing={1}>
              <Grid2 size={12}>
                <DataGrid
                  style={{ width: '100%', height: order.length * 50 + 100 }}
                  rows={order}
                  editMode="row"
                  columns={columns}
                  hideFooter
                />
              </Grid2>
            </Grid2>
          </Paper>
        )
      }
      )}
    </Paper >
  )
} 