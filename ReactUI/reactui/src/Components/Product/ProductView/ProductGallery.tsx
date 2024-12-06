import { useEffect, useState } from 'react'
import Typography from '@mui/material/Typography';
import axios from 'axios';
import { IProduct } from '../../../Interfaces/Product/IProduct';
import { ProductView } from './ProductView';
import { makeStyles } from '@mui/styles';
import { Product } from '../../../Types/Product/Product';

export interface ProductGalleryProps {
  products: Product[]
}

const useStyles = makeStyles({
  root: {
    width: 300,
    margin: 10
  },
});

export const ProductGalleryView = (props: ProductGalleryProps) => {
  const classes = useStyles();
  return <div> <h1 className={classes.root}><Typography>Products</Typography></h1> {props.products.map((product) => { return <ProductView product={product} />; })} </div>

}

