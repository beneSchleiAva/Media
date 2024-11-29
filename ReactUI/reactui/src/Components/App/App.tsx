import React from 'react';
import './App.css';

import { ProductGalleryView } from '../Product/ProductView/ProductGallery';

class App extends React.Component {
  constructor(props: any) {
    super(props);
  }

  render() {
    return      <ProductGalleryView />

  }
}

export default App;
