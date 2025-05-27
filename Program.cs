using ExpenseTracker.Models;
using ExpenseTracker.Services;

var service = new ExpenseService();

while (true)
{
    Console.WriteLine("\nExpense Tracker:");
    Console.WriteLine("1. Add Expense");
    Console.WriteLine("2. View All Expenses");
    Console.WriteLine("3. View Total by Category");
    Console.WriteLine("4. View Grand Total");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Enter date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Enter category: ");
            string category = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter description: ");
            string description = Console.ReadLine() ?? string.Empty;

            var expense = new Expense(date, category, amount, description);
            service.AddExpense(expense);
            Console.WriteLine("Expense added!");
            break;

        case "2":
            var all = service.GetAllExpenses();
            foreach (var e in all)
                Console.WriteLine($"{e.Date.ToShortDateString()} - {e.Category} - {e.Amount:C} - {e.Description}");
            break;

        case "3":
            Console.Write("Enter category: ");
            string cat = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Total for {cat}: {service.GetTotalByCategory(cat):C}");
            break;

        case "4":
            Console.WriteLine($"Total expenses: {service.GetTotal():C}");
            break;

        case "5":
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
