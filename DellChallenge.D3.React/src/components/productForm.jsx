import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import { getProduct, saveProduct } from "../services/productService";

class ProductForm extends Form {
  state = {
    data: {
      name: "",
      category: ""
    },
    errors: {}
  };

  schema = {
    id: Joi.number(),
    name: Joi.string()
      .required()
      .label("Name"),
    category: Joi.string()
      .required()
      .label("Category")
  };

  mapToViewModel(product) {
    return {
      id: product.id,
      name: product.name,
      category: product.category
    };
  }

  doSubmit = async () => {
    //Call the server
    await saveProduct(this.state.data);

    this.props.history.push("/products");
  };

  async populateProduct() {
    try {
      const productId = this.props.match.params.id;
      if (productId === "new") return;

      const { data: product } = await getProduct(productId);

      this.setState({ data: this.mapToViewModel(product) });
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        this.props.history.replace("/not-found");
    }
  }

  async componentDidMount() {
    await this.populateProduct();
  }

  render() {
    return ( 
      <div>
        <h1>
          Product Form
          {this.props.match.params.id !== "new"
            ? ` - ${this.props.match.params.id}`
            : ""}
        </h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderInput("name", "Name")}
          {this.renderInput("category", "Category")}
          {this.renderButton("Save")}
        </form>
      </div>
    );
  }
}

export default ProductForm;
