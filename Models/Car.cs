public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public decimal PricePerDay { get; set; }

    public static List<Car> GetCars()
    {
        return new List<Car>
        {
            new Car { Id = 1, Name = "Alfa Romeo Giulia Quadrifoglio", ImageUrl = "/images/alfa-romeo.jpg", PricePerDay = 1500 },
            new Car { Id = 2, Name = "Aston Martin DB11 V12", ImageUrl = "/images/aston-martin.jpg", PricePerDay = 5000 },
            new Car { Id = 3, Name = "Audi A7 45 TDI", ImageUrl = "/images/audi-a7.jpg", PricePerDay = 1000 },
            new Car { Id = 4, Name = "Audi R8 Spyder RWD", ImageUrl = "/images/audi-r8.jpg", PricePerDay = 3500 },
            new Car { Id = 5, Name = "BMW M2 Competition", ImageUrl = "/images/bmw-m2.jpg", PricePerDay = 1000 },
            new Car { Id = 6, Name = "BMW M4 Competition RWD", ImageUrl = "/images/bmw-m4.jpg", PricePerDay = 2500 }
        };
    }
}
