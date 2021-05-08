using FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions;
using System;

namespace FindExactSolution.Web.Client.Common.Resources.Questions
{
    public class QuestionChallengeResource
    {
        public Guid Id { get; set; }

        public Guid ChallengeId { get; set; }

        public string Description { get; set; }

        public string Input { get; set; }

        public int Point { get; set; }

        public bool IsSolved { 
            get
            {
                return QuestionSubmission != null && QuestionSubmission.IsCorrect;
            } 
        }

        public QuestionSubmissionChallengeResource QuestionSubmission { get; set; }
    }
}