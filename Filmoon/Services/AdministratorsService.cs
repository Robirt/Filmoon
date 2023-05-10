using Filmoon.Entities;
using Filmoon.Repositories;
using Filmoon.Requests;
using Filmoon.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class AdministratorsService
{
    public AdministratorsService(AdministratorsRepository administratorsRepository)
    {
        AdministratorsRepository = administratorsRepository;
    }

    private AdministratorsRepository AdministratorsRepository { get; }

    public async Task<List<AdministratorEntity>?> GetAsync()
    {
        return await AdministratorsRepository.GetAsync();
    }

    public async Task<ActionResponse?> AddAsync(SignUpRequest signUpRequest)
    {
        return await AdministratorsRepository.AddAsync(signUpRequest);
    }
}
