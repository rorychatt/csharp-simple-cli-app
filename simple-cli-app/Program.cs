using System.Text.Json;

namespace Program
{
    public class Program
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        public static int Main(string[] args)
        {
            return 0;
        }
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
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(url, jsonString);
        }
    }
}