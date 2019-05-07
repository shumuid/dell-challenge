import React, { Component } from "react";
import Table from "./common/table";
import { Link } from "react-router-dom";

class ProductsTable extends Component {
  columns = [
    {
      path: "name",
      label: "Name",
      content: product => <Link to={`/products/${product.id}`}>{product.name}</Link>
    },
    { path: "category", label: "Category" }
  ];

  deleteColumn = {
    key: "delete",
    content: product => (
      <button
        className="btn btn-danger"
        onClick={() => this.props.onDelete(product)}
      >
        Delete
      </button>
    )
  };

  constructor() {
    super();

    //could show delete column only if the user is an Admin for example
    this.columns.push(this.deleteColumn);
  }

  render() {
    const { products, onSort, sortColumn } = this.props;

    return (
      <Table
        columns={this.columns}
        data={products}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default ProductsTable;
