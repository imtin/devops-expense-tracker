namespace ExpenseTracker.Models
{
    public class Expense
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public Expense(DateTime date, string category, decimal amount, string description)
        {
            Date = date;
            Category = category;
            Amount = amount;
            Description = description;
        }
    }
}
