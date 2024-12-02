"use client";
import * as React from 'react';
import { useForm, Controller } from 'react-hook-form';
import { TextField, Button, Card, CardHeader, CardContent } from '@mui/material';
import { Product } from '../../../Types/Product/Product';

export interface ProductCreateFunctionalityProps {
  CreateFunction: (Product: Product) => void;
}

export const ProductCreateForm: React.FC<ProductCreateFunctionalityProps> = (props: ProductCreateFunctionalityProps) => {
  const { control, handleSubmit, reset } = useForm<Product>();
  const onSubmit = (data: Product) => {
    props.CreateFunction(data);
reset();
  };

  return (
    <Card>
      <CardHeader title="Create a Product" />
      <CardContent>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Controller
            name="name"
            control={control}
            
                        defaultValue=""
            render={({ field }) => (
              <TextField {...field} label="Name of the Product" variant="outlined" fullWidth margin="normal" />
            )}
          />
          <Controller
            name="description"
            control={control}
            defaultValue=""
            render={({ field }) => (
              <TextField {...field} label="Description of the Product" variant="outlined" fullWidth margin="normal" />
            )}
          />
          <Controller
            name="productPriceUIDto.value"
            control={control}
            defaultValue={0}
            render={({ field }) => (
              <TextField {...field} type='number' label="Price  of the Product" variant="outlined" fullWidth margin="normal" />
            )}
          />
          <Button type="submit" variant="contained" color="primary">
            Create
          </Button>
        </form>
      </CardContent>
    </Card>
  );
};

export default ProductCreateForm;