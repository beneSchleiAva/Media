import React from 'react';
import { useEffect, useState } from 'react'

import { Product } from '../../../Types/Product/Product';
import Card from '@mui/material/Card';

import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import axios from 'axios';
import { IProduct } from '../../../Interfaces/Product/IProduct';
import { ProductView } from './ProductView';
import { Box } from '@mui/material';
import { makeStyles } from '@mui/styles';
const useStyles = makeStyles({
  root: {
    width: 300,
    margin: 10
  },
});


export const ProductGalleryView = () => {
  const [products, SetProducts] = useState<IProduct[]>([]);
  const classes = useStyles();
  useEffect(() => {
    const GetProducts = async () => {
      const response = await axios.get<IProduct[]>('https://localhost:7206/Product');
      SetProducts(response.data);
    }
    GetProducts()
  }, [])

  return <div> <h1 className={classes.root}><Typography>Products</Typography></h1> {products.map((product) => { return <ProductView product={product} />; })} </div>

}

