﻿// ---------------------------------------------------------------
// Copyright (c) Hassan Habib & Alice Luo  All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using RESTFulSense.Controllers;
using RESTFulSense.Models;
using Tynamix.ObjectFiller;
using Xunit;

namespace RESTFulSense.Tests.Controllers
{
    public class RESTFulControllerTests
    {
        private readonly IRESTFulController restfulController;

        public RESTFulControllerTests() => 
            this.restfulController = new RESTFulController();

        [Fact]
        public void ShouldReturnLockedObject()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new LockedObjectResult(randomMessage);

            // when
            LockedObjectResult actualResult = 
                this.restfulController.Locked(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnBadGatewayObject()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new BadGatewayObjectResult(randomMessage);

            // when
            BadGatewayObjectResult actualResult =
                this.restfulController.BadGateway(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        private string GetRandomMessage() => new MnemonicString().GetValue();
    }
}
