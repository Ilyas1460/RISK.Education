using Education.Persistence.Abstractions;

namespace Education.Persistence.Categories;

public class Category : Entity {
	public Guid CategoryId { get; init; }
	public string Title { get; private set; }
	public string Description { get; private set; }
	
	public Category(Guid categoryId, string title, string description) {
		CategoryId = categoryId;
		Title = title;
		Description = description;
	}
	
	public void UpdateTitle(string title) {
		Title = title;
	}
	
	public void UpdateDescription(string description) {
		Description = description;
	}
}