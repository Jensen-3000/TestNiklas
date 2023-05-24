namespace ClassLibrary
{
    public class Bus
    {
        public int Id { get; set; }
        public string Color { get; set; } = "";
        public int milesEachGalon { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} \nmiles per gallon: {milesEachGalon}";
        }
    }
}
