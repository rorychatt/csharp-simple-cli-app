using System.Text.Json;

namespace simple_cli_app.Program
{
    public class App
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        public static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0: throw new ArgumentException("Please provide some arguments, like 'read data.json'");
                case 1: throw new ArgumentException("Please provide name of the .JSON file to read or write to");
                case 2:
                    {
                        processInput(args);
                        break;
                    }
                default: throw new ArgumentException("Too many parameters!");
            }
        }

        private static void processInput(string[] args)
        {
            var operation = checkForOperation(args);
        }

        private static string checkForOperation(string[] args)
        {
            return args[0] switch
            {
                "r" => "r",
                "w" => "w",
                _ => throw new ArgumentException("Only r - read and w - write tags are supported"),
            };
        }

        public class ReadableData
        {
            public required string Name { get; set; }
        }
        public static List<ReadableData> ReadJSONFile(string url)
        {
            string jsonString = File.ReadAllText(url);
            List<ReadableData> data = JsonSerializer.Deserialize<List<ReadableData>>(jsonString)!;
            return data;
        }

        public static void WriteToJSONFile(string url, List<ReadableData> data)
        {
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(url, jsonString);
        }
    }
}