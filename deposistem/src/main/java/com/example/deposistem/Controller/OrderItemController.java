package com.example.deposistem.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import com.example.deposistem.Entity.OrderItem;
import com.example.deposistem.Repository.OrderItemRepository;

import java.util.List;

@RestController
@RequestMapping("/api/orderitems")
public class OrderItemController {

    @Autowired
    private OrderItemRepository orderItemRepository;

    // Tüm sipariş kalemlerini getirme
    @GetMapping
    public List<OrderItem> getAllOrderItems() {
        return orderItemRepository.findAll();
    }

    // Belirli bir sipariş kalemini getirme
    @GetMapping("/{orderItemId}")
    public OrderItem getOrderItemById(@PathVariable Long orderItemId) throws Throwable {
        return (OrderItem) orderItemRepository.findById(orderItemId)
                .orElseThrow(() -> new RuntimeException("OrderItem not found with id: " + orderItemId));
    }

    // Yeni bir sipariş kalemi ekleme
    @PostMapping
    public OrderItem createOrderItem(@RequestBody OrderItem orderItem) {
        return (OrderItem) orderItemRepository.save(orderItem);
    }

    

    // Bir sipariş kalemini silme
    @DeleteMapping("/{orderItemId}")
    public void deleteOrderItem(@PathVariable Long orderItemId) {
        orderItemRepository.deleteById(orderItemId);
    }
}