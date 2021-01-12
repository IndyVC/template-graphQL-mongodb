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
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, SkillDto>
    {
        private readonly IRepository<Skill> _repo;
        private readonly IMediator _mediator;
        private readonly ISkillsDxos _dxo;

        public DeleteSkillHandler(IRepository<Skill> repo, IMediator mediator, ISkillsDxos dxo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(IRepository<Skill>)); ;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _dxo = dxo ?? throw new ArgumentNullException(nameof(dxo));
        }

        public async Task<SkillDto> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
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
