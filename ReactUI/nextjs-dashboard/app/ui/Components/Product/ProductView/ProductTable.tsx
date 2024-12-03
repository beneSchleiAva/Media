"use client"
import { Product } from '../../../Types/Product/Product';
import * as React from 'react';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';
import { ProductTableEntry } from '@/app/ui/Types/Product/ProductTableEntry';
import { ProductTableEntryFactory } from '@/app/ui/Types/Product/ProductTableEntryFactory';

export interface ProductTableProperties {
  products: Product[],
  EditFunction: (Product: Product) => void;
  SelectOrderFunction(Products: Product[]): void;
}

export const ProductTable = (props: ProductTableProperties) => {

  const columns: GridColDef[] = [
    { field: 'name', headerName: 'Name', width: 200 },
    { field: 'description', headerName: 'Description', width: 200 },
    { field: 'price', headerName: 'Price', width: 200 },
  ];

  const values = props.products.map((product) => {
    return ProductTableEntryFactory.FromProduct(product);
  });

  const paginationModel = { page: 0, pageSize: 20 };
  return (
    < Paper sx={{ width: '100%' }}>
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
          props.SelectOrderFunction(potentialProducts);
        }
        }
        localeText={{
          MuiTablePagination: {
            labelRowsPerPage: 'Zeilen pro Seite',
            labelDisplayedRows: ({ from, to, count }) =>
              `Anzeige der Zeilen ${from} bis ${to} von insgesamt ${count === -1 ? `mehr als ${to} Zeilen` : count} Zeilen`,
          }
        }
        }
      />
    </Paper >
  )
}
