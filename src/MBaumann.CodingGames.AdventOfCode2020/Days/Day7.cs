using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    public static class Day7
    {
        private const string NO_OTHER_BAGS = "no other bags";
        private const string BAGS_CONTAIN = " bags contain ";
        private const string SHINY_GOLD = "shiny gold";
        private static readonly Regex BAG_COUNT_REGEX = new (@"(?<number>\d) (?<bag>[a-z ]+) bag(s)?", RegexOptions.Compiled);
        private static readonly InnerBag NO_INNER_BAG = new (0, NO_OTHER_BAGS);
        
        public static int FirstPart()
        {
            return CountBagColorsThatContainAtLeastOneShinyGoldBag(
                File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day7.txt"));
        }
        public static long SecondPart()
        {
            return CountBagsInsideShinyGoldBag(
                File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day7.txt"));
        }
        
        public static int CountBagColorsThatContainAtLeastOneShinyGoldBag(string p_Input)
        {
            var v_BagsAndColors = Preparebags(p_Input);

            var v_VisitedBags = new Dictionary<string, int>
            {
                { NO_OTHER_BAGS, 0 }
            };

            do
            {
                var v_Bag = v_BagsAndColors.First(b => !v_VisitedBags.ContainsKey(b.Key));
                
                CountShinyGoldBagsForBranch(v_Bag.Key, v_BagsAndColors, v_VisitedBags);
                
                
            } while (v_VisitedBags.Count - 1 != v_BagsAndColors.Count);

            return v_VisitedBags.Count(b => b.Value > 0);
        }

        private static void CountShinyGoldBagsForBranch(string p_Bag,
            Dictionary<string, InnerBag[]> p_BagsAndColors,
            Dictionary<string, int> p_BagCounts)
        {
            if (p_BagCounts.ContainsKey(p_Bag))
                return;

            var v_Bags = p_BagsAndColors[p_Bag];
            var v_Count = 0;
            
            foreach (var v_BagCount in v_Bags)
            {
                if (v_BagCount.Name == SHINY_GOLD)
                {
                    v_Count += v_BagCount.Count;
                }
                else
                {
                    
                    CountShinyGoldBagsForBranch(v_BagCount.Name, p_BagsAndColors, p_BagCounts);
                    v_Count += p_BagCounts[v_BagCount.Name];
                }
            }
            
            p_BagCounts.Add(p_Bag, v_Count);
        }

        public static long CountBagsInsideShinyGoldBag(string p_Input)
        {
            var v_BagsAndColors = Preparebags(p_Input);

            var v_VisitedBags = new Dictionary<string, long>
            {
                { NO_OTHER_BAGS, 0 }
            };

            do
            {
                var v_Bag = v_BagsAndColors.First(b => !v_VisitedBags.ContainsKey(b.Key));
                
                CountHoldedBags(v_Bag.Key, v_BagsAndColors, v_VisitedBags);
                
                
            } while (v_VisitedBags.Count - 1 != v_BagsAndColors.Count);

            return v_VisitedBags[SHINY_GOLD];
        }

        private static void CountHoldedBags(string p_Bag,
            Dictionary<string, InnerBag[]> p_BagsAndColors,
            Dictionary<string, long> p_BagCounts)
        {
            if (p_BagCounts.ContainsKey(p_Bag))
                return;

            var v_Bags = p_BagsAndColors[p_Bag];
            long v_Count = 0;
            
            foreach (var v_BagCount in v_Bags)
            {
                if (v_BagCount.Name != NO_OTHER_BAGS)
                {
                    CountHoldedBags(v_BagCount.Name, p_BagsAndColors, p_BagCounts);
                    v_Count += v_BagCount.Count + v_BagCount.Count * p_BagCounts[v_BagCount.Name];
                }
            }
            
            p_BagCounts.Add(p_Bag, v_Count);
        }

        private static Dictionary<string, InnerBag[]> Preparebags(string p_Input)
        {
            var v_BagsAndColors = new Dictionary<string, InnerBag[]>();

            foreach (var v_Line in p_Input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var v_BagAndContent = v_Line.Split(new[] { BAGS_CONTAIN }, StringSplitOptions.None);

                if (v_BagAndContent[1].TrimEnd('.') == NO_OTHER_BAGS)
                {
                    v_BagsAndColors.Add(v_BagAndContent[0], new []{ NO_INNER_BAG });
                }
                else
                {
                    var v_OtherBags = v_BagAndContent[1].TrimEnd('.').Split(new[] {','}).Select(b =>
                    {
                        var v_Match = BAG_COUNT_REGEX.Match(b);
                        return new InnerBag(int.Parse(v_Match.Groups["number"].Value), v_Match.Groups["bag"].Value);
                    }).ToArray();
                    
                    v_BagsAndColors.Add(v_BagAndContent[0], v_OtherBags);
                }
            }

            return v_BagsAndColors;
        }
    }

    public record InnerBag(int Count, string Name);
}