using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Languages;

public class Language : BaseEntity
{
    public int LanguageId { get; init; }
    public string Name { get; private set; }
    public string Code { get; private set; }

    public List<Course> Courses { get; set; }

    public Language(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public void UpdateName(string name) => Name = name;

    public void UpdateCode(string code) => Code = code;
}
