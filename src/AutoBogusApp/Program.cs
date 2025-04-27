using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoBogusApp.DataGeneration;

namespace BugusApp;

public static class JsonConfig
{
    public static readonly JsonSerializerOptions DefaultOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };
}

public class Program
{
    // static void Main(string[] args)
    // {
    //     Faker f = new Faker();
    //     var name = Generic.GenerateName(f, 3, 40);
    //     Console.WriteLine(name);
    // }
    
    static void Main(string[] args)
    {
        // VacatureFaker faker = new VacatureFaker();
        // var vacature = faker.FakeVacature();
        
        // VacatureFaker faker = new VacatureFaker();
        // var mpVacature = faker.FakeMpVacatureMatch();
        
        WerkzoekendeFaker faker = new WerkzoekendeFaker();
        var werkzoekende = faker.FakeWerkzoekende();        
        
        // Serialize to JSON
        //string json = JsonSerializer.Serialize(vacature, JsonConfig.DefaultOptions);
        //string json = JsonSerializer.Serialize(mpVacature, JsonConfig.DefaultOptions);
        string json = JsonSerializer.Serialize(werkzoekende, JsonConfig.DefaultOptions);
        // string json = JsonSerializer.Serialize(werkzoekende, JsonConfig.DefaultOptions);
        Console.WriteLine(json);
    }
}
