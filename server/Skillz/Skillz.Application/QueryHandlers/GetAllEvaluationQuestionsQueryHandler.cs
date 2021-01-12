using MediatR;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Dto;
using Skillz.Contracts.Queries;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Profiles;
using Skillz.Models.Evaluations;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Skillz.Application.QueryHandlers
{
    public class GetAllEvaluationQuestionsQueryHandler : IRequestHandler<GetAllEvaluationQuestionsQuery, IEnumerable<EvaluationQuestionDto>>
    {
        private readonly IRepository<EvaluationQuestion> _questionsRepo;
        private readonly IEvaluationQuestionsDxos _questionsDxos;
        private readonly ILogger<GetAllEvaluationQuestionsQueryHandler> _logger;

        public GetAllEvaluationQuestionsQueryHandler(IRepository<EvaluationQuestion> questionsRepo, IEvaluationQuestionsDxos questionsDxos, ILogger<GetAllEvaluationQuestionsQueryHandler> logger)
        {
            _questionsRepo = questionsRepo ?? throw new ArgumentNullException(nameof(questionsRepo));
            _questionsDxos = questionsDxos ?? throw new ArgumentNullException(nameof(questionsDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<EvaluationQuestionDto>> Handle(GetAllEvaluationQuestionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var questions = await _questionsRepo.Query(e => e.IsDeleted == false).Include(e => e.EvaluationQuestionGroup).Include(e => e.EvaluationQuestionCategory).ToListAsync();

                if (null != questions)
                {
                    _logger.LogInformation($"Request for questions");
                    return _questionsDxos.MapEvaluationQuestionsDto(questions);
                }
            }
            catch (Exception ex) {
                string s = ex.Message;
            }

           

            return null;
        }
    }
}
