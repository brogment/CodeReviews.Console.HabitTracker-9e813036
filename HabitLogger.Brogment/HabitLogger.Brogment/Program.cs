using Microsoft.Data.Sqlite;
using System.Text.RegularExpressions;

string connectionString = @"Data Source=habit-Tracker.db";

using var connection = new SqliteConnection(connectionString);
connection.Open();

var tableCommand = connection.CreateCommand();
tableCommand.CommandText =
    @"CREATE TABLE IF NOT EXISTS booksread (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            title TEXT,
            book_completed TEXT,
            date_started TEXT,
            date_finished TEXT
            )";
tableCommand.ExecuteNonQuery();

connection.Close();

MainMenu();


void MainMenu()
{
    while (true)
    {
        Console.WriteLine(@" MAIN MENU
-----------

PRESS KEY TO CHOOSE AN OPERATION:

(1) VIEW ALL RECORDS
(2) INSERT RECORD
(3) DELETE RECORD
(4) UPDATE RECORD

(Q) QUIT");

        var input = ProcessKey("[1|2|3|4|q|Q]");

        switch (input)
        {
            case "1":
               // PrintRecords();
                break;
            case "2":
                Insert();
                break;
            case "3":
               // Delete();
                break;
            case "4":
               // Update();
                break;
            case "q":
            case "Q":
                return;
        }

    }
}

string ProcessKey(string regexExpression)
{
    string? keyValue;
    while (true)
    {
        ConsoleKeyInfo keyPressed = Console.ReadKey();
        Console.WriteLine();
        keyValue = keyPressed.KeyChar.ToString();

        if (Regex.IsMatch(keyValue, regexExpression))
        {
            return keyValue;
        }
    }
}

void Insert()
{
    string dateFormat = @"\d{2}-\d{2}-\d{4}";

    Console.WriteLine("Enter title of book");
    string title = GetText();

    Console.WriteLine($"Enter date you started reading {title}");
    string? date_started = GetDateInput(dateFormat);
    string? date_finished = null;

    Console.WriteLine($"Have you finished {title}");
    string? finishedBook = ProcessKey("[y|Y|n|N]").ToLower();
    if (finishedBook.Equals('y'))
    {
        date_finished = GetDateInput(dateFormat);
    }
}

string GetText(string? message = null)
{
    if (message is not null)
    {
        Console.WriteLine(message);
    }

    string? input = null;
    while (true)
    {
        input = Console.ReadLine();
        if (input.Equals("") {
    }

}

string GetDateInput(string regexDateFormat)
{
    Console.WriteLine("Please enter date in MM-DD-YYYY format");
    string? input = Console.ReadLine();
    
    while (true)
    {
          // null check needed
        if (Regex.IsMatch(input, regexDateFormat))
        {
            return input;
        }   else
        {
            Console.WriteLine("Date entered in wrong format");
        }
    }
}