using System.IO;
using System.Text.Json;

namespace Casino
{
    public static class SaveGame
    {
        private static string subor = "save.json";

        public static void Save(Player player)
        {
            // Serializuje objekt Player do JSON formátu a uloží ho do súboru
            string json = JsonSerializer.Serialize(player, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(subor, json);
        }

        public static Player Load()
        {
            // Načíta uloženú hru zo súboru, ak existuje, inak vráti null
            if (!File.Exists(subor))
            {
                return null;
            }

            string json = File.ReadAllText(subor);
            return JsonSerializer.Deserialize<Player>(json);
        }
        public static void DeleteSave()
        {
            // Odstráni súbor so save hrou, ak existuje
            if (File.Exists(subor))
            {
                File.Delete(subor);
            }
        }
    }
}