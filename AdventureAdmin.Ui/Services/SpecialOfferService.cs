using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class SpecialOfferService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<SpecialOffer, int>
{
    public async Task<SpecialOffer?> Buscar(int id)
    {
        return await context.SpecialOffers.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var oferta = await context.SpecialOffers.FindAsync(id);
        if (oferta == null) return false;
        
        context.SpecialOffers.Remove(oferta);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<SpecialOffer>> GetList(Expression<Func<SpecialOffer, bool>> criterio)
    {
        return await context.SpecialOffers
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.SpecialOffer entity)
    {
        await context.SpecialOffers.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
