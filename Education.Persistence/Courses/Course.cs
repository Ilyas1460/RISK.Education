using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using Education.Persistence.Languages;

namespace Education.Persistence.Courses;

public class Course : Entity {
	public Guid CourseId { get; init; }
	public string Title { get; private set; }
	public string Description { get; private set; }
	public Guid CategoryId { get; private set; }
	public Guid LanguageId { get; private set; }
	
	public Category Category { get; set; }
	public Language Language { get; set; }
	
	public Course(Guid courseId, string title, string description, Guid categoryId, Guid languageId) {
		CourseId = courseId;
		Title = title;
		Description = description;
		CategoryId = categoryId;
		LanguageId = languageId;
	}
	
	public void UpdateTitle(string title) {
		Title = title;
	}
	
	public void UpdateDescription(string description) {
		Description = description;
	}
	
	public void UpdateCategoryId(Guid categoryId) {
		CategoryId = categoryId;
	}
	
	public void UpdateLanguageId(Guid languageId) {
		LanguageId = languageId;
	}
}