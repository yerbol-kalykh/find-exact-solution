using FindExactSolution.Web.Client.Common.Resources.Questions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionResource>> GetAllQuestionsAsync(Guid eventId);
    }
}