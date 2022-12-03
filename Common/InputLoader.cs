    class InputLoader
    {
        public static List<string> LoadData(string fileName, string dayNumber)
        {
            List<string> logs = new List<string>();

            var filePath = Path.Combine(Environment.CurrentDirectory, $"Day{dayNumber}/" + fileName);
            var lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                logs.Add(line);
            }
            return logs;
        }
    }
