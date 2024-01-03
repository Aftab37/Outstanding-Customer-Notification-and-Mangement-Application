//Models/Customer.cs
namespace WebApplication1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OutstandingAmount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
