"use client"
import Paper from '@mui/material/Paper';
import { Order } from '../../Types/Order/Order';
import { Grid2 } from '@mui/material';
import { OrderView } from './OrderView';

export interface OrderTableProperties {
  orders: Order[];
}

export const OrderTable = (props: OrderTableProperties) => {
  return (
    <Paper className='mt-5' sx={{ width: '100%' }}>
      <Grid2 container spacing={2} >
        {props.orders.map((order) => {
          return (
            <div key={crypto.randomUUID()}>
              <OrderView order={order} />
            </div>
          );
        })}
      </Grid2>
    </Paper >
  )
}