class CalorieCounting {
    internal List<int> createElfList(List<string> calorieLog){
        var elfList = new List<int>();
        var currentCalories = 0;

        foreach(var logEntry in calorieLog){
            if(logEntry.Length > 0){
                currentCalories += Int32.Parse(logEntry);
            } else {
                elfList.Add(currentCalories);
                currentCalories = 0;
            }
         }
         return elfList;
    }


    internal void Play(){
        List<string> calorieLog = LoadData("day1.txt");

        var elfList = createElfList(calorieLog);
        elfList.Sort();
        var firstEntry = elfList[elfList.Count - 1];
        var lastThreeEntries = elfList.GetRange(elfList.Count - 3, 3).Sum();

        Console.WriteLine($"Day1: Max calorie entry: {firstEntry}, Top three elves: {lastThreeEntries}");
    }

    private List<string> LoadData(string fileName)
    {
        List<string> logs = new List<string>();

        var filePath = Path.Combine(Environment.CurrentDirectory, "Day1/" + fileName);
        var lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            logs.Add(line);
        }
        return logs;
    }
}