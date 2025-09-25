using Chaquitaclla_API_TSW.Crops.Domain.Model.Aggregates;

namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Entities;

public class CropsDiseases
{
    public int CropId { get; set; }
    public Crop Crop { get; set; } 

    public int DiseaseId { get; set; }
    public Disease Disease { get; set; } 
}