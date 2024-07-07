using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BLOGSOCIALUDLA.Models;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<User>>("api/users");
    }

    public async Task<User> GetUserAsync(string username)
    {
        return await _httpClient.GetFromJsonAsync<User>($"api/users/{username}");
    }

    public async Task CreateUserAsync(User user)
    {
        await _httpClient.PostAsJsonAsync("api/users", user);
    }

    public async Task UpdateUserAsync(string username, User user)
    {
        await _httpClient.PutAsJsonAsync($"api/users/{username}", user);
    }

    public async Task DeleteUserAsync(string username)
    {
        await _httpClient.DeleteAsync($"api/users/{username}");
    }
}
