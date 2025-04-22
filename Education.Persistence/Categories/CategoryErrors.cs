using Education.Persistence.Abstractions;

namespace Education.Persistence.Categories;

public static class CategoryErrors
{
    public static Error NotFound(int id) => new("Category.NotFound", $"The category with id '{id}' was not found.");

    public static Error AlreadyExists(string title) =>
        new("Category.AlreadyExists", $"The category with title '{title}' already exists.");
}
