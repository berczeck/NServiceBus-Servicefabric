using System.Collections.Generic;

namespace ClientWebApi.Models
{
    /// <summary>
    /// Sales model
    /// </summary>
    public class SalesModel
    {
        /// <summary>
        /// Order id used by customers
        /// </summary>
        public string OrderId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsPromoted { get; set; }
        public int DayNumber { get; set; }
        public List<Address> Addresses { get; set; }
        public Person Owner { get; set; }
    }

    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Location { get; set; }

    }

    /// <summary>
    /// Card order request
    /// </summary>
    public class CreateCardOrderRequest
    {
        /// <summary>
        /// Id property
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// cancel order
    /// </summary>
    public class CreateCardOrderResponse
    {
        /// <summary>
        /// Id property
        /// </summary>
        public int Id { get; set; }
    }
}