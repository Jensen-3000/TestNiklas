using ClassLibrary;

// Exercise 2
List<Bus> buses = new List<Bus>
{
    new Bus{ Id = 1, Color = "Red", milesEachGalon = 10},
    new Bus{ Id = 2, Color = "Blue", milesEachGalon = 5},
    new Bus{ Id = 3, Color = "Yellow", milesEachGalon = 11},
    new Bus{ Id = 4, Color = "Green", milesEachGalon = 25},
    new Bus{ Id = 5, Color = "Purple", milesEachGalon = 8}
};

DisplaySeparator("Exercise 3");
Reflection reflection = new Reflection();

foreach (var item in buses)
{
    var sql = reflection.ReflectionInsertInto(item);
    Console.WriteLine(sql);
}

// Exercise 4
// Reflection giver dig muligheden for at få metadata ud fra objekter i runtime.
// Det bliver brugt her for at finde hvilken type objektet er og hvad properties der er inde
// i klassen, for at lave en dynamisk sql string.


// Use true to also include ID, false for no ID.
DisplaySeparator("Exercise 5 - uden ID");
Console.WriteLine(reflection.ReflectionInsertInto(buses, false));

DisplaySeparator("Exercise 5 - med ID");
Console.WriteLine(reflection.ReflectionInsertInto(buses, true));

DisplaySeparator("Exercise 6 - Sorted by milesEachGalon");

Sorting sorting = new Sorting();
var sorted = sorting.SortingBus(buses);
foreach (var item in sorted)
{
    Console.WriteLine(item.ToString());
}


void DisplaySeparator(string text)
{
    Console.WriteLine();
    Console.Write(new string('-',20));
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(text);
    Console.ResetColor();
    Console.Write(new string('-', 20));
    Console.WriteLine();
}