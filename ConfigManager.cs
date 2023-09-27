using Newtonsoft.Json;

namespace WOL
{

    internal class ConfigManager
    {
        private readonly string filePath;
        public readonly Config Config;

        public ConfigManager()
        {
            // Lấy đường dẫn của tệp config.ini cùng cấp với tệp thực thi của ứng dụng
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = Path.Combine(executablePath, "config.json");

            // Kiểm tra xem tệp config.ini có tồn tại hay không, nếu không thì tạo mới
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "{}");
            }
            Config = ReadFromFile<Config>();
        }

        public string? GetValue(string key)
        {
            return Config.GetPropertyValue(Config, key);
        }

        public void SetValue(string key, string value)
        {
            Config.SetPropertyValue(Config, key, value);
            WriteToFile(Config);
        }

        public T ReadFromFile<T>()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The JSON file does not exist.");
            }

            try
            {
                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonContent);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading JSON file: " + ex.Message);
            }
        }

        public void WriteToFile<T>(T data)
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonContent);
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing to JSON file: " + ex.Message);
            }
        }

        public string ReadValue(string section, string key)
        {
            if (!File.Exists(filePath)) return null;

            var lines = File.ReadAllLines(filePath);
            bool sectionFound = false;

            foreach (var line in lines)
            {
                if (line.Trim().StartsWith($"[{section}]"))
                {
                    sectionFound = true;
                }
                else if (sectionFound)
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2 && parts[0].Trim() == key)
                    {
                        return parts[1].Trim();
                    }
                }
            }

            return null;
        }

        public void WriteValue(string section, string key, string value)
        {
            var lines = File.Exists(filePath) ? File.ReadAllLines(filePath).ToList() : new List<string>();

            int sectionStartIndex = -1;
            int sectionEndIndex = -1;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Trim().StartsWith($"[{section}]"))
                {
                    sectionStartIndex = i;
                }
                else if (sectionStartIndex != -1 && lines[i].Trim() == "")
                {
                    sectionEndIndex = i;
                    break;
                }
            }

            if (sectionStartIndex != -1 && sectionEndIndex == -1)
            {
                sectionEndIndex = lines.Count;
            }

            if (sectionStartIndex == -1 || sectionEndIndex == -1)
            {
                // Section not found, add new section
                lines.Add($"[{section}]");
                lines.Add($"{key}={value}");
            }
            else
            {
                // Update existing section
                var sectionLines = lines.GetRange(sectionStartIndex, sectionEndIndex - sectionStartIndex);
                var keyLine = sectionLines.FindIndex(line => line.Trim().StartsWith(key));

                if (keyLine == -1)
                {
                    sectionLines.Add($"{key}={value}");
                }
                else
                {
                    sectionLines[keyLine] = $"{key}={value}";
                }

                lines.RemoveRange(sectionStartIndex, sectionLines.Count);
                lines.InsertRange(sectionStartIndex, sectionLines);
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
