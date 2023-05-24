namespace ClassLibrary;

public class Sorting
{
    public List<Bus> SortingBus(List<Bus> buses)
    {
        var sortedList = buses.OrderBy(x => x.milesEachGalon).ToList();
        return sortedList;
    }
}
