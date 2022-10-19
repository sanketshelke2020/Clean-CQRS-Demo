﻿using Clean.Identity.UnitTests.Fakes;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Clean.Identity.UnitTests.Mocks
{
    public class SignInManagerMocks
    {
        public static Mock<FakeSignInManager> GetSignInManager()
        {
            var mockSigninManager = new Mock<FakeSignInManager>();

            mockSigninManager.Setup(sm => sm.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync((string userName, string password, bool isPersistent, bool lockoutOnFailure) =>
                {
                    if (password == null)
                        return SignInResult.Success;
                    return SignInResult.Failed;
                });

            return mockSigninManager;
        }
    }
}
