using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private readonly List<Expense> _expenses = new();

        public void AddExpense(Expense expense)
        {
            _expenses.Add(expense);
        }

        public List<Expense> GetAllExpenses()
        {
            return _expenses;
        }

        public decimal GetTotalByCategory(string category)
        {
            return _expenses
                .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .Sum(e => e.Amount);
        }

        public decimal GetTotal()
        {
            return _expenses.Sum(e => e.Amount);
        }
    }
}
