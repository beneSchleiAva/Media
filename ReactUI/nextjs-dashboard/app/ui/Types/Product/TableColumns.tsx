export class TableColumns {
    static GetOrderTableColumns() {
        return [
            { field: 'name', headerName: 'Name', width: 200 },
            { field: 'description', headerName: 'Description', width: 200 },
            { field: 'price', headerName: 'Price', width: 200 },
            { field: 'quantity', headerName: 'Quantity', width: 200, editable: true },
            { field: 'effectivePrice', headerName: 'EffectivePrice', width: 200, editable: true },
        ];
    }


    static GetOrderPositionTableColumns() {
        return [
            { field: 'ProductId', headerName: 'ProductId', width: 200 },
            { field: 'Price_Sold', headerName: 'Price(sold)', width: 200 },
            { field: 'Price_Book', headerName: 'Price(Book)', width: 200 },
            { field: 'Quantity', headerName: 'Quantity', width: 200,  },
        ];
    }   

    static GetProductTableColumns() {
        return [
            { field: 'id', headerName: 'Id', width: 200 },
            { field: 'name', headerName: 'Name', width: 200 },
            { field: 'description', headerName: 'Description', width: 200 },
            { field: 'price', headerName: 'Price', width: 200 },
        ];;
    }
}  