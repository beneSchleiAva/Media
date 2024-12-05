"use client";
import { useEffect, useState } from 'react'
import axios from 'axios';
import { IProduct } from '../../Interfaces/Product/IProduct';
import React from 'react';
import { Product } from '../../Types/Product/Product';
import { Card, CardContent, Grid2, Typography } from '@mui/material';
import { ApiConstants } from '../Constants/Constants';
import { Order } from '../../Types/Order/Order';
import { OrderTable } from './OrderTable';
import axiosRetry from 'axios-retry';


export const OrderStore: React.FC = () => {
    const [orders, SetOrders] = useState<Order[]>([]);

    axiosRetry(axios, { retries: 3 });
    useEffect(() => {
        GetOrders();
    }, []);

    const GetOrders = async () => {
        try {
            const response = await axios.get<Order[]>(ApiConstants.OrderBaseUrl);

            if (response.data != null) {
                console.log(response.data);
                SetOrders(response.data);
            }
        }
        catch (error) {
            console.log(error);
        }
    }
    return (

        <OrderTable orders={orders} />

    )
}