using NUnit.Framework;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Tests
{
    public class ExpenseServiceTests
    {
        private ExpenseService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ExpenseService();
        }

        [Test]
        public void AddExpense_ShouldIncreaseCount()
        {
            _service.AddExpense(new Expense(DateTime.Now, "Food", 10, "Lunch"));
            Assert.AreEqual(1, _service.GetAllExpenses().Count);
        }

        [Test]
        public void GetTotalByCategory_ShouldReturnCorrectSum()
        {
            _service.AddExpense(new Expense(DateTime.Now, "Transport", 5, "Bus"));
            _service.AddExpense(new Expense(DateTime.Now, "Transport", 15, "Taxi"));

            Assert.AreEqual(20, _service.GetTotalByCategory("Transport"));
        }

        [Test]
        public void GetTotal_ShouldReturnSumOfAllExpenses()
        {
            _service.AddExpense(new Expense(DateTime.Now, "Food", 12, "Pizza"));
            _service.AddExpense(new Expense(DateTime.Now, "Books", 8, "Textbook"));

            Assert.AreEqual(20, _service.GetTotal());
        }
    }
}
