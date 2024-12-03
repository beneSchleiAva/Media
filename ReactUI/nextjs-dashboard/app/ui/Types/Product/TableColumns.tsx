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
}