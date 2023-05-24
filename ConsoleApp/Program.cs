using ClassLibrary;

Console.WriteLine("Hello, World!");


List<Bus> buses = new List<Bus>
{
    new Bus{ Id = 1, Color = "Red", milesEachGalon = 10},
    new Bus{ Id = 2, Color = "Blue", milesEachGalon = 5},
    new Bus{ Id = 3, Color = "Yellow", milesEachGalon = 11},
    new Bus{ Id = 4, Color = "Green", milesEachGalon = 25},
    new Bus{ Id = 5, Color = "Purple", milesEachGalon = 8}
};

Reflection reflection = new Reflection();

foreach (var item in buses)
{
    var sql = reflection.ReflectionInsertInto(item);
    Console.WriteLine(sql);
}


// Reflection giver dig muligheden for at få metadata ud fra objekter i runtime.
// Det bliver brugt her for at finde hvilken type objektet er og hvad properties der er inde
// i klassen, for at lave en dynamisk sql string.

var sql2 = reflection.ReflectionInsertInto(buses);
Console.WriteLine(sql2);


Sorting sorting = new Sorting();
var sorted = sorting.SortingBus(buses);
foreach (var item in sorted)
{
    Console.WriteLine(item.ToString());
}