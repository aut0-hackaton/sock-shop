using System;

namespace WebShop.Api.Models.Orders
{

    public class GetOrdersResponse
    {
        public string customerId { get; set; }
        public Customer customer { get; set; }
        public Address address { get; set; }
        public Card card { get; set; }
        public Item[] items { get; set; }
        public Shipment shipment { get; set; }
        public DateTime date { get; set; }
        public float total { get; set; }
        public _Links _links { get; set; }
    }


    public class Customer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public object[] addresses { get; set; }
        public object[] cards { get; set; }
    }

    public class Address
    {
        public string number { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }

    public class Card
    {
        public string longNum { get; set; }
        public string expires { get; set; }
        public string ccv { get; set; }
    }

    public class Shipment
    {
        public string name { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
        public Order order { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Order
    {
        public string href { get; set; }
    }

    public class Item
    {
        public string itemId { get; set; }
        public int quantity { get; set; }
        public float unitPrice { get; set; }
    }

}
