using AutoMapper;
using Services.Interfaces;
using Contracts.Repository;
using DTOs;
using Models;

namespace Services;

public class UserService : IUserService
{
    private readonly ICryptoService _cryptoService;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(ICryptoService cryptoService, IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _cryptoService = cryptoService;
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDTO?> AuthenticateAsync(string username, string password)
    {
        var user = await _userRepository.GetByUserAsync(username);
        if (user == null) return null;
        var isPasswordValid = _cryptoService.VerifyPassword(password, user.HashedPassword, user.PasswordSalt);
        if (!isPasswordValid) return null;

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<UserDTO?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetAsync<UserModel>(id);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO?> CreateAsync(NewUserDTO dto)
    {
        _unitOfWork.Begin();
        var newUser = new UserModel();
        var salt = _cryptoService.GenerateSalt();
        newUser.Username = dto.Username;
        newUser.PasswordSalt = salt;
        newUser.HashedPassword = _cryptoService.HashPassword(dto.Password, salt);
        newUser.Roles = new List<RoleModel>();

        foreach (var role in dto.Roles)
        {
            var roleModel = await _userRepository.LoadAsync<RoleModel>(role.Id);
            newUser.Roles.Add(roleModel);
            roleModel.Users.Add(newUser);
            await _userRepository.SaveAsync(roleModel);
        }

        await _userRepository.SaveAsync(newUser);
        _unitOfWork.Commit();

        return _mapper.Map<UserDTO?>(newUser);
    }

    public async Task UpdateAsync(UserDTO dto)
    {
        _unitOfWork.Begin();
        var updatedUser = await _userRepository.GetAsync<UserModel>(dto.Id);
        await _userRepository.SaveAsync<UserModel>(updatedUser);
        _unitOfWork.Commit();
    }
    public async Task<List<RoleDTO>> GetRolesAsync()
    {
        var roles = await _userRepository.GetRolesAsync();
        return _mapper.Map<List<RoleDTO>>(roles);
    }
}
