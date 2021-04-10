using FindExactSolution.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Pages.Leadeboard
{
    public partial class Leaderboard
    {
        public IEnumerable<Team> Teams { get; set; }

        private void InitializeJobCategories()
        {
            Teams = new List<Team>()
            {
                new Team{Id = Guid.NewGuid(), Name = "Pie research"},
                new Team{Id = Guid.NewGuid(), Name = "Sales"},
                new Team{Id = Guid.NewGuid(), Name = "Management"},
                new Team{Id = Guid.NewGuid(), Name = "Store staff"},
                new Team{Id = Guid.NewGuid(), Name = "Finance"},
                new Team{Id = Guid.NewGuid(), Name = "QA"},
                new Team{Id = Guid.NewGuid(), Name = "IT"},
                new Team{Id = Guid.NewGuid(), Name = "Cleaning"},
                new Team{Id = Guid.NewGuid(), Name = "Bakery"},
                new Team{Id = Guid.NewGuid(), Name = "Bakery"}
            };
        }

        protected override Task OnInitializedAsync()
        {
            InitializeJobCategories();

            return base.OnInitializedAsync();
        }
    }
}
