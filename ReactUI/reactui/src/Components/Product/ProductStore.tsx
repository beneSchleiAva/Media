import { useEffect, useState, useContext, createContext } from 'react'
import axios from 'axios';
import { IProduct } from '../../Interfaces/Product/IProduct';
import React from 'react';
import { ProductGalleryView } from './ProductView/ProductGallery';
import { Product } from '../../Types/Product/Product';
import { Grid2 } from '@mui/material';
import ProductCreateForm from './Create/ProductCreateForm';

export const ProductStore: React.FC = () => {

    const [products, SetProducts] = useState<Product[]>([]);

    useEffect(() => {
        const GetProducts = async () => {
            const response = await axios.get<IProduct[]>('https://localhost:7206/Product');
            SetProducts(response.data);
        }
        GetProducts()
    }, [products]);
    const CreateProduct = (product: Product) => {
        axios.post('https://localhost:7206/Product', product);
        console.log(product);
      }
    return (
        <Grid2 container spacing={2}>
            <Grid2 size={8}>
                <ProductGalleryView products={products} />
            </Grid2>
            <Grid2 size={4}>
                <ProductCreateForm CreateFunction={CreateProduct} />
            </Grid2>
        </Grid2>
    )
}