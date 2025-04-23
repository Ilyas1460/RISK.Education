using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Languages;

public sealed class Language : BaseEntity
{
    public string Name { get; private set; }
    public string Code { get; private set; }

    public List<Course> Courses { get; set; }

    private Language(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public static Language Create(string name, string code)
    {
        return new Language(name, code);
    }

    public void UpdateName(string name) => Name = name;

    public void UpdateCode(string code) => Code = code;
}
