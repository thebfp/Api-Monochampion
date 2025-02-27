﻿using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class CommentService
    {
        public static void MapCommentEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Comment").WithTags(nameof(Comment));

            group.MapGet("/", async (CommentRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllComments")
            .WithOpenApi();

            group.MapGet("/{id}", async (CommentRepository repo, int id) =>
            {
                var comment = await repo.GetByIdAsync(id);
                if (comment is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(comment);
            })
           .WithName("GetCommentById")
           .WithOpenApi();

            group.MapPost("/", async (CommentRepository repo, Comment comment) =>
            {
                await repo.AddAsync(comment);
 
                return Results.Created($"/api/Comment/{comment.Id}", comment);
            })
            .WithName("CreateComment")
            .WithOpenApi();

            group.MapPut("/{id}", async (CommentRepository repo, int id, Comment update) =>
            {
                await repo.UpdateAsync(update, id);
            })
            .WithName("UpdateComment")
            .WithOpenApi();

            group.MapDelete("/{id}", async (CommentRepository repo, int id) =>
            {
                await repo.DeleteAsync(id);
            })
            .WithName("DeleteComment")
            .WithOpenApi();
        }
    }
}
