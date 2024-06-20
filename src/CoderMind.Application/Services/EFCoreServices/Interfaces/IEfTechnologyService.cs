﻿using CoderMind.Shared.Dtos.TechnologyDtos;

namespace CoderMind.Application.Services.EFCoreServices.Interfaces;

public interface IEfTechnologyService
{
    Task<IEnumerable<GetTechnologySubjectsDto>> GetTechnologySubjectsAsync(CancellationToken cancellationToken = default);
    Task<GetTechnologyDto> GetTechnologyAsync(string id, CancellationToken cancellationToken = default);
    Task CreateTechnologyAsync(CreateTechnologyDto createTechnologyDto, CancellationToken cancellationToken = default);
    Task DeleteTechnologyAsync(string id, CancellationToken cancellationToken = default);
    Task UpdateTechnologyAsync(UpdateTechnologyDto updateTechnologyDto, CancellationToken cancellationToken = default);
}
