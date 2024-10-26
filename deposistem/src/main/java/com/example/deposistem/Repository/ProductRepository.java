package com.example.deposistem.Repository;

import com.example.deposistem.Entity.Product; // Product sınıfını ekleyin
import org.springframework.data.jpa.repository.JpaRepository;

public interface ProductRepository extends JpaRepository<Product, Long> {
   
}