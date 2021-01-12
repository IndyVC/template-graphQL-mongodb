using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using System.Collections.Generic;

namespace Skillz.Application.Dxos
{
    public interface IConsultantsDxos
    {
        ConsultantDto MapConsultantDto(Consultant consultant);
        List<ConsultantDto> MapConsultantsDto(IEnumerable<Consultant> consultants);
    }
}
