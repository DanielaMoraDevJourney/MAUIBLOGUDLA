using System;
using System.Net.Http;
using BLOGSOCIALUDLA.ViewModels;
using Microsoft.Maui.Controls;


public partial class PostFica : ContentPage
{
    public PostFica()
    {
        InitializeComponent();
        var blogService = new BlogService(new HttpClient { BaseAddress = new Uri("https://localhost:7034/") });
        BindingContext = new PostFicaViewModel(blogService);
    }
}
