using ModernFlat.Core;

namespace ModernFlat.MVVM.ViewModels;

public class MainViewModel : ObservableObject
{
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand DiscoveryViewCommand { get; set; }

    public HomeViewModel HomeViewModel { get; set; }
    public DiscoveryViewModel DiscoveryViewModel { get; set; }

    private object? _currentView;
    public object? CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        HomeViewModel = new HomeViewModel();
        DiscoveryViewModel = new DiscoveryViewModel();

        CurrentView = HomeViewModel;

        HomeViewCommand = new RelayCommand(_ =>
        {
            CurrentView = HomeViewModel;
        });

        DiscoveryViewCommand = new RelayCommand(_ =>
        {
            CurrentView = DiscoveryViewModel;
        });
    }
}