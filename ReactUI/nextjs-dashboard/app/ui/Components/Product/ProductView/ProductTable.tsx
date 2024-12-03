"use client"
import { Product } from '../../../Types/Product/Product';
import * as React from 'react';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';

export interface ProductTableProperties {
  products: Product[],
  EditFunction: (Product: Product) => void;
}

export const ProductTable = (props: ProductTableProperties) => {
  const [selectedProducts, setSelectedProducts] = React.useState<Product[]>([])

  const columns: GridColDef[] = [
    { field: 'name', headerName: 'Name', width: 200 },
    { field: 'description', headerName: 'Description', width: 200 },
    { field: 'price', headerName: 'Price', width: 200 },
  ];

  const values = props.products.map((product) => {
    let id: string = "";
    let formattedPrice: string = "";
    if (product.productIdUIDto != null) { id = product.productIdUIDto.value; };
    if (product.productPriceUIDto != null) {
      formattedPrice = new Intl.NumberFormat('de-DE', { style: 'currency', currency: 'EUR' }).format(
        product.productPriceUIDto.value
      )
    };
    return {
      id: id,
      name: product.name,
      description: product.description,
      price: formattedPrice
    }
  });
  const paginationModel = { page: 0, pageSize: 20 };
  return (
    < Paper sx={{ width: '100%' }}>
      <div>
        {selectedProducts.map((product) => { return product.productIdUIDto.value })}
      </div>
      <DataGrid
        rows={values}
        columns={columns}
        initialState={{ pagination: { paginationModel } }}
        pageSizeOptions={[5, 10, 15, 20]}
        checkboxSelection
        sx={{ border: 1 }}
        onRowSelectionModelChange={(selectedIds) => {
          let potentialProducts = new Array<Product>();
          selectedIds.forEach(id => {
            var potentialMatch = props.products.filter(p => p.productIdUIDto.value == id.toString());
            if (potentialMatch.length == 1) {
              potentialProducts.push(potentialMatch[0]);
            }
          });
          setSelectedProducts(potentialProducts);
        }
        }
      />
    </Paper >
  )
}
