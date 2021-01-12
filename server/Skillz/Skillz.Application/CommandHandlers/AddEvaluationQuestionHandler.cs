using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skillz.Application.Dxos;
using Skillz.Contracts.Commands;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Profiles;
using Skillz.Models.Evaluations;
using Skillz.Models.Events;
using Skillz.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Application.CommandHandlers
{
    public class AddEvaluationQuestionHandler : IRequestHandler<AddEvaluationQuestionCommand, EvaluationQuestionDto>
    {
        private readonly IRepository<Company> _companiesRepo;
        private readonly IRepository<EvaluationQuestion> _questionsRepo;
        private readonly IEvaluationQuestionsDxos _questionsDxos;
        private readonly IMediator _mediator;

        public AddEvaluationQuestionHandler(IRepository<EvaluationQuestion> questionsRepo, IRepository<Company> companiesRepo, IMediator mediator, IEvaluationQuestionsDxos questionsDxos)
        {
            _questionsRepo = questionsRepo ?? throw new ArgumentNullException(nameof(IRepository<EvaluationQuestion>));
            _companiesRepo = companiesRepo ?? throw new ArgumentNullException(nameof(IRepository<Company>));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _questionsDxos = questionsDxos ?? throw new ArgumentNullException(nameof(questionsDxos));
        }

        public async Task<EvaluationQuestionDto> Handle(AddEvaluationQuestionCommand request, CancellationToken cancellationToken)
        {


            var company = await _companiesRepo.GetAsync(c => c.Id == request.CompanyId);
            
            if (company == null)
            {
                //TODO: nog goed exception gooien
                throw new ApplicationException();
            }

            var question = new EvaluationQuestion(
                request.Title,
                request.EvaluationQuestionTypeId,
                company.Id,
                request.EvaluationQuestionCategoryId.Value,
                request.EvaluationQuestionGroupId.Value);

            question.Description = request.Description;



            _questionsRepo.Add(question);
            

            if (await _questionsRepo.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            var newQuestion = await _questionsRepo.Query(e => e.Id == question.Id).Include(e => e.EvaluationQuestionGroup).Include(e => e.EvaluationQuestionCategory).SingleAsync();

            //await _mediator.Publish(new ConsultantCreatedEvent(question.Id), cancellationToken);
            var dto = _questionsDxos.MapEvaluationQuestionDto(newQuestion);

            return dto;



        }
    }
}
