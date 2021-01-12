
using Skillz.Contracts.Dto;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Evaluations;
using Skillz.Models.Entities.Profiles;
using Skillz.Models.Evaluations;
using System.Collections.Generic;

namespace Skillz.Application.Dxos
{
    public interface IEvaluationQuestionsDxos
    {
        EvaluationQuestionDto MapEvaluationQuestionDto(EvaluationQuestion question);
        List<EvaluationQuestionDto> MapEvaluationQuestionsDto(IEnumerable<EvaluationQuestion> questions);
        EvaluationQuestionDataDto MapEvaluationQuestionsDataDto(IEnumerable<EvaluationQuestionCategory> categories, IEnumerable<EvaluationQuestionGroup> groups);
    }
}
