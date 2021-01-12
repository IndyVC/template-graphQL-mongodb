using AutoMapper;
using Skillz.Contracts.Dto;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities.Evaluations;
using Skillz.Models.Evaluations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Application.Dxos
{
    public class EvaluationQuestionsDxos : IEvaluationQuestionsDxos
    {
        private readonly IMapper _mapper;

        public EvaluationQuestionsDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EvaluationQuestion, EvaluationQuestionDto>();
                cfg.CreateMap<EvaluationQuestionGroup, EvaluationQuestionGroupDto>();
                cfg.CreateMap<EvaluationQuestionCategory, EvaluationQuestionCategoryDto>();
                cfg.CreateMap<EvaluationQuestionCategory, IdTitleDto>();
                cfg.CreateMap<EvaluationQuestionGroup, IdTitleDto>();
            });
            _mapper = config.CreateMapper();
        }


        public EvaluationQuestionDto MapEvaluationQuestionDto(EvaluationQuestion question)
        {
            return _mapper.Map<EvaluationQuestion, EvaluationQuestionDto>(question);
        }

        public List<EvaluationQuestionDto> MapEvaluationQuestionsDto(IEnumerable<EvaluationQuestion> questions)
        {
            return _mapper.Map<List<EvaluationQuestionDto>>(questions);
        }

        public EvaluationQuestionDataDto MapEvaluationQuestionsDataDto(IEnumerable<EvaluationQuestionCategory> categories, IEnumerable<EvaluationQuestionGroup> groups)
        {
            var ed = new EvaluationQuestionDataDto();
            ed.Categories = _mapper.Map<IEnumerable<IdTitleDto>>(categories);
            ed.Groups = _mapper.Map<IEnumerable<IdTitleDto>>(groups);

            return ed;
        }
    }
}
