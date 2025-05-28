using NUnit.Framework;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using System;

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
            Assert.That(_service.GetAllExpenses().Count, Is.EqualTo(1));
        }

        [Test]
        public void GetTotalByCategory_ShouldReturnCorrectSum()
        {
            _service.AddExpense(new Expense(DateTime.Now, "Transport", 5, "Bus"));
            _service.AddExpense(new Expense(DateTime.Now, "Transport", 15, "Taxi"));
            Assert.That(_service.GetTotalByCategory("Transport"), Is.EqualTo(20));
        }

        [Test]
        public void GetTotal_ShouldReturnSumOfAllExpenses()
        {
            _service.AddExpense(new Expense(DateTime.Now, "Food", 12, "Pizza"));
            _service.AddExpense(new Expense(DateTime.Now, "Books", 8, "Textbook"));
            Assert.That(_service.GetTotal(), Is.EqualTo(20));
        }
    }
}
