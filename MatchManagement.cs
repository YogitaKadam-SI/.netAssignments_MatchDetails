using System;
using System.Collections.Generic;
using System.Linq;

public class MatchManagement
{
    public static List<MatchDetails> matches = new List<MatchDetails>()
        {
            new MatchDetails() { MatchId = 1, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Mumbai", HomeTeam = "India", AwayTeam = "Australia", HomeTeamScore = 300, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 2, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Pune", HomeTeam = "India", AwayTeam = "England", HomeTeamScore = 200, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 3, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Gujrat", HomeTeam = "India", AwayTeam = "Pakistan", HomeTeamScore = 600, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 4, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "NewYork", HomeTeam = "India", AwayTeam = "NewZealand", HomeTeamScore = 400, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 5, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Mumbai", HomeTeam = "India", AwayTeam = "SriLanka", HomeTeamScore = 350, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 6, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Ahemdabad", HomeTeam = "India", AwayTeam = "WestIndies", HomeTeamScore = 200, AwayTeamScore = 200},
        };

    public void AddMatch(MatchDetails match)
    {
        matches.Add(match);
    }

    // Implement sorting matches based on criteria and order
    public void SortMatches(string criteria, bool ascending)
    {
        switch (criteria.ToLower())
        {
            case "date":
                matches = ascending ? matches.OrderBy(m => m.MatchDateTime).ToList() : matches.OrderByDescending(m => m.MatchDateTime).ToList();
                break;
            case "sport":
                matches = ascending ? matches.OrderBy(m => m.Sport).ToList() : matches.OrderByDescending(m => m.Sport).ToList();
                break;
            case "location":
                matches = ascending ? matches.OrderBy(m => m.Location).ToList() : matches.OrderByDescending(m => m.Location).ToList();
                break;
            default:
                Console.WriteLine("Invalid sorting criteria.");
                break;
        }
    }

    // Implement filtering matches based on criteria
    public List<MatchDetails> FilterMatches(string criteria, string value)
    {
        switch (criteria.ToLower())
        {
            case "sport":
                return matches.Where(m => m.Sport.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
            case "location":
                return matches.Where(m => m.Location.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
            case "daterange":
                DateTime startDate;
                DateTime endDate;
                if (DateTime.TryParse(value.Split('-')[0], out startDate) && DateTime.TryParse(value.Split('-')[1], out endDate))
                {
                    return matches.Where(m => m.MatchDateTime >= startDate && m.MatchDateTime <= endDate).ToList();
                }
                else
                {
                    Console.WriteLine("Invalid date range format. Use format 'yyyy-mm-dd - yyyy-mm-dd'.");
                }
                break;
            default:
                Console.WriteLine("Invalid filtering criteria.");
                break;
        }

        return new List<MatchDetails>();
    }

    // Implement statistics calculation based on match scores
    public void CalculateStatistics(string criteria)
    {
        switch (criteria.ToLower())
        {
            case "averagescore":
                double homeAvg = matches.Average(m => m.HomeTeamScore);
                double awayAvg = matches.Average(m => m.AwayTeamScore);
                Console.WriteLine($"Average Score - Home: {homeAvg}, Away: {awayAvg}");
                break;
            case "highestscore":
                int highestHomeScore = matches.Max(m => m.HomeTeamScore);
                int highestAwayScore = matches.Max(m => m.AwayTeamScore);
                Console.WriteLine($"Highest Score - Home: {highestHomeScore}, Away: {highestAwayScore}");
                break;
            case "lowestscore":
                int lowestHomeScore = matches.Min(m => m.HomeTeamScore);
                int lowestAwayScore = matches.Min(m => m.AwayTeamScore);
                Console.WriteLine($"Lowest Score - Home: {lowestHomeScore}, Away: {lowestAwayScore}");
                break;
            default:
                Console.WriteLine("Invalid statistics criteria.");
                break;
        }
    }

    // Implement search matches based on keywords
    public List<MatchDetails> SearchMatches(string keyword)
    {
        return matches.Where(m =>
            m.Sport.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.HomeTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.AwayTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            m.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public void DisplayAllMatches()
    {
        foreach (var match in matches)
        {
            Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
        }
    }

    public void DisplayMatchDetails(int matchId)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
        }
        else
        {
            Console.WriteLine("Match not found.");
        }
    }

    public void UpdateMatchScore(int matchId, int homeScore, int awayScore)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            match.HomeTeamScore = homeScore;
            match.AwayTeamScore = awayScore;
            Console.WriteLine("Scores updated successfully.");
        }
        else
        {
            Console.WriteLine("Match not found.");
        }
    }

    public void RemoveMatch(int matchId)
    {
        var match = matches.Find(m => m.MatchId == matchId);
        if (match != null)
        {
            matches.Remove(match);
            Console.WriteLine("Match removed successfully.");
        }
        else
        {
            Console.WriteLine("Match not found.");
        }
    }
}

