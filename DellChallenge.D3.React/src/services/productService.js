import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = `${apiUrl}/products`;

function productUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getProducts() {
  return http.get(apiEndpoint);
}

export function getProduct(productId) {
  return http.get(productUrl(productId));
}

export function deleteProduct(productId) {
  http.delete(productUrl(productId));
}

export function saveProduct(product) {
  if (product.id) {
    const body = { ...product };
    delete body.id;
    return http.put(productUrl(product.id), body);
  }
  return http.post(`${apiEndpoint}/`, product);
}