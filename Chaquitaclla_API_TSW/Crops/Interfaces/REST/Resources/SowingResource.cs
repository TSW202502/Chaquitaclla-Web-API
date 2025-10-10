using Chaquitaclla_API_TSW.Crops.Domain.Model.ValueObjects;

namespace Chaquitaclla_API_TSW.Crops.Interfaces.REST.Resources;




public record SowingResource(int Id, DateTime StartDate, DateTime EndDate, 
    int AreaLand, bool Status, EPhenologicalPhase PhenologicalPhase, 
    int CropId,  string PhenologicalPhaseName);