using System;

namespace FindExactSolution.Domain.Entities
{
    public class QuestionSubmission
    {
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public string TeamAnswer { get; set; }

        public int EarnedPoints { get; set; }

        public bool IsCorrect { get; set; }

        public int TotalAttempts { get; set; }

        public DateTime LastSubmittedDateTime { get; set; }

        public static QuestionSubmission Create(Guid questionId, Guid teamId, bool isCorrect, string teamAnswer, int earnedPoints)
        {
            return new QuestionSubmission
            {
                QuestionId = questionId,
                TeamId = teamId,
                IsCorrect = isCorrect,
                LastSubmittedDateTime = DateTime.Now,
                TotalAttempts = 1,
                TeamAnswer = teamAnswer,
                EarnedPoints = earnedPoints
            };
        }

        public void Update(bool isCorrect, string teamAnswer, int earnedPoints)
        {
            IsCorrect = isCorrect;
            LastSubmittedDateTime = DateTime.Now;
            TotalAttempts++;
            TeamAnswer = teamAnswer;
            EarnedPoints = earnedPoints;
        }
    }
}