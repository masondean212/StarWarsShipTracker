using AutoMapper;
using Configuration;
using DTOs;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using System.Security.Claims;

namespace StarWarsSessionTracker.Controllers.Base;

public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    protected readonly IUserService _userService;
    protected readonly IMapper _mapper;
    protected readonly AppSettings _appSettings;

    protected ControllerBase(IOptions<AppSettings> options, IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _appSettings = options.Value;
        _userService = userService;
    }

    protected async Task<UserDTO?> GetCurrentUserAsync()
    {
        var userId = this.User.FindFirstValue("UserId");
        return userId == null ? null : await _userService.GetByIdAsync(int.Parse(userId));
    }
}
