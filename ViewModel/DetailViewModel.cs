using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp2.ViewModel;

[QueryProperty(nameof(Text), nameof(Text))]
public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    public partial string Text { get; set; }

    public DetailViewModel()
    {
        Text = string.Empty;
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
