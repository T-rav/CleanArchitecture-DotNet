﻿using NUnit.Framework;
using TddBuddy.CleanArchitecture.Utils.TOs;

namespace TddBuddy.CleanArchitecture.Utils.Tests.TOs
{
    [TestFixture]
    public class ErrorOutputToTests
    {
        [Test]
        public void FetchErrors_WhenConstructed_ShouldReturnList()
        {
            //---------------Set up test pack-------------------
            //---------------Execute Test ----------------------
            var result = new ErrorOutputTo();
            //---------------Test Result -----------------------
            Assert.NotNull(result.Errors);
        }

        [Test]
        public void HasErrors_WhenNoErrors_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var errorOutputTo = new ErrorOutputTo();
            //---------------Execute Test ----------------------
            var result = errorOutputTo.HasErrors;
            //---------------Test Result -----------------------
            Assert.False(result);
        }

        [Test]
        public void HasErrors_WhenErrors_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var errorOutputTo = new ErrorOutputTo();
            errorOutputTo.AddError("test error");
            //---------------Execute Test ----------------------
            var result = errorOutputTo.HasErrors;
            //---------------Test Result -----------------------
            Assert.True(result);
        }
    }
}
