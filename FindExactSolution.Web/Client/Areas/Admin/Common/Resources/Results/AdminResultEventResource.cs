namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Results
{
    public class AdminResultEventResource
    {
        public string TeamName { get; set; }
        public int TotalPoints { get; set; }

        public int TotalQuestions { get; set; }

        public int TotalChallenges { get; set; }

        public int SolvedQuestions { get; set; }

        public int SolvedChallenges { get; set; }
    }
}
