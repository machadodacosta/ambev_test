using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sales.AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.Include(i => i.Products).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }
        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken)
        {
            var existingSale = await GetByIdAsync(sale.Id, cancellationToken);

            if (existingSale == null)
            {
                return null;
            }

            _context.Sales.Update(sale);  // Marca o produto para atualização.
            await _context.SaveChangesAsync(cancellationToken);  // Persiste as alterações.

            return sale;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
