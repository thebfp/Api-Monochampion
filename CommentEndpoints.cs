using Microsoft.EntityFrameworkCore;
using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace Api_One_Trick_Pony_Br;

public static class CommentEndpoints
{
    public static void MapCommentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Comment").WithTags(nameof(Comment));

        group.MapGet("/", async (Api_One_Trick_Pony_BrContext db) =>
        {
            return await db.Comment.ToListAsync();
        })
        .WithName("GetAllComments")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Comment>, NotFound>> (int id, Api_One_Trick_Pony_BrContext db) =>
        {
            return await db.Comment.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Comment model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCommentById")
        .WithOpenApi();


        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Comment comment, Api_One_Trick_Pony_BrContext db) =>
        {
            var affected = await db.Comment
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, comment.Id)
                    .SetProperty(m => m.MonochampId, comment.MonochampId)
                    .SetProperty(m => m.AutorID, comment.AutorID)
                    .SetProperty(m => m.Message, comment.Message)
                    .SetProperty(m => m.Date, comment.Date)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateComment")
        .WithOpenApi();

        group.MapPost("/", async (Comment comment, Api_One_Trick_Pony_BrContext db) =>
        {
            db.Comment.Add(comment);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Comment/{comment.Id}",comment);
        })
        .WithName("CreateComment")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, Api_One_Trick_Pony_BrContext db) =>
        {
            var affected = await db.Comment
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteComment")
        .WithOpenApi();
    }
}
