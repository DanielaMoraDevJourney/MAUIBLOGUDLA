using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BLOGSOCIALUDLA.Models;

public class BlogService
{
    private readonly HttpClient _httpClient;

    public BlogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Post>> GetBlogsFicaAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Post>>("api/fica/blogs");
    }

    public async Task<List<Post>> GetBlogsNodoAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Post>>("api/nodo/blogs");
    }

    public async Task<Post> GetBlogFicaAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Post>($"api/fica/blogs/{id}");
    }

    public async Task<Post> GetBlogNodoAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Post>($"api/nodo/blogs/{id}");
    }

    public async Task CreateBlogFicaAsync(Post post)
    {
        await _httpClient.PostAsJsonAsync("api/fica/blogs", post);
    }

    public async Task CreateBlogNodoAsync(Post post)
    {
        await _httpClient.PostAsJsonAsync("api/nodo/blogs", post);
    }

    public async Task UpdateBlogFicaAsync(Guid id, Post post)
    {
        await _httpClient.PutAsJsonAsync($"api/fica/blogs/{id}", post);
    }

    public async Task UpdateBlogNodoAsync(Guid id, Post post)
    {
        await _httpClient.PutAsJsonAsync($"api/nodo/blogs/{id}", post);
    }

    public async Task DeleteBlogFicaAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"api/fica/blogs/{id}");
    }

    public async Task DeleteBlogNodoAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"api/nodo/blogs/{id}");
    }
}
