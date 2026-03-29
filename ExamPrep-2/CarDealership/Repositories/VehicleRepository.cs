using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> models;

        public VehicleRepository()
        {
            models = new List<IVehicle>();
        }

        public IReadOnlyCollection<IVehicle> Models => models.AsReadOnly();

        public void Add(IVehicle model)
        {
            models.Add(model);
        }

        public bool Exists(string text)
        {
            return models.Any(m => m.Model == text);
        }

        public IVehicle Get(string text)
        {
            IVehicle vehicle = models.FirstOrDefault(m => m.Model == text);

            return vehicle;
        }

        public bool Remove(string text)
        {
            IVehicle vehicle = models.FirstOrDefault(m => m.Model == text);

            return models.Remove(vehicle);
        }
    }
}
