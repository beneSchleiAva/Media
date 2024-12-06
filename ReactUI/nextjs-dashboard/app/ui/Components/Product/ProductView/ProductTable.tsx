"use client"
import { Product } from '../../../Types/Product/Product';
import * as React from 'react';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';
import { ProductTableEntryFactory } from '@/app/ui/Types/Product/ProductTableEntryFactory';
import { TableColumns } from '@/app/ui/Types/Product/TableColumns';

export interface ProductTableProperties {
  products: Product[],
  SelectOrderFunction(Products: Product[]): void;
}

export const ProductTable = (props: ProductTableProperties) => {
  const columns: GridColDef[] = TableColumns.GetProductTableColumns();
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
