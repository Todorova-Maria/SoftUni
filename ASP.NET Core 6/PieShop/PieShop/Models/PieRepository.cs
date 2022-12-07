using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext pieShopDbContext;

        public PieRepository(PieShopDbContext pieShopDbContext)
        {
            this.pieShopDbContext = pieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return pieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return pieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
          return pieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
