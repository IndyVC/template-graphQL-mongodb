using MediatR;
using Microsoft.EntityFrameworkCore;
using Skillz.Application.Dxos;
using Skillz.Contracts.Commands;
using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Skills;
using Skillz.Models.Events;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.CommandHandlers
{
    public class AddSkillGroupHandler : IRequestHandler<AddSkillGroupCommand, SkillGroupDto>
    {
        private readonly IRepository<SkillGroup> _repo;
        private readonly IMediator _mediator;
        private readonly ISkillGroupsDxos _dxo;

        public AddSkillGroupHandler(IRepository<SkillGroup> repo, IMediator mediator, ISkillGroupsDxos dxo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(IRepository<SkillGroup>)); ;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _dxo = dxo ?? throw new ArgumentNullException(nameof(dxo));
        }

        public async Task<SkillGroupDto> Handle(AddSkillGroupCommand request, CancellationToken cancellationToken)
        {
            var skill = new SkillGroup(
                request.Title,
                request.CompanyId);



            _repo.Add(skill);

            if (await _repo.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            //await _mediator.Publish(new ConsultantCreatedEvent(employee.Id), cancellationToken);

            var nw = await _repo.Query(e => e.Id == skill.Id).SingleAsync();
            var dto = _dxo.MapSkillGroupDto(nw);

            return dto;
        }
    }
}
