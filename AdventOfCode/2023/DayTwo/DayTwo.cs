
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace _2023
{
    public class DayTwo
    {
        public static string Solve(string filePath)
        {
            using (StreamReader reader = File.OpenText(filePath))
            {
                var total = 0;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    //Game 3: 6 green, 15 red; 1 green, 4 red, 7 blue; 9 blue, 7 red, 8 green
                    // 12 R
                    // 13 G
                    // 14 B
                    var maxRed = 12;
                    var maxGreen = 13;
                    var maxBlue = 14;
                    var gameInfo = line.Split(':',StringSplitOptions.TrimEntries);
                    var gameID = int.Parse(Regex.Match(gameInfo[0],"\\d+").Value);
                    var gameDetails = gameInfo[1].Split(';',StringSplitOptions.TrimEntries);
                    bool isPossible = true;
                    foreach(var detail in gameDetails){
                        if(!isPossible)
                        {
                            break;
                        }
                        var roundDetails = detail.Split(',',StringSplitOptions.TrimEntries);
                        foreach(var rDetail in roundDetails)
                        {
                            if(!isPossible)
                            {
                                break;
                            }
                            if(rDetail.Contains("red") && int.Parse(Regex.Match(rDetail,"\\d+").Value) > maxRed)
                            {
                                isPossible = false;
                            }
                            if(rDetail.Contains("green")&& int.Parse(Regex.Match(rDetail,"\\d+").Value) > maxGreen)
                            {
                                isPossible = false;
                            }
                            if(rDetail.Contains("blue")&& int.Parse(Regex.Match(rDetail,"\\d+").Value) > maxBlue)
                            {
                                isPossible = false;
                            }
                        }
                    }
                    if(isPossible) {total+=gameID;}
                }
                return total.ToString();
            }
        }
    }
}