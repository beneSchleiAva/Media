import React, { Fragment } from 'react';
import './App.css';

import { ProductGalleryView } from '../Product/ProductView/ProductGallery';
import ProductCreateForm from '../Product/Create/ProductCreateForm';
import Grid from '@mui/material/Grid2';
import { Product } from '../../Types/Product/Product';
import axios from 'axios';

class App extends React.Component {
  constructor(props: any) {
    super(props);
  }

  render() {
    return <Grid container spacing={2}>
      <Grid size={8}>
        <ProductGalleryView />
      </Grid>
      <Grid size={4}>
        <ProductCreateForm CreateFunction={CreateProduct} />
      </Grid>
    </Grid>

  }
}

const CreateProduct = (product: Product) => {
  axios.post('https://localhost:7206/Product', product);
  console.log(product);
}
export default App;
