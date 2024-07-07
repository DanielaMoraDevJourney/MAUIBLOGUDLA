using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BLOGSOCIALUDLA.Models;

public class CommentService
{
    private readonly HttpClient _httpClient;

    public CommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Comentario>> GetCommentsByBlogFicaIdAsync(Guid blogFicaId)
    {
        return await _httpClient.GetFromJsonAsync<List<Comentario>>($"api/comments/byBlogFica/{blogFicaId}");
    }

    public async Task<List<Comentario>> GetCommentsByBlogNodoIdAsync(Guid blogNodoId)
    {
        return await _httpClient.GetFromJsonAsync<List<Comentario>>($"api/comments/byBlogNodo/{blogNodoId}");
    }

    public async Task CreateCommentAsync(Comentario comentario)
    {
        await _httpClient.PostAsJsonAsync("api/comments", comentario);
    }

    public async Task UpdateCommentAsync(Guid id, Comentario comentario)
    {
        await _httpClient.PutAsJsonAsync($"api/comments/{id}", comentario);
    }

    public async Task DeleteCommentAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"api/comments/{id}");
    }
}
