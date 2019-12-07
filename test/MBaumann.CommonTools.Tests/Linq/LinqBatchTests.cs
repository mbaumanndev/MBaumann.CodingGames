using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MBaumann.CommonTools.Linq;

namespace MBaumann.CommonTools.Tests.Linq
{
    public sealed class LinqBatchTests
    {
        [Fact]
        public void Part1ComputerTests()
        {
            var v_Expected = new int[4][] { new int[] { 1 }, new int[] { 2 }, new int[] { 3 }, new int[1] { 4 } };
            var v_Input = new int[4] { 1, 2, 3, 4 };

            Assert.Equal(v_Expected, v_Input.Batch(1));
        }
    }
}
