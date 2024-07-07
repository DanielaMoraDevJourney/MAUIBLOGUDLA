using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using BLOGSOCIALUDLA.Models;
using BLOGSOCIALUDLA.Views;
using Microsoft.Maui.Controls;

public class PostFicaViewModel : INotifyPropertyChanged
{
    private readonly BlogService _blogService;

    public ObservableCollection<Post> Posts { get; set; }
    public ICommand AddPostCommand { get; }
    public ICommand PostSelectedCommand { get; }
    public ICommand BackCommand { get; }

    private Post _selectedPost;
    public Post SelectedPost
    {
        get => _selectedPost;
        set
        {
            if (_selectedPost != value)
            {
                _selectedPost = value;
                OnPropertyChanged();
                PostSelectedCommand.Execute(_selectedPost);
            }
        }
    }

    public PostFicaViewModel(BlogService blogService)
    {
        _blogService = blogService;
        Posts = new ObservableCollection<Post>();
        AddPostCommand = new Command(async () => await OnAddPost());
        PostSelectedCommand = new Command<Post>(async (post) => await OnPostSelected(post));
        BackCommand = new Command(async () => await OnBack());
        LoadPosts();
    }

    private async Task LoadPosts()
    {
        var posts = await _blogService.GetBlogsFicaAsync();
        foreach (var post in posts)
        {
            Posts.Add(post);
        }
    }

    private async Task OnAddPost()
    {
        var nuevaPage = new AddPostPage();
        nuevaPage.PostAgregado += NuevaPage_PostAgregado;
        await Application.Current.MainPage.Navigation.PushAsync(nuevaPage);
    }

    private async void NuevaPage_PostAgregado(object sender, Post e)
    {
        await _blogService.CreateBlogFicaAsync(e);
        Posts.Add(e);
    }

    private async Task OnPostSelected(Post selectedPost)
    {
        if (selectedPost != null)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new PostSeleccionado(selectedPost));
        }
    }

    private async Task OnBack()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
