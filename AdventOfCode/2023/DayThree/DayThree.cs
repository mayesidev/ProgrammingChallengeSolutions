using System.Text.RegularExpressions;

namespace _2023
{
    public class DayThree
    {
        public static string Solve(string filePath)
        {
            var partOneTotal = 0;
            var nums = new HashSet<NumLocation>();
            var symbols = new HashSet<SymbolLocation>();
            using (StreamReader reader = File.OpenText(filePath))
            {
                var lineIndex = 0;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    var matches = Regex.Matches(line, "(\\d+)|([^a-zA-Z0-9.\\s])");
                    foreach (Match match in matches)
                    {
                        var foundMatch = match.Value;
                        if (int.TryParse(foundMatch, out int foundNum) && !nums.Any(num => num.num.Equals(foundNum) && num.line == lineIndex))
                        {
                            // add all index occurances of a found number where there is not another digit preceding or following (ie, 32 shouldn't match 632)
                            for (int i = line.IndexOf(foundMatch); i > -1; i = line.IndexOf(foundMatch, i + 1))
                            {
                                var parsedNumBefore = i > 0 && int.TryParse(line[i - 1].ToString(), out int charBefore);
                                var parsedNumAfter = i + foundMatch.Length < line.Length && int.TryParse(line[i + foundMatch.Length].ToString(), out int charAfter);
                                if (!parsedNumBefore && !parsedNumAfter)
                                {
                                    nums.Add(new NumLocation(lineIndex, i, foundNum));
                                }
                            }
                        }
                        else
                        {
                            if (!symbols.Any(symbol => symbol.symbol.Equals(foundMatch) && symbol.line == lineIndex))
                            {
                                // add all index occurances of a found symbol at once
                                for (int i = line.IndexOf(foundMatch); i > -1; i = line.IndexOf(foundMatch, i + 1))
                                {
                                    symbols.Add(new SymbolLocation(lineIndex, i, foundMatch, []));
                                }
                            }
                        }
                    }
                    lineIndex++;
                }
            }

            foreach (var num in nums)
            {
                var lineBeforeNum = num.line - 1;
                var lineAfterNum = num.line + 1;
                var numStartIndex = num.index - 1;
                var numEndIndex = num.index + num.num.ToString().Length; // start index + length of num to get end index
                var touchingSymbols = symbols.Where(symbol =>
                    (symbol.line == num.line && (symbol.index == numStartIndex || symbol.index == numEndIndex)) // same line, immediately before or after
                    || (symbol.line == lineBeforeNum && symbol.index >= numStartIndex && symbol.index <= numEndIndex) // line before, any touching index (-1,match,+1)
                    || (symbol.line == lineAfterNum && symbol.index >= numStartIndex && symbol.index <= numEndIndex) // line after, any touching index (-1,matched,+1)
                    );
                if (touchingSymbols.Any())
                {
                    Console.WriteLine($"{num.num} on line {num.line} touches something");
                    partOneTotal += num.num;

                    foreach(var symbol in touchingSymbols)
                    {
                        if(symbol.symbol.Equals("*"))
                        {
                            symbol.touchingNums.Add(num.num);
                        }
                    }
                }
            }

            var partTwoTotal = symbols.Where(symbol=>symbol.touchingNums.Count==2).Sum(symbol=>symbol.touchingNums.Aggregate((first,next)=>first*next));

            return $"{partOneTotal}, {partTwoTotal}";
        }

        internal class NumLocation(int line, int index, int num)
        {
            public int line = line;
            public int index = index;
            public int num = num;
        }

        internal class SymbolLocation(int line, int index, string symbol, List<int> touchingNums)
        {
            public int line = line;
            public int index = index;
            public string symbol = symbol;
            public List<int> touchingNums = touchingNums;
        }
    }
}
