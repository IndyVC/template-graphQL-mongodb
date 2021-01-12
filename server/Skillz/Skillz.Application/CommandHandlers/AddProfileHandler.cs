using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Commands;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Profiles;
using Skillz.Models.Events;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.CommandHandlers
{
    public class AddProfileHandler : IRequestHandler<AddProfileCommand, ProfileDto>
    {
        private readonly IRepository<Company> _companiesRepo;
        private readonly IRepository<Profile> _profilesRepo;
        private readonly IProfilesDxos _profilesDxos;
        private readonly IMediator _mediator;

        public AddProfileHandler(IRepository<Profile> profilesRepo, IRepository<Company> companiesRepo, IMediator mediator, IProfilesDxos profilesDxos)
        {
            _profilesRepo = profilesRepo ?? throw new ArgumentNullException(nameof(IRepository<Profile>));
            _companiesRepo = companiesRepo ?? throw new ArgumentNullException(nameof(IRepository<Company>));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _profilesDxos = profilesDxos ?? throw new ArgumentNullException(nameof(profilesDxos));
        }

        public async Task<ProfileDto> Handle(AddProfileCommand request, CancellationToken cancellationToken)
        {


            var company = await _companiesRepo.GetAsync(c => c.Id == request.CompanyId);
            if (company == null)
            {
                //TODO: nog goed exception gooien
                throw new ApplicationException();
            }

            var profile = new Profile(
                request.Title,
                company.Id);



            _profilesRepo.Add(profile);

            if (await _profilesRepo.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            await _mediator.Publish(new ConsultantCreatedEvent(profile.Id), cancellationToken);
            var dto = _profilesDxos.MapProfiletDto(profile);

            return dto;



        }
    }
}
