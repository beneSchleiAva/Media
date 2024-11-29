import React from 'react';
import { makeStyles } from '@mui/styles';

import { Product } from '../../../Types/Product/Product';
import Card from '@mui/material/Card';

import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';

export interface ProductProps {
  product: Product
}
const useStyles = makeStyles({
  root: {
    width: 300,
    margin: 10
  },
});


export const ProductView = (props: ProductProps) => {

  const classes = useStyles();

return <Card  className={classes.root}>
    <CardContent>
       <Typography  variant='h3'>
        {props.product.name}
      </Typography>
      <Typography variant="body2" >
        Price: {props.product.productPriceUIDto.value}
      </Typography>
      <Typography variant="body2">Description: {props.product.description}</Typography>
    </CardContent>
  </Card>
}