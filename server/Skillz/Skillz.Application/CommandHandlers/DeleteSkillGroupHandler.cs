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
    public class DeleteSkillGroupHandler : IRequestHandler<DeleteSkillGroupCommand, SkillGroupDto>
    {
        private readonly IRepository<SkillGroup> _repo;
        private readonly IMediator _mediator;

        public DeleteSkillGroupHandler(IRepository<SkillGroup> repo, IMediator mediator)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(IRepository<SkillGroup>)); ;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<SkillGroupDto> Handle(DeleteSkillGroupCommand request, CancellationToken cancellationToken)
        {
            var skill = await _repo.GetAsync(s => s.Id == request.Id && s.CompanyId == request.CompanyId && s.IsDeleted == false);

            if (null == skill) throw new ApplicationException();

            skill.Delete();
            _repo.Update(skill);

            if (await _repo.SaveChangesAsync() == 0) throw new ApplicationException();

            return null;
        }
    }
}
