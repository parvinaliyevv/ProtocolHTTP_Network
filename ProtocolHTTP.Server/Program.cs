namespace ProtocolHTTP.Server;

public static class Program
{
    private static uint _userId = default;

    private static HttpListener _listener;
    private static ushort _portNumber;

    public static string FilePath { get; set; }
    public static List<User> Users { get; set; }


    static Program()
    {
        _listener = new HttpListener();
        _portNumber = ushort.Parse(ConfigurationManager.AppSettings["PortNumber"]);

        FilePath = string.Format(@"{0}Assets\Data\Users.json", DirectoryService.GetProjectParentFolder());

        Users = new List<User>()
        {
            new User(NameFaker.FirstName(), NameFaker.LastName(), Convert.ToByte(NumberFaker.Number(10, 90))),
            new User(NameFaker.FirstName(), NameFaker.LastName(), Convert.ToByte(NumberFaker.Number(10, 90))),
            new User(NameFaker.FirstName(), NameFaker.LastName(), Convert.ToByte(NumberFaker.Number(10, 90))),
            new User(NameFaker.FirstName(), NameFaker.LastName(), Convert.ToByte(NumberFaker.Number(10, 90))),
            new User(NameFaker.FirstName(), NameFaker.LastName(), Convert.ToByte(NumberFaker.Number(10, 90)))
        };

        Users.ForEach(item => item.Id = _userId++);
        _listener.Prefixes.Add(string.Format("http://localhost:{0}/", _portNumber));
    }


    private static void Main(string[] args)
    {
        try
        {
            _listener.Start();

            if (File.Exists(FilePath)) DeserializeUsers();
            else SerializeUsers();

            HttpListenerContext context = null;

            while (true)
            {
                context = _listener.GetContext();

                CommunicationWithClientAsync(context);
            }
        }
        catch
        {
            Console.WriteLine("Server aborted or failed start!");
        }
    }

    private static void CommunicationWithClient(HttpListenerContext context)
    {
        var request = context.Request;
        var response = context.Response;
        
        if (request.HttpMethod == HttpMethod.Get.Method)
        {
            var jsonString = JsonSerializer.Serialize(Users);
            var streamWriter = new StreamWriter(response.OutputStream);

            streamWriter.WriteLine(jsonString);

            response.StatusCode = 200;
            streamWriter.Close();
        }
        else if (request.HttpMethod == HttpMethod.Post.Method)
        {
            var streamReader = new StreamReader(request.InputStream);
            var streamWriter = new StreamWriter(response.OutputStream);
            
            var jsonString = streamReader.ReadToEnd();

            var user = JsonSerializer.Deserialize<User>(jsonString);
            user.Id = _userId++;

            jsonString = JsonSerializer.Serialize(user);
            streamWriter.WriteLine(jsonString);

            Users.Add(user);
            SerializeUsersAsync();

            response.StatusCode = 200;
            streamReader.Close();
            streamWriter.Close();
        }
        else
        {
            response.StatusCode = 400;
            response.OutputStream.Close();
        }

        response.Close();
    }
    private static async Task CommunicationWithClientAsync(HttpListenerContext context)
        => await Task.Factory.StartNew(() => CommunicationWithClient(context));

    private static void SerializeUsers()
    {
        if (!File.Exists(FilePath)) File.Create(FilePath).Close();

        var jsonString = JsonSerializer.Serialize(Users);
        File.WriteAllText(FilePath, jsonString);
    }
    private static async Task SerializeUsersAsync() => await Task.Factory.StartNew(() => SerializeUsers());

    private static void DeserializeUsers()
    {
        if (File.Exists(FilePath))
        {
            var jsonString = File.ReadAllText(FilePath);
            Users = JsonSerializer.Deserialize<List<User>>(jsonString);
        }
    }
    private static async Task DeserializeUsersAsync() => await Task.Factory.StartNew(() => DeserializeUsers());
}
