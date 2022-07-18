using WPFTestApp.ViewModels.Base;

namespace WPFTestApp.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private string _Title = "Главное окно";

    public string Title
    {
        get => _Title;
        set
        {
            _Title = value;
            OnPropertyChanged("Title");
        }
    }
}
