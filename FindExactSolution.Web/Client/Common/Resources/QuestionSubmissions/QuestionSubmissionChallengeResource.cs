using System;

namespace FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions
{
    public class QuestionSubmissionChallengeResource
    {
        public bool IsCorrect { get; set; }

        public int TotalAttempts { get; set; }

        public DateTime LastSubmittedDateTime { get; set; }

        public string TeamAnswer { get; set; }
    }
}
