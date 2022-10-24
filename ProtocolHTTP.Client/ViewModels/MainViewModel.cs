namespace ProtocolHTTP.Client.ViewModels;

public class MainViewModel
{
    private HttpClient _client;
    private static ushort _portNumber;

    public User User { get; set; }
    public ObservableCollection<User> Users { get; set; }

    public RelayCommand GetCommand { get; set; }
    public RelayCommand PostCommand { get; set; }


    public MainViewModel()
    {
        _client = new HttpClient();
        _portNumber = ushort.Parse(ConfigurationManager.AppSettings["PortNumber"]);

        Users = new ObservableCollection<User>();

        GetCommand = new RelayCommand(_ => GetUsersAsync());
        PostCommand = new RelayCommand(_ => PostUserAsync(), null);
    }


    private async Task GetUsersAsync()
    {
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(string.Format("http://localhost:{0}/", _portNumber))
        };

        var response = await _client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(jsonString);

            Users.Clear();

            foreach (var user in users) Users.Add(user);
        }
    }

    private async Task PostUserAsync()
    {
        var content = JsonContent.Create(User);

        var response = await _client.PostAsync(string.Format("http://localhost:{0}/", _portNumber), content);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            User = JsonSerializer.Deserialize<User>(jsonString);

            Users.Add(User);
        }
    }
}
