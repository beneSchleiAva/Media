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
import { OrderProductFactory } from '../../Types/OrderProduct/OrderProductFactory';
import { OrderPosition } from '../../Types/OrderPosition/OrderPosition';
import { Order } from '../../Types/Order/Order';
import { OrderTable } from '../Order/OrderTable';
import axiosRetry from 'axios-retry';
import { OrderProduct } from '../../Types/OrderProduct/OrderProduct';

export const ProductStore: React.FC = () => {
    const [products, SetProducts] = useState<Product[]>([]);
    const [selectedOrderProducts, SetSelectedOrderProducts] = useState<OrderProduct[]>([]);

    axiosRetry(axios, { retries: 3 });
    useEffect(() => {
        GetProducts();
    }, []);

    const GetProducts = async () => {
        try {
            const response = await axios.get<IProduct[]>(ApiConstants.ProductBaseUrl);
            if (response.data != null)
                SetProducts(response.data);
        } catch (error) {
            console.log(error);
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

        const orderPositions = new Array<OrderPosition>();

        orderProducts.forEach(orderProduct => {
            try {
                orderPositions.push({
                    referenceProduct: {
                        value: orderProduct.productIdUIDto.value
                    },
                    referenceBilledProductUnitPrice: {
                        value: orderProduct.productPriceUIDto.value
                    },
                    referenceCurrentProductBookUnitPrice: {
                        value: orderProduct.productPriceUIDto.value
                    }
                    ,
                    referenceOrderDescription: {
                        quantity: orderProduct.Quantity,
                        effectivePrice: orderProduct.EffectivePrice
                    }
                });

                const order: Order = {
                    orderPositions: orderPositions
                }

                axios.post(ApiConstants.OrderBaseUrl, order);

            } catch (error) {
                console.log(error);
            }
        });

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
        </Grid2>
    )
}