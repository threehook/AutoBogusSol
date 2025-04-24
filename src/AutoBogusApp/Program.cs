using System.Text.Json;
using AutoBogus;
using AutoBogusApp.DataGeneration;
using AutoBogusApp.Vum;

namespace AutoBogusApp;

public class Program
{

    static void Main(string[] args)
    {
        // Set global AutoBogus config to use Dutch locale
        AutoFaker.Configure(builder => { builder.WithLocale("nl"); });

        // Configure the faker
        var vacatureFaker = new AutoFakerExtensions.CustomAutoFaker<MPVacatureMatch>();
        AutoFakerExtensions.ApplyCustomAttributeRules<MPVacatureMatch>(vacatureFaker);
        
        // Generate data
        var vacature = vacatureFaker.Generate();       

        /*var werkzoekendeFaker = new AutoFakerExtensions.CustomAutoFaker<Werkzoekende>();
        AutoFakerExtensions.ApplyCustomAttributeRules<Werkzoekende>(werkzoekendeFaker);*/
        
        // Generate data
        // var werkzoekende = werkzoekendeFaker.Generate();
        
        
        string json = JsonSerializer.Serialize(vacature, JsonConfig.DefaultOptions);
        // string json = JsonSerializer.Serialize(werkzoekende, JsonConfig.DefaultOptions);
        
        Console.WriteLine(json);
    }
}