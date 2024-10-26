package com.example.deposistem.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import com.example.deposistem.Entity.Product;
import com.example.deposistem.Repository.ProductRepository;

import java.util.List;

@RestController
@RequestMapping("/api/products")
public class ProductController {

    @Autowired
    private ProductRepository productRepository;

    @GetMapping
    public List<Product> getAllProducts() {
        return productRepository.findAll();
    }

    @GetMapping("/{productId}")
    public Product getProductById(@PathVariable Long productId) {
        return (Product) productRepository.findById(productId)
                .orElse(null); // İsteğe bağlı, ürün bulunamazsa null dönebilirsiniz.
    }

    @PostMapping
    public Product createProduct(@RequestBody Product product) {
        return (Product) productRepository.save(product);
    }

    @DeleteMapping("/{productId}")
    public void deleteProduct(@PathVariable Long productId) {
        productRepository.deleteById(productId);
    }
}