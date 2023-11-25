
using ParcialFinal.DAL.Entities;

namespace ParcialFinal.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;
        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateServices();

            await _context.SaveChangesAsync();
        }

        private async Task PopulateServices()
        {
            if (!_context.Services.Any())
            {
                await AddServiceIfNotExistsAsync(new Service { Name = "Lavada simple", Price = "25.000" });
                await AddServiceIfNotExistsAsync(new Service { Name = "Lavada + Polishada", Price = "50.000" });
                await AddServiceIfNotExistsAsync(new Service { Name = "Lavada + Aspirada de Cojinería", Price = "30.000" });
                await AddServiceIfNotExistsAsync(new Service { Name = "Lavada Full", Price = "65.000" });
                await AddServiceIfNotExistsAsync(new Service { Name = "Lavada en seco del Motor", Price = "80.000" });
                await AddServiceIfNotExistsAsync(new Service { Name = "Lavada Chasis", Price = "90.000" });
            }
        }

        private async Task AddServiceIfNotExistsAsync(Service service)
        {
            if (!_context.Services.Any(s => s.Name == service.Name && s.Price == service.Price))
            {
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}
