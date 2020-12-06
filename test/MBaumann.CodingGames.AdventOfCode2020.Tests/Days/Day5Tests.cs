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
    public class Day5Tests
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void Part1(string p_BoardingPass, byte p_Row, byte p_Col, int p_SeatID)
        {
            (byte v_Row, byte v_Col) = Day5.GetSeatCoords(p_BoardingPass);

            Check.That(v_Row).IsEqualTo(p_Row);
            Check.That(v_Col).IsEqualTo(p_Col);
            Check.That(Day5.GetSeatId(v_Row, v_Col)).IsEqualTo(p_SeatID);
        }
    }
}
