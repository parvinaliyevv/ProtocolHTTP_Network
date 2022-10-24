namespace ProtocolHTTP.Client.Views;

public partial class InsertUserView : Window
{
    public InsertUserView()
    {
        InitializeComponent();

        DataContext = new InsertUserViewModel();
    }


    private void SaveCar_ButtonClicked(object sender, RoutedEventArgs e) => DialogResult = true;

    private void AppClose_ButtonClicked(object sender, RoutedEventArgs e) => Close();

    private void DragWindow_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
}
