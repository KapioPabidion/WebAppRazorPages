using WebAppRazorPages.Model;
using WebAppRazorPages.Repository;

namespace WebAppRazorPages.Repository
{
    public class SqlMotorcycleRepository : IMotorcycle
    {
        private readonly AppDbContext _appDbContext;

        public SqlMotorcycleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Motorcycle Add(Motorcycle Imotorcycle)
        {
            return Imotorcycle;
        }
        public Motorcycle DeleteMotorcycle(int Id)
        {
            var motorcycle = GetMotorcycle(Id);
            _appDbContext.Remove(motorcycle);
            _appDbContext.SaveChanges();
            return motorcycle;
        }

        public Motorcycle? GetMotorcycle(int Id)
        {
            return _appDbContext.Motorcycle.Where( u => u.Id == Id).ToList().FirstOrDefault();
        }

        public List<Motorcycle> GetAll()
        {
            return _appDbContext.Motorcycle.ToList();
        }

        public Motorcycle UpdateMotorcycle(Motorcycle upMotorcycle)
        {
            if (upMotorcycle.Id == 0)
            {
                _appDbContext.Motorcycle.Add(upMotorcycle);
            }
            else
            {
                _appDbContext.Motorcycle.Update(upMotorcycle);
            }
            _appDbContext.SaveChanges();
            return upMotorcycle;
        }
    }
}
