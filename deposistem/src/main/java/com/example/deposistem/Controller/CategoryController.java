package com.example.deposistem.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;

import com.example.deposistem.Entity.Product;
import com.example.deposistem.Repository.ProductRepository;

import java.util.List;

@Controller
@RequestMapping("/api/admin/products")
public class CategoryController {

    @Autowired
    private ProductRepository productRepository;

    // Tüm ürünleri getirme
    @GetMapping
    public List<Product> getAllProducts() {
        return productRepository.findAll();
    }

    // Belirli bir ürünü getirme
    @GetMapping("/{productId}")
    public Product getProductById(@PathVariable Long productId) throws Throwable {
        return (Product) productRepository.findById(productId)
                .orElseThrow(() -> new RuntimeException("Product not found with id: " + productId));
    }

    // Yeni bir ürün ekleme
    @PostMapping
    public Product createProduct(@RequestBody Product product) {
        return (Product) productRepository.save(product);
    }

    // Bir ürünü silme
    @DeleteMapping("/{productId}")
    public void deleteProduct(@PathVariable Long productId) {
        productRepository.deleteById(productId);
    }
}