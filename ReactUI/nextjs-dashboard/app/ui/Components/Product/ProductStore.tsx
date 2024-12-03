"use client";
import { useEffect, useState } from 'react'
import axios from 'axios';
import { IProduct } from '../../Interfaces/Product/IProduct';
import React from 'react';
import { ProductGalleryView } from './ProductView/ProductGallery';
import { ProductTable } from './ProductView/ProductTable';
import { Product } from '../../Types/Product/Product';
import { Card, CardContent, Grid2, Typography } from '@mui/material';
import ProductCreateForm from './Create/ProductCreateForm';
import { ApiConstants } from '../Constants/Constants';

export const ProductStore: React.FC = () => {
    const [products, SetProducts] = useState<Product[]>([]);
    useEffect(() => {
        GetProducts()
    }, []);

    const GetProducts = async () => {
        try {
            const response = await axios.get<IProduct[]>(ApiConstants.ProductBaseUrl);
            if (response.data != null)
                SetProducts(response.data);
        } catch (error) {
            ;
        }
    }

    const CreateProduct = (product: Product) => {
        axios.post(ApiConstants.ProductBaseUrl, product).then(() => {
            GetProducts();
        });
    }

    const EditProduct = (product: Product) => {
        console.log(product);
    }

    return (
        <Grid2 container spacing={3}>
            <Grid2 size={12}>
                <Card>
                    <CardContent>
                        <Typography variant='h3'> Products</Typography>
                    </CardContent>
                </Card>
            </Grid2>
            <Grid2 size={8}>
                <ProductTable products={products} EditFunction={EditProduct} />
            </Grid2>
            <Grid2 size={4}>
                <ProductCreateForm CreateFunction={CreateProduct} />
            </Grid2>
            <Grid2 size={12}>
                <ProductGalleryView products={products} EditFunction={EditProduct} />
            </Grid2>
        </Grid2>
    )
}