using Contracts.Repository;
using DTOs;
using Services.Interfaces;
using System.Linq;
using AutoMapper;
using Models;

namespace Services;

public class ShipServices : IShipServices
{
    private readonly IShipRepository _shipRepository;
    private readonly IMapper _mapper;
    public ShipServices(IShipRepository shipRepository, IMapper mapper) 
    {
        _shipRepository = shipRepository;
        _mapper = mapper;
    }
    public Task<IEnumerable<ShipDTO>> GetShipDetails()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ShipListItemDTO>> GetShipList()
    {
        var shipList = await _shipRepository.GetAllAsync();
        return shipList.Select(ship => new ShipListItemDTO()
                                        {
                                            Id = ship.Id,
                                            Name = ship.Name,
                                        }).ToList();
    }
}

