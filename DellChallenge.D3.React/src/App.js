import React, { Component } from "react";
import { Route, Switch, Redirect } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import NavBar from "./components/navBar";
import Products from "./components/products";
import ProductForm from "./components/productForm";
import NotFound from "./components/notFound";
import "./App.css";
import "react-toastify/dist/ReactToastify.css";

class App extends Component {
  state = {};

  componentDidMount() {
    //
  }

  render() {
    return (
      <React.Fragment>
        <ToastContainer />
        <NavBar />
        <main className="container">
          <Switch>
            <Route path="/products/:id" component={ProductForm} />
            <Route path="/products/new" component={ProductForm} />
            <Route
              path="/products"
              render={props => <Products {...props} />}
            />
            <Route path="/not-found" component={NotFound} />
            <Redirect from="/" exact to="/products" />
            <Redirect to="/not-found" />
          </Switch>
        </main>
      </React.Fragment>
    );
  }
}

export default App;
