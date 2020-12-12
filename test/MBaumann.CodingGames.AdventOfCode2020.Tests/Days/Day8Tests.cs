using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBaumann.CodingGames.AdventOfCode2020.Days;
using NFluent;
using Xunit;

namespace MBaumann.CodingGames.AdventOfCode2020.Tests.Days
{
    public class Day8Tests
    {
        public const string INPUT = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

        public const string CORRECTED_INPUT = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
nop -4
acc +6";

        [Fact]
        public void Part1()
        {
            _ = Day8.GetAccValue(INPUT, out var v_Value);
            Check.That(v_Value).IsEqualTo(5);
        }
        
        [Fact]
        public void Part2a()
        {
            Check.That(Day8.CorrectInput(INPUT)).IsEqualTo(CORRECTED_INPUT);
        }
        
        
        [Fact]
        public void Part2b()
        {
            _ = Day8.GetAccValue(Day8.CorrectInput(INPUT), out var v_Value);
            Check.That(v_Value).IsEqualTo(8);
        }
    }
}
