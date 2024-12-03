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
import { OrderSelectionView } from './OrderSelectionView/OrderSelectionView';
import { OrderProduct } from '../../Types/Product/OrderProduct';
import { OrderProductFactory } from '../../Types/Product/OrderProductFactory';

export const ProductStore: React.FC = () => {
    const [products, SetProducts] = useState<Product[]>([]);
    const [selectedOrderProducts, SetSelectedOrderProducts] = useState<OrderProduct[]>([]);
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

    const EditProduct = (editProduct: Product) => {
        console.log(editProduct);
    }
    const CreateOrder = (orderProducts: OrderProduct[]) => {
        console.log(orderProducts);
    }
    const SelectOrderProducts = (selectedProducts: Product[]) => {
        let orderProducts = selectedProducts.map((product) => {
            return OrderProductFactory.FromProduct(product);
        });
        SetSelectedOrderProducts(orderProducts);

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
            <Grid2 size={5}>
                <ProductTable products={products} EditFunction={EditProduct} SelectOrderFunction={SelectOrderProducts} />
            </Grid2>
            <Grid2 size={7}>
                <Grid2 container spacing={3}>
                    <Grid2 size={12}>
                        <ProductCreateForm CreateFunction={CreateProduct} />
                    </Grid2>
                    <Grid2 size={12}>
                        <OrderSelectionView providedOrderProducts={selectedOrderProducts} CreateFunction={CreateOrder} />
                    </Grid2>
                </Grid2>
            </Grid2>
            <Grid2 size={12}>
                <ProductGalleryView products={products} EditFunction={EditProduct} />
            </Grid2>
        </Grid2>
    )
}