using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoBogusApp.DataGeneration;
// using AutoBogusApp.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register the chain providers
        // builder.Services.AddScoped<IMatchProvider, RepoMatchProvider>();
        // builder.Services.AddScoped<IMatchProvider, FakerMatchProvider>();
        // builder.Services.AddScoped<IChainProvider, ChainProvider>();
        
        
        VacatureFaker faker = new VacatureFaker();
        //var vacature = faker.FakeVacature();
        var vacature = faker.FakeVacature();
        
        // WerkzoekendeFaker faker = new WerkzoekendeFaker();
        //var werkzoekende = faker.FakeWerkzoekende();
        // var werkzoekende = faker.FakeMpWerkzoekendeMatch();
        
        // Serialize to JSON
        string json = JsonSerializer.Serialize(vacature, JsonConfig.DefaultOptions);
        //string json = JsonSerializer.Serialize(mpVacature, JsonConfig.DefaultOptions);
        // string json = JsonSerializer.Serialize(werkzoekende, JsonConfig.DefaultOptions);
        // string json = JsonSerializer.Serialize(werkzoekende, JsonConfig.DefaultOptions);
        Console.WriteLine(json);
    }
}
