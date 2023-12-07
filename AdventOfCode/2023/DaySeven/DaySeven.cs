namespace _2023
{
    public class DaySeven
    {
        private Dictionary<Hand, int> hands = [];
        private int startRank = 1;
        public string Solve(string filePath)
        {
            var total = 0;
            using (StreamReader reader = File.OpenText(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    var input = line.Split(' ', StringSplitOptions.TrimEntries);
                    hands.Add(new Hand(input[0]), int.Parse(input[1]));
                }
            }

            total += ScoreHandsByType(HandType.High);
            total += ScoreHandsByType(HandType.One);
            total += ScoreHandsByType(HandType.Two);
            total += ScoreHandsByType(HandType.Three);
            total += ScoreHandsByType(HandType.Full);
            total += ScoreHandsByType(HandType.Four);
            total += ScoreHandsByType(HandType.Five);

            return total.ToString();
        }

        private int ScoreHandsByType(HandType handType)
        {
            var runningTotal = 0;
            var selectedHands = hands.Where(hand => hand.Key.GetHandType() == handType);
            var sortedHands = selectedHands.OrderBy(hand => hand.Key);
            foreach (var hand in sortedHands)
            {
                Console.WriteLine($"Scoring hand: {hand.Key.cards} with type: {handType} with bet: {hand.Value} in rank: {startRank}.");
                runningTotal += hand.Value * startRank;
                startRank++;
                hands.Remove(hand.Key);
            }
            return runningTotal;
        }

        internal class Hand(string cards) : IComparable
        {
            public string cards = cards;

            public HandType GetHandType()
            {
                var handType = HandType.High;
                Dictionary<char, int> cardCount = cards.Distinct().ToDictionary(card1 => card1, card2 => cards.Count(card3 => card3 == card2));

                if (cardCount.TryGetValue('J', out int jokerCount))
                {
                    cardCount.Remove('J');
                    if (jokerCount == 5)
                    {
                        cardCount.Add('A', 5);
                    }
                    else
                    {
                        var mostCard = cardCount.Values.Max();
                        cardCount[cardCount.First(card => card.Value == mostCard).Key] = mostCard + jokerCount;
                    }
                }

                if (cardCount.Count == 1)
                {
                    handType = HandType.Five;
                }
                else if (cardCount.Count == 2)
                {
                    var firstCardCount = cardCount.First().Value;
                    if (firstCardCount == 1 || firstCardCount == 4)
                    {
                        handType = HandType.Four;
                    }
                    else
                    {
                        handType = HandType.Full;
                    }
                }
                else if (cardCount.Count == 3)
                {
                    var mostCardCount = cardCount.Max(card => card.Value);
                    if (mostCardCount == 3)
                    {
                        handType = HandType.Three;
                    }
                    else
                    {
                        handType = HandType.Two;
                    }
                }
                else if (cardCount.Count == 4)
                {
                    handType = HandType.One;
                }
                return handType;
            }

            public int CompareTo(object? obj)
            {
                var diff = 0;
                if (obj == null) diff = 1;

                if (obj is Hand otherHand)
                {
                    for (var i = 0; i < cards.Length; i++)
                    {
                        var diffCards = DetermineCardValue(cards[i]).CompareTo(DetermineCardValue(otherHand.cards[i]));
                        if (diffCards != 0)
                        {
                            diff = diffCards;
                            break;
                        }
                    }
                }
                return diff;
            }

            private static int DetermineCardValue(char card)
            {
                var value = 0;
                if (int.TryParse(card.ToString(), out int parsedCard))
                {
                    value = parsedCard;
                }
                else
                {
                    switch (card)
                    {
                        case 'T':
                            value = 10;
                            break;
                        case 'J':
                            value = 1;
                            break;
                        case 'Q':
                            value = 12;
                            break;
                        case 'K':
                            value = 13;
                            break;
                        case 'A':
                            value = 14;
                            break;
                    }
                }
                return value;
            }
        }

        internal enum HandType
        {
            Five,
            Four,
            Full,
            Three,
            Two,
            One,
            High
        }
    }
}
