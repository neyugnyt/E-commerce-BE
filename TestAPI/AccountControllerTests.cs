using AutoMapper;
using Core.Entiies.Identity;
using Core.Interface;
using E_commerce_API.Controllers;
using E_commerce_API.Errors;
using Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

public class AccountControllerTests
{
    private readonly Mock<UserManager<AppUser>> _userManagerMock;
    private readonly Mock<SignInManager<AppUser>> _signInManagerMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly Mock<IMapper> _mapperMock;


// No other changes are needed in the file.
    public AccountControllerTests()
    {
        var userStoreMock = new Mock<IUserStore<AppUser>>();
        _userManagerMock = new Mock<UserManager<AppUser>>(
            userStoreMock.Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<AppUser>>().Object,
            Array.Empty<IUserValidator<AppUser>>(),
            Array.Empty<IPasswordValidator<AppUser>>(),
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<AppUser>>>().Object
        );

        var contextAccessor = new Mock<IHttpContextAccessor>();
        var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>();
        _signInManagerMock = new Mock<SignInManager<AppUser>>(
            _userManagerMock.Object,
            contextAccessor.Object,
            userPrincipalFactory.Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<AppUser>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object,
            new Mock<IUserConfirmation<AppUser>>().Object
        );

        _tokenServiceMock = new Mock<ITokenService>();
        _mapperMock = new Mock<IMapper>();
    }

    private AccountController CreateController()
    {
        var controller = new AccountController(
            _userManagerMock.Object,
            _signInManagerMock.Object,
            _tokenServiceMock.Object,
            _mapperMock.Object
        );
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        return controller;
    }

    [Fact]
    public async Task CheckEmailExistsAsync_ReturnsTrue_IfEmailExists()
    {
        // Arrange
        var email = "test@example.com";
        _userManagerMock.Setup(x => x.FindByEmailAsync(email))
            .ReturnsAsync(new AppUser { Email = email });

        var controller = CreateController();

        // Act
        var result = await controller.CheckEmailExistsAsync(email);

        // Assert
        Assert.True(result.Value);
    }

    [Fact]
    public async Task CheckEmailExistsAsync_ReturnsBadRequest_IfEmailIsNull()
    {
        var controller = CreateController();

        var result = await controller.CheckEmailExistsAsync(null);

        var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.IsType<ApiResponse>(badRequest.Value);
    }

    [Fact]
    public async Task Login_ReturnsUnauthorized_IfUserNotFound()
    {
        var loginDto = new LoginDTO { Email = "notfound@example.com", Password = "Password1!" };
        _userManagerMock.Setup(x => x.FindByEmailAsync(loginDto.Email))
            .ReturnsAsync((AppUser)null);

        var controller = CreateController();

        var result = await controller.Login(loginDto);

        var unauthorized = Assert.IsType<UnauthorizedObjectResult>(result.Result);
        Assert.IsType<ApiResponse>(unauthorized.Value);
    }

    [Fact]
    public async Task Login_ReturnsUserDTO_IfLoginSuccessful()
    {
        var loginDto = new LoginDTO { Email = "user@example.com", Password = "Password1!" };
        var user = new AppUser { Email = loginDto.Email, DisplayName = "User" };
        _userManagerMock.Setup(x => x.FindByEmailAsync(loginDto.Email)).ReturnsAsync(user);
        _signInManagerMock.Setup(x => x.CheckPasswordSignInAsync(user, loginDto.Password, false))
            .ReturnsAsync(SignInResult.Success);
        _tokenServiceMock.Setup(x => x.CreateToken(user)).Returns("token");

        var controller = CreateController();

        var result = await controller.Login(loginDto);

        var userDto = Assert.IsType<UserDTO>(result.Value);
        Assert.Equal("User", userDto.DisplayName);
        Assert.Equal("user@example.com", userDto.Email);
        Assert.Equal("token", userDto.Token);
    }

    [Fact]
    public async Task Register_ReturnsBadRequest_IfEmailExists()
    {
        var registerDto = new RegisterDTO { Email = "exists@example.com", DisplayName = "User", Password = "Password1!" };
        _userManagerMock.Setup(x => x.FindByEmailAsync(registerDto.Email)).ReturnsAsync(new AppUser());

        var controller = CreateController();

        var result = await controller.Register(registerDto);

        var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.IsType<ApiResponse>(badRequest.Value);
    }

    [Fact]
    public async Task Register_ReturnsUserDTO_IfRegistrationSuccessful()
    {
        var registerDto = new RegisterDTO { Email = "new@example.com", DisplayName = "User", Password = "Password1!" };
        _userManagerMock.Setup(x => x.FindByEmailAsync(registerDto.Email)).ReturnsAsync((AppUser)null);
        _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), registerDto.Password))
            .ReturnsAsync(IdentityResult.Success);
        _tokenServiceMock.Setup(x => x.CreateToken(It.IsAny<AppUser>())).Returns("token");

        var controller = CreateController();

        var result = await controller.Register(registerDto);

        var userDto = Assert.IsType<UserDTO>(result.Value);
        Assert.Equal("User", userDto.DisplayName);
        Assert.Equal("new@example.com", userDto.Email);
        Assert.Equal("token", userDto.Token);
    }
}