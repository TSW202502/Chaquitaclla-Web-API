using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;

namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;

public class CropsPests
{
    public int CropId { get; set; }
    
    public Crop Crop { get; set; }
    public int PestId { get; set; }
    
    public Pest Pest { get; set; }
}