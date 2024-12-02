import React from "react";
import { render } from "@testing-library/react";
import { ProductGalleryView } from "../ui/Components/Product/ProductView/ProductGallery";
import { Product } from "../ui/Types/Product/Product";

describe("Gallery View", () => {
    it("should render all products to view", () => {
        let products: Product[] = []
        let p: Product = new Product();
        p["name"] ="Product 1";

        products.push(p);

        const { container } = render(<ProductGalleryView products={products} EditFunction={()=>{}} />);
    })
});