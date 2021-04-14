namespace FindExactSolution.Domain.Entities
{
    public interface ICompetition
    {
        public int Id { get; set; }

        public Team Team { get; set; }
    }
}
