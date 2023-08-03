namespace BlazorApp.Data
{
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    
    public interface IFoodService
    {
        IEnumerable<Food> GetFoods();
    }

    public class FoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food() {Name = "Bibimbap", Price = 7000},
                new Food() {Name = "Gimbap", Price = 3000},
                new Food() {Name = "Jjajanbap", Price = 8000}
            };

            return foods;
        }
    }

    public class PaymentService
    {
        IFoodService _service;
        public PaymentService(IFoodService service)
        {
            _service = service;
        }
    }

}
