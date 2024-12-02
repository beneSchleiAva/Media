"use client";
import React from 'react';

import { Product } from '../../../Types/Product/Product';
import Card from '@mui/material/Card';

import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import { ButtonBase } from '@mui/material';

export interface ProductProps {
  product: Product,
  EditFunction: (Product: Product) => void;
}

export const ProductView = (props: ProductProps) => {
  return (
    <div  className="w-9/12 h-full" onClick={() => props.EditFunction(props.product)}>
      <Card>
        <CardContent>
          <Typography variant='body2'>
            {props.product.name}
          </Typography>
          <Typography variant="body2" >
            Price: {props.product.productPriceUIDto.value}
          </Typography>
          <Typography variant="body2">Description: {props.product.description}</Typography>
        </CardContent>
      </Card>
    </div >
  )
}