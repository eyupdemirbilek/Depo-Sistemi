package com.example.deposistem.Repository;

import com.example.deposistem.Entity.Category; // Category sınıfını ekleyin
import org.springframework.data.jpa.repository.JpaRepository;

public interface CategoryRepository extends JpaRepository<Category, Long> {
    
}
