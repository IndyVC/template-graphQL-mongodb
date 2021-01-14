using MediatR;
using Microsoft.EntityFrameworkCore;
using Skillz.Application.Dxos;
using Skillz.Contracts.Commands;
using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using Skillz.Models.Events;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.CommandHandlers
{
    public class AddConsultantHandler : IRequestHandler<AddConsultantCommand, ConsultantDto>
    {
        private readonly IRepository<Consultant> _consultantsRepository;
        private readonly IMediator _mediator;
        private readonly IConsultantsDxos _consultantsDxo;

        public AddConsultantHandler(IRepository<Consultant> consultantsRepository, IMediator mediator, IConsultantsDxos consultantsDxo)
        {
            _consultantsRepository = consultantsRepository ?? throw new ArgumentNullException(nameof(IRepository<Consultant>)); ;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _consultantsDxo = consultantsDxo ?? throw new ArgumentNullException(nameof(consultantsDxo));
        }

        public async Task<ConsultantDto> Handle(AddConsultantCommand request, CancellationToken cancellationToken)
        {
            var consultant = new Consultant(
                request.FirstName,
                request.LastName,
                request.CompanyId);
            consultant.Email = request.Email;
            consultant.Phone = request.Phone;
            consultant.MobilePhone = request.MobilePhone;

            _consultantsRepository.Add(consultant);

            if (await _consultantsRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            await _mediator.Publish(new ConsultantCreatedEvent(consultant.Id), cancellationToken);

            var newConsultant = await _consultantsRepository.Query(e => e.Id == consultant.Id).SingleAsync();
            var dto = _consultantsDxo.MapConsultantDto(newConsultant);

            return dto;
        }
    }
}
