using Chaquitaclla_API_TSW.Forum.Domain.Model.Aggregates;
using Chaquitaclla_API_TSW.Forum.Domain.Model.Commands;

namespace Chaquitaclla_API_TSW.Forum.Domain.Model.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Question> Questions { get; private set; }
    
    
    public Category(){ }
    
    public Category(string name)
    {
        Name = name;
    }
    
    public Category(CreateCategoryCommand command) : this(command.Name) { }
    
    public Category UpdateInformation(UpdateCategoryCommand command)
    {
        Name = command.Name;
        return this;
    }
}
