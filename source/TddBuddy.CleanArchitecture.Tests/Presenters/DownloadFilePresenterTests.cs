﻿using System;
using System.Web.Http;
using NSubstitute;
using NUnit.Framework;
using TddBuddy.CleanArchitecture.Domain.Messages;
using TddBuddy.CleanArchitecture.Domain.Output;
using TddBuddy.CleanArchitecture.HttpResponses;
using TddBuddy.CleanArchitecture.Presenters;

namespace TddBuddy.CleanArchitecture.Tests.Presenters
{
    [TestFixture]
    public class DownloadFilePresenterTests
    {
        [Test]
        public void Render_GivenFileResponse_ShouldReturnDownloadFileResult()
        {
            //---------------Set up test pack-------------------
            var fileOutput = CreateFileResult();

            var presenter = CreatePresenter();
            presenter.Respond(fileOutput);
            //---------------Execute Test ----------------------
            var result = presenter.Render() as DownloadFileResult;
            //---------------Test Result -----------------------
            Assert.IsNotNull(result);
            Assert.AreEqual(fileOutput, result.FileOutput);
        }

        [Test]
        public void Render_GivenErrorResponse_ShouldReturnUnprocessibleEntity()
        {
            //---------------Set up test pack-------------------
            var errorOutput = CreateErrorResult();

            var presenter = CreatePresenter();
            presenter.Respond(errorOutput);
            //---------------Execute Test ----------------------
            var result = presenter.Render() as UnprocessasbleEntityResult<ErrorOutputMessage>;
            //---------------Test Result -----------------------
            Assert.IsNotNull(result);
            Assert.AreEqual(errorOutput, result.Content);
        }

        [Test]
        public void Render_GivenFileAndErrorResponse_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var errorOutput = CreateErrorResult();
            var fileOutput = CreateFileResult();

            var presenter = CreatePresenter();
            presenter.Respond(errorOutput);
            presenter.Respond(fileOutput);
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<InvalidOperationException>(() => presenter.Render());
            //---------------Test Result -----------------------
            Assert.AreEqual("Only one response allowed", exception.Message);
        }

        [Test]
        public void Render_GivenNoResponse_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var presenter = CreatePresenter();
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<InvalidOperationException>(() => presenter.Render());
            //---------------Test Result -----------------------
            Assert.AreEqual("No response specified", exception.Message);
        }

        private ErrorOutputMessage CreateErrorResult()
        {
            return new ErrorOutputMessage();
        }

        private IFileOutput CreateFileResult()
        {
            return Substitute.For<IFileOutput>();
        }

        private DownloadFilePresenter CreatePresenter()
        {
            var apiController = Substitute.For<ApiController>();
            return new DownloadFilePresenter(apiController);
        }

    }
}