import React, { Fragment, useState } from 'react';
import './App.css';

import { ProductGalleryView } from '../Product/ProductView/ProductGallery';
import ProductCreateForm from '../Product/Create/ProductCreateForm';
import Grid from '@mui/material/Grid2';
import { Product } from '../../Types/Product/Product';
import axios from 'axios';
import { ProductStore } from '../Product/ProductStore';

class App extends React.Component {
  constructor(props: any) {
    super(props);
  }
  render() {
    return <ProductStore />
  }
}
export default App;
