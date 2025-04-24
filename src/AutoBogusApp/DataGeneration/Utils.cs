using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using AutoBogus;
using AutoBogusApp.Vum;
using Bogus;

namespace AutoBogusApp.DataGeneration;

public static class JsonConfig
{
    public static readonly JsonSerializerOptions DefaultOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Prevents unwanted encoding
        WriteIndented = true, // Pretty-print JSON
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };
}


