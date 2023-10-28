using System.ComponentModel.Design;
using AutoMapper;
using Configuration;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using ControllerBase = StarWarsSessionTracker.Controllers.Base.ControllerBase;

namespace StarWarsSessionTracker.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    public UsersController(IOptions<AppSettings> options, IMapper mapper, IUserService userService) : base(options, mapper, userService)
    {
    }

    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] NewUserDTO dto)
    {
        var newUser = await _userService.CreateAsync(dto);
        return Ok(newUser);
    }
    [HttpGet("getroles")]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _userService.GetRolesAsync();
        return Ok(roles);
    }
}
