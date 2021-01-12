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
using Skillz.Models.Entities.Evaluations;

namespace Skillz.Application.QueryHandlers
{
    public class GetEvaluationDataQueryHandler : IRequestHandler<GetEvaluationQuestionsDataQuery, EvaluationQuestionDataDto>
    {
        private readonly IRepository<EvaluationQuestionGroup> _questionsGroupsRepo;
        private readonly IRepository<EvaluationQuestionCategory> _questionsCategoriesRepo;
        private readonly IEvaluationQuestionsDxos _questionsDxos;
        private readonly ILogger<GetEvaluationDataQueryHandler> _logger;

        public GetEvaluationDataQueryHandler(IRepository<EvaluationQuestionGroup> questionsGroupsRepo, IRepository<EvaluationQuestionCategory> questionsCategoriesRepo, IEvaluationQuestionsDxos questionsDxos, ILogger<GetEvaluationDataQueryHandler> logger)
        {
            _questionsGroupsRepo = questionsGroupsRepo ?? throw new ArgumentNullException(nameof(questionsGroupsRepo));
            _questionsCategoriesRepo = questionsCategoriesRepo ?? throw new ArgumentNullException(nameof(questionsCategoriesRepo));

            _questionsDxos = questionsDxos ?? throw new ArgumentNullException(nameof(questionsDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<EvaluationQuestionDataDto> Handle(GetEvaluationQuestionsDataQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var groups = await _questionsGroupsRepo.Query(e => e.IsDeleted == false).ToListAsync();
                var categories = await _questionsCategoriesRepo.Query(e => e.IsDeleted == false).ToListAsync();

                if (null != groups)
                {
                    _logger.LogInformation($"Request for questions");
                    return _questionsDxos.MapEvaluationQuestionsDataDto(categories, groups);
                }
            }
            catch (Exception ex) {
                string s = ex.Message;
            }

           

            return null;
        }
    }
}
