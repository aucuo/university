package com.example.pms2;

public class Ticket {
    private int id;
    private String directionFrom;
    private String directionTo;
    private double price;

    public Ticket(int id, String directionFrom, String directionTo, double price) {
        this.id = id;
        this.directionFrom = directionFrom;
        this.directionTo = directionTo;
        this.price = price;
    }

    public int getId() {
        return id;
    }

    public String getDirectionFrom() {
        return directionFrom;
    }

    public String getDirectionTo() {
        return directionTo;
    }

    public double getPrice() {
        return price;
    }
}
