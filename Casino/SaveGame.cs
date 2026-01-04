using System.IO;
using System.Text.Json;

namespace Casino
{
    public static class SaveGame
    {
        private static string subor = "save.json";

        public static void Save(Player player)
        {
            string json = JsonSerializer.Serialize(player, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(subor, json);
        }

        public static Player Load()
        {
            if (!File.Exists(subor))
            {
                return null;
            }

            string json = File.ReadAllText(subor);
            return JsonSerializer.Deserialize<Player>(json);
        }
    }
}