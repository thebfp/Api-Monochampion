using Microsoft.EntityFrameworkCore;
using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace Api_One_Trick_Pony_Br;

public static class PonyEndpoints
{
    public static void MapPonyEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Pony").WithTags(nameof(Pony));

        group.MapGet("/", async (Api_One_Trick_Pony_BrContext db) =>
        {
            return await db.Pony.ToListAsync();
        })
        .WithName("GetAllPonies")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Pony>, NotFound>> (int id, Api_One_Trick_Pony_BrContext db) =>
        {
            return await db.Pony.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Pony model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPonyById")
        .WithOpenApi();

        group.MapGet("/by-nick/{nick}", async Task<Results<Ok<Pony>, NotFound>> (string nick, Api_One_Trick_Pony_BrContext db) =>
        {
            return await db.Pony.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Nick == nick)
                is Pony model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPonyByNick")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Pony pony, Api_One_Trick_Pony_BrContext db) =>
        {
            var affected = await db.Pony
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, pony.Id)
                    .SetProperty(m => m.IconID, pony.IconID)
                    .SetProperty(m => m.Bio, pony.Bio)
                    .SetProperty(m => m.Karma, pony.Karma)
                    .SetProperty(m => m.Champion, pony.Champion)
                    .SetProperty(m => m.Elo, pony.Elo)
                    .SetProperty(m => m.Pdl, pony.Pdl)
                    .SetProperty(m => m.Nick, pony.Nick)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePony")
        .WithOpenApi();

        group.MapPost("/", async (Pony pony, Api_One_Trick_Pony_BrContext db) =>
        {
            db.Pony.Add(pony);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Pony/{pony.Id}",pony);
        })
        .WithName("CreatePony")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, Api_One_Trick_Pony_BrContext db) =>
        {
            var affected = await db.Pony
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePony")
        .WithOpenApi();
    }
}
