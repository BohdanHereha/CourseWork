using System;
using System.Numerics;
using System.Reflection;
using IIG.BinaryFlag;
using Xunit;

namespace WhiteBoxTesting
{
    public class WBT
    {
        MultipleBinaryFlag multipleBinaryFlag_1 = new MultipleBinaryFlag(6, true);
        MultipleBinaryFlag multipleBinaryFlag_2 = new MultipleBinaryFlag(16, false);
        MultipleBinaryFlag multipleBinaryFlag_3 = new MultipleBinaryFlag(196, true);
        MultipleBinaryFlag multipleBinaryFlag_4 = new MultipleBinaryFlag(69);

        [Fact]
        public void NotNullTest()
        {
            Assert.NotNull(multipleBinaryFlag_1);
            Assert.NotNull(multipleBinaryFlag_1.ToString());
        }

        [Fact]
        public void SecondArgumentIsMissing()
        {
            Assert.True(multipleBinaryFlag_4.GetFlag());
            Assert.Equal("True", multipleBinaryFlag_4.GetFlag().ToString());
        }

        [Fact]
        public void ObjectEqualsFalse1()
        {
            Assert.False(multipleBinaryFlag_1.Equals(multipleBinaryFlag_2));
        }

        [Fact]
        public void ObjectEqualsFalse2()
        {
            Assert.False(multipleBinaryFlag_1.Equals(multipleBinaryFlag_3));
        }

        [Fact]
        public void MinLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(1, true));
        }

        [Fact]
        public void MaxLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868705, true));
        }

        [Fact]
        public void ClassName()
        {
            Assert.Equal("MultipleBinaryFlag", multipleBinaryFlag_1.GetType().Name);
        }

        [Fact]
        public void GetFlagTrue()
        {
            Assert.True(multipleBinaryFlag_1.GetFlag());
            Assert.Equal("True", multipleBinaryFlag_1.GetFlag().ToString());
        }

        [Fact]
        public void GetFlagFalse()
        {
            Assert.False(multipleBinaryFlag_2.GetFlag());
            Assert.Equal("False", multipleBinaryFlag_2.GetFlag().ToString());
        }

        [Fact]
        public void SetFlagLessPosstion()
        {
            multipleBinaryFlag_1.SetFlag(5);
            Assert.True(multipleBinaryFlag_1.GetFlag());
            Assert.Equal("True", multipleBinaryFlag_1.GetFlag().ToString());
        }

        [Fact]
        public void SetFlagLessGreaterThanOrEqualPosstion()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => multipleBinaryFlag_1.SetFlag(6));
        }

        [Fact]
        public void ResetFlagLessGreaterThanOrEqualPosstion()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => multipleBinaryFlag_1.ResetFlag(6));
        }

        [Fact]
        public void ResetFlagFalse()
        {
            multipleBinaryFlag_1.ResetFlag(5);
            Assert.Equal("False", multipleBinaryFlag_1.GetFlag().ToString());
            Assert.False(multipleBinaryFlag_1.GetFlag());
            Assert.Equal("False", multipleBinaryFlag_1.GetFlag().ToString());
        }

        [Fact]
        public void ResetAndSetFlag()
        {
            multipleBinaryFlag_1.ResetFlag(5);
            multipleBinaryFlag_1.ResetFlag(4);
            multipleBinaryFlag_1.SetFlag(5);
            multipleBinaryFlag_1.SetFlag(4);
            Assert.True(multipleBinaryFlag_1.GetFlag());
            Assert.Equal("True", multipleBinaryFlag_1.GetFlag().ToString());
        }

        [Fact]
        public void TrueGetFlagIfAllPositionSetFlag()
        {
            for (uint i = 0; i < 16; i++)
            {
                multipleBinaryFlag_2.SetFlag(i);
            }
            Assert.True(multipleBinaryFlag_2.GetFlag());
            Assert.Equal("True", multipleBinaryFlag_1.GetFlag().ToString());
        }

        [Fact]
        public void DisposeNotNull()
        {
            multipleBinaryFlag_2.Dispose();
            Assert.NotNull(multipleBinaryFlag_2);
            Assert.NotNull(multipleBinaryFlag_2.ToString());
        }
    }
}