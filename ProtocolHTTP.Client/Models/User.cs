namespace ProtocolHTTP.Client.Models;

public class User
{
    [JsonPropertyName("id")]
    public uint? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("age")]
    public byte? Age { get; set; }


    public User()
    {
        Id = null;
        Name = null;
        Surname = null;
        Age = null;
    }

    public User(string name, string surname, byte? age)
    {
        Name = name;
        Surname = surname;
        Age = age;
    }
}
