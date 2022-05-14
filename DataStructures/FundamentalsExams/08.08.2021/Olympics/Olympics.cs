using System;
using System.Collections.Generic;
using System.Linq;

public class Olympics : IOlympics
{
    private Dictionary<int, Competitor> competitors;
    private Dictionary<int, Competition> competitions;

    public Olympics()
    {
        this.competitors = new Dictionary<int, Competitor>();
        this.competitions = new Dictionary<int, Competition>();
    }
    public void AddCompetition(int id, string name, int score)
    {
        if (this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.competitions.Add(id, new Competition(name, id, score));
    }

    public void AddCompetitor(int id, string name)
    {
        if (this.competitors.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.competitors.Add(id, new Competitor(id, name));
    }

    public void Compete(int competitorId, int competitionId)
    {
        var currCompetitior = GetCompetitorById(competitorId);
        var currCompetition = GetCompetitionById(competitionId);

        if(currCompetitior == null || currCompetition == null)
        {
            throw new ArgumentException();
        }

        this.competitors[competitorId].TotalScore += currCompetition.Score;
        this.competitions[competitionId].Competitors.Add(currCompetitior);
        
    }

    private Competition GetCompetitionById(int competitionId)
    {
        if (this.competitions.ContainsKey(competitionId))
        {
            return this.competitions[competitionId];
        }

        return null;
    }

    private Competitor GetCompetitorById(int id)
    {
        if (this.competitors.ContainsKey(id))
        {
            return this.competitors[id];
        }

        return null;
    }

    public int CompetitionsCount()
    {
        return this.competitions.Count;
    }

    public int CompetitorsCount()
    {
        return this.competitors.Count;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        var currCompetition = GetCompetitionById(competitionId);

        if (currCompetition == null)
        {
            throw new ArgumentException();
        }


        if (this.competitions[competitionId].Competitors.Contains(comp))
        {
            return true;
        } 

        return false;
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        var currCompetitior = this.GetCompetitorById(competitorId);
        var currCompetition = this.GetCompetitionById(competitionId);

        if (currCompetitior == null || currCompetition == null)
        {
            throw new ArgumentException();
        }

        currCompetitior.TotalScore -= currCompetition.Score;
        currCompetition.Competitors.Remove(currCompetitior);
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        var result = this.competitors.Select(x => x.Value).Where(c => c.TotalScore > min && c.TotalScore <= max).OrderBy(x => x.Id).ToList();

        return result;
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        var result = this.competitors.Select(x => x.Value).Where(c => c.Name.Contains(name)).OrderBy(x => x.Id).ToList();

        if(result.Count == 0)
        {
            throw new ArgumentException();
        }

        return result;
    }

    public Competition GetCompetition(int id)
    {
        var competition =  this.GetCompetitionById(id);

        if(competition == null)
        {
            throw new ArgumentException();
        }

        return competition;
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        var result = this.competitors.Where(c => c.Value.Name.Length >= min && c.Value.Name.Length <= max).Select(x => x.Value).OrderBy(o => o.Id).ToList();

        return result;
    }
}