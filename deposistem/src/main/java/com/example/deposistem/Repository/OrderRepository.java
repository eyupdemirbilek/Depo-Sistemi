package com.example.deposistem.Repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.deposistem.Entity.Order;

public interface OrderRepository extends JpaRepository<Order, Long> {
    
}
