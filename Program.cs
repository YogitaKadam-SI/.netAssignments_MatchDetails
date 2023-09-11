namespace Match_Details_Management_System
{
    internal class Program
    {
        static void Main()
        {
            UserInterface ui = new UserInterface();
            MatchManagement matchManagement = new MatchManagement();

            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Display All Matches");
                Console.WriteLine("2. Add a match");
                Console.WriteLine("3. Display Match Details");
                Console.WriteLine("4. Update Match Score");
                Console.WriteLine("5. Remove Match");
                Console.WriteLine("6. Sort Matches");
                Console.WriteLine("7. Filter Matches");
                Console.WriteLine("8. Calculate Statistics");
                Console.WriteLine("9. Search Matches");
                Console.WriteLine("0. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            matchManagement.DisplayAllMatches();
                            break;
                        case 2:
                            MatchDetails newMatch = new MatchDetails();

                            newMatch.MatchId = ui.GetMatchId();
                            newMatch.Sport = ui.GetSport();
                            newMatch.MatchDateTime = ui.GetMatchDateTime();
                            newMatch.Location = ui.GetLocation();
                            newMatch.HomeTeam = ui.GetHomeTeam();
                            newMatch.AwayTeam = ui.GetAwayTeam();
                            newMatch.HomeTeamScore = ui.GetHomeTeamScore();
                            newMatch.AwayTeamScore = ui.GetAwayTeamScore();

                            matchManagement.AddMatch(newMatch);
                            break;
                        case 3:
                            Console.Write("Enter Match ID: ");
                            int matchId = int.Parse(Console.ReadLine());
                            matchManagement.DisplayMatchDetails(matchId);
                            break;
                        case 4:
                            Console.Write("Enter Match ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Home Team Score: ");
                            int homeScore = int.Parse(Console.ReadLine());
                            Console.Write("Enter Away Team Score: ");
                            int awayScore = int.Parse(Console.ReadLine());
                            matchManagement.UpdateMatchScore(id, homeScore, awayScore);
                            break;
                        case 5:
                            Console.Write("Enter Match ID: ");
                            int removeId = int.Parse(Console.ReadLine());
                            matchManagement.RemoveMatch(removeId);
                            break;
                        case 6:
                            Console.WriteLine("Sort by: (date/sport/location)");
                            string criteria = Console.ReadLine();
                            Console.WriteLine("Ascending? (true/false)");
                            bool ascending = bool.Parse(Console.ReadLine());
                            matchManagement.SortMatches(criteria, ascending);
                            matchManagement.DisplayAllMatches();
                            break;
                        case 7:
                            Console.WriteLine("Filter by: (sport/location/daterange)");
                            string filterCriteria = Console.ReadLine();
                            Console.WriteLine("Enter value: ");
                            string value = Console.ReadLine();
                            List<MatchDetails> filteredMatches = matchManagement.FilterMatches(filterCriteria, value);
                            Console.WriteLine("\nFiltered Matches:");
                            foreach (var match in filteredMatches)
                            {
                                Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
                            }
                            break;
                        case 8:
                            Console.WriteLine("Calculate statistics for: (averagescore/highestscore/lowestscore)");
                            string statisticsCriteria = Console.ReadLine();
                            matchManagement.CalculateStatistics(statisticsCriteria);
                            break;
                        case 9:
                            Console.WriteLine("Search for: ");
                            string keyword = Console.ReadLine();
                            List<MatchDetails> searchedMatches = matchManagement.SearchMatches(keyword);
                            Console.WriteLine("\nSearched Matches:");
                            foreach (var match in searchedMatches)
                            {
                                Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
                            }
                            break;
                        case 0:
                            continueRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.Please enter a number.");
                }
            }
        }
    }
}