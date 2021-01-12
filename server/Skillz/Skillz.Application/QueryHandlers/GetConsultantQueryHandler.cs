using MediatR;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Consultants;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.QueryHandlers
{
    public class GetConsultantQueryHandler : IRequestHandler<GetConsultantQuery, ConsultantDto>
    {

        private readonly IRepository<Consultant> _repo;
        private readonly IConsultantsDxos _dxo;

        // dependency Injection
        public GetConsultantQueryHandler(IRepository<Consultant> repo, IConsultantsDxos dxo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _dxo = dxo ?? throw new ArgumentNullException(nameof(dxo));

            // repo
        }

        public async Task<ConsultantDto> Handle(GetConsultantQuery request, CancellationToken cancellationToken)
        {
            var member = await _repo.GetAsync(c => c.IsDeleted == false && c.Id == request.Id);
            if (null != member)
            {
                // loggen
                return _dxo.MapConsultantDto(member);
            }

            throw new ApplicationException();
        }
    }
}
