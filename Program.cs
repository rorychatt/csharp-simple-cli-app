﻿using System.Text.Json;

public class Apps
{

    public class ReadableData
    {
        public required string Name { get; set; }
    }
    public static List<ReadableData> ReadJSONFile(string url)
    {
        string jsonString = File.ReadAllText(url);
        List<ReadableData> data = JsonSerializer.Deserialize<List<ReadableData>>(jsonString);
        return data;
    }

    public static void WriteToJSONFile(string url, List<ReadableData> data)
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(url, jsonString);
    }
}