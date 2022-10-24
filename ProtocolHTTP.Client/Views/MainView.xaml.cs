namespace ProtocolHTTP.Client.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }


    private void InsertCar_ButtonClicked(object sender, RoutedEventArgs e)
    {
        var view = new InsertUserView() { Owner = this };
        var viewModel = DataContext as MainViewModel;

        if (view.ShowDialog() == true)
        {
            var user = (view.DataContext as InsertUserViewModel).User;

            viewModel.User = user;
            viewModel.PostCommand.Execute(null);
        }
    }

    private void AppClose_ButtonClicked(object sender, RoutedEventArgs e) => Close();

    private void DragWindow_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

    private void MinimizeWindow_ButtonClicked(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
}
