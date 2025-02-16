﻿using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class PonyService
    {
        public static void MapPonyEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Pony").WithTags(nameof(Pony));

            group.MapGet("/", async (PonyRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllPonys")
            .WithOpenApi();

            group.MapGet("/{id}", async (PonyRepository repo, int id) =>
            {
                var pony = await repo.GetByIdAsync(id);
                if (pony is null)
                    return Results.NotFound();
                
                return Results.Ok(pony);
            })
           .WithName("GetPonyById")
           .WithOpenApi();

            group.MapPost("/", async (PonyRepository repo, Pony pony) =>
            {
                repo.AddAsync(pony);

                if(pony == null)
                    return Results.BadRequest();
                
                return Results.Created();
            })
            .WithName("CreatePony")
            .WithOpenApi();

            group.MapPut("/{id}", async (PonyRepository repo, int id, Pony pony) =>
            {
                pony = await repo.GetByIdAsync(id);

                if (id != pony.Id)
                    return Results.BadRequest();

                await repo.UpdateAsync(pony);
                return Results.Ok();
            })
            .WithName("UpdatePony")
            .WithOpenApi();

            group.MapDelete("/{id}", async (PonyRepository repo, int id) =>
            {

                var delete = repo.DeleteAsync(id);

                if (delete == null)
                    return Results.NotFound();

                return Results.Ok();
            })
            .WithName("DeletePony")
            .WithOpenApi();
        }
    }
}
