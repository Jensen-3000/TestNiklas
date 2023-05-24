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

var sql = reflection.ReflectionInsertInto(buses);
Console.WriteLine(sql);