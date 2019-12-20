using Newtonsoft.Json;
using System.IO;
using System;

namespace Kopiowanie
{
    class JsonFile
    {
        public string Link { get; set; }
        public string Content { get; set; }
        public string Hashes { get; set; }

        public JsonFile() { }

        ~JsonFile() { GC.Collect(); }

        private void SaveToFile(string path)
        {
            var jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, jsonData);
        }

        public static JsonFile LoadFromFile(string path)
        {
            var jsonData = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<JsonFile>(jsonData);
        }

        public void CreatJson(string link, string content, string path)
        {
            var json = new JsonFile()
            {
                Link = link,
                Content = content,
                Hashes = Hash.GetHashString(content)
            };

            json.SaveToFile(path);
        }
    }
}
