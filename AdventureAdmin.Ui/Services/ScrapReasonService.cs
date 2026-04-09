using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services
{
    public class ScrapReasonService(AdventureWorksContext context) : Aplicada1.Core.IService<Data.Models.ScrapReason, int>
    {
        Task<Data.Models.ScrapReason?> IService<Data.Models.ScrapReason, int>.Buscar(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IService<Data.Models.ScrapReason, int>.Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Data.Models.ScrapReason>>GetList(Expression<Func<Data.Models.ScrapReason, bool>> criterio)
        {
            return await context.ScrapReasons.Where(criterio).ToListAsync();

        }

        async Task<bool> IService<Data.Models.ScrapReason, int>.Guardar(Data.Models.ScrapReason entidad)
        {
            await context.ScrapReasons.AddAsync(entidad);
            var resultado = await context.SaveChangesAsync();
            return resultado > 0;
        }
    }
}
