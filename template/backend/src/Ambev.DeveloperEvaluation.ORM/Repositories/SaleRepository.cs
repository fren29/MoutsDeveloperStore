using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DbContext _context;

        public SaleRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken)
        {
            await _context.Set<Sale>().AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<Sale?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Sale>()
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}