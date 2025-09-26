namespace Chaquitaclla_API_TSW.Crops.Domain.Model.Commands;


//,List<Disease> Diseases, List<Pest> Pests
public record CreateCropCommand(string Name, string Description);
