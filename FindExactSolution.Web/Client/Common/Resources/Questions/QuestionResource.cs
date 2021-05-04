using System;

namespace FindExactSolution.Web.Client.Common.Resources.Questions
{
    public class QuestionResource
    {
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Point { get; set; }
    }
}
