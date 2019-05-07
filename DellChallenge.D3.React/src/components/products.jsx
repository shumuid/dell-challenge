import React, { Component } from "react";
import { getProducts, deleteProduct } from "../services/productService";
import { toast } from "react-toastify";
import ProductsTable from "./productsTable";
import _ from "lodash";

class Products extends Component {
  state = {
    products: [],
    sortColumn: { path: "name", order: "asc" }
  };

  async componentDidMount() {
    //this is where we initialize object from server calls

    const { data: products } = await getProducts();

    this.setState({ products });
  }

  handleDelete = async product => {
    const originalProducts = this.state.products;

    const products = originalProducts.filter(p => p.id !== product.id);
    this.setState({ products });

    try {
      await deleteProduct(product.id);
    } catch (ex) {
      if (ex.response && ex.response.status === 404) {
        toast.error("This product has already been deleted.");

        this.setState({ products: originalProducts });
      }
    }
  };

  handleSort = sortColumn => {
    this.setState({ sortColumn });
  };

  handleNewProduct = () => {
    this.props.history.push("/products/new");
  };

  getPagedData = () => {
    const {
      products: allProducts,
      sortColumn
    } = this.state;

    //filter data could do a search filter logic here
    let filtered = allProducts;

    //sort data
    const sorted = _.orderBy(filtered, [sortColumn.path], [sortColumn.order]);

    return { data: sorted, totalCount: sorted.length };
  };

  render() {
    const { length: products_no } = this.state.products;

    const {
      sortColumn
    } = this.state;

    if (products_no === 0) return <p>There are no products in the database.</p>;

    const { totalCount, data: products } = this.getPagedData();

    return (
      <div className="row mt-2">
        <div className="col">
            <p>
              <button onClick={this.handleNewProduct} className="btn btn-primary">
                New Product
              </button>
            </p>
          <p>Showing {totalCount} products in the database.</p>
          <ProductsTable
            products={products}
            onDelete={this.handleDelete}
            onSort={this.handleSort}
            sortColumn={sortColumn}
          />
        </div>
      </div>
    );
  }
}

export default Products;
