using Education.Persistence.Abstractions;

namespace Education.Persistence.Languages;

public class Language : Entity {
	public Guid LanguageId { get; init; }
	public string Name { get; private set; }
	public string Code { get; private set; }
	
	public Language(Guid languageId, string name, string code) {
		LanguageId = languageId;
		Name = name;
		Code = code;
	}
	
	public void UpdateName(string name) {
		Name = name;
	}
	
	public void UpdateCode(string code) {
		Code = code;
	}
}