using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;

namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;

public class Cares
{
    public int Id { get; }

    public string description { get; private set; }
    
    public DateTime date { get; private set; }
    
    public Sowing Sowing { get; private set; }

    public Cares()
    {
        
    }
    
    public Cares(string description, DateTime date, Sowing sowing)
    {
       this.description = description;
       this.date = date;
       Sowing = sowing;
    }
    
}