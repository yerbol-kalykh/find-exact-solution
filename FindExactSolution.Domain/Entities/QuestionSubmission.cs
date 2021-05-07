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

        public bool IsCorrect { get; set; }

        public DateTime LastSubmittedDateTime { get; set; }

        public static QuestionSubmission Create(Guid questionId, Guid teamId, bool isCorrect)
        {
            return new QuestionSubmission
            {
                QuestionId = questionId,
                TeamId = teamId,
                IsCorrect = isCorrect,
                LastSubmittedDateTime = DateTime.Now
            };
        }

        public void Update(bool isCorrect)
        {
            IsCorrect = isCorrect;
            LastSubmittedDateTime = DateTime.Now;
        }
    }
}