SQLDBNAME = DBCRUDDEMO

Routes:

Get All Products: https://localhost:7043/api/Products/getAllProducts

Get Product By Id: 'https://localhost:7043/api/Products/getProductById/{id}'

Add New Product: 'https://localhost:7043/api/Products/addProduct' { "nombre": "", "detalles": "", "precio": 0, "cantidad": 0 }

Update Product: 'https://localhost:7043/api/Products/updateProduct/{id}' { "nombre": "", "detalles": "", "precio": 0, "cantidad": 0 }

Sell Product: 'https://localhost:7043/api/Products/sellProduct/{id}' { "cantidad": 0 }

Delete Product: 'https://localhost:7043/api/Products/deleteProduct/{id}'
