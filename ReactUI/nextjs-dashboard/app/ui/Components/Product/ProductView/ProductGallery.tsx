"use client"
import { ProductView } from './ProductView';
import { Product } from '../../../Types/Product/Product';
import React from 'react';
import { Card, CardContent, Typography } from '@mui/material';

export interface ProductGalleryProps {
  products: Product[],
  EditFunction: (Product: Product) => void;
}

export const ProductGalleryView = (props: ProductGalleryProps) => {
  return (
    <div className="mt-4 grid grid-cols-1 gap-1">
      {props.products.map((product) => { return <div key={product.productIdUIDto.value}><ProductView product={product} EditFunction={props.EditFunction} /></div>; })}
    </div>
  )
}

