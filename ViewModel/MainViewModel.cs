using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp2.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    public partial ObservableCollection<string> Items { get; set; }

    [ObservableProperty]
    public partial string Text { get; set; }

    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        Text = string.Empty;
        _connectivity = connectivity;
    }

    [RelayCommand]
    private async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlertAsync("Uh Oh!", "No Internet", "OK");
            return;
        }

        Items.Add(Text.Trim());
        Text = string.Empty;
    }

    [RelayCommand]
    private void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    private async Task Tap(string s)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage), new Dictionary<string, object>
        {
            [nameof(DetailViewModel.Text)] = s
        });
    }
}
