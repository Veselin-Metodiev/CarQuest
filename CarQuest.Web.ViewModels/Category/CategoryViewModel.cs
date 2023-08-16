namespace CarQuest.Web.ViewModels.Category;

using Data.Models;
using Services.Mapping;

public class CategoryViewModel : IMapFrom<Category>
{
	public string Name { get; set; } = null!;
}
