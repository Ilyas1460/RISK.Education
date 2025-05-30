namespace Education.IntegrationTests.Categories;

public static class CategoryConstants
{
    public const int RecordsCount = 8;

    public const int SampleCategoryId = 1;
    public const string SampleCategoryName = "Mathematics";
    public static readonly DateTime SampleCategoryCreatedAt = DateTime.Parse("2025-04-20T08:15:00+00");
    public static readonly DateTime SampleCategoryUpdatedAt = DateTime.Parse("2025-05-15 14:30:00+00");
    public static readonly DateTime? SampleCategoryDeletedAt = null;

    public const int NonExistentCategoryId = 9999;
    public const int EmptyCategoryId = 0;

    public const string CategoryNameToAdd = "Programming";
    public const string UpdatedCategoryName = "Advanced Programming";
    public const string AnotherUpdatedCategoryName = "Data Science";
    public const string ExistingCategoryName = "Physics";
    public const string EmptyCategoryName = "";

    public const int NotUpdatedCategoryId = 3;
    public const string NotUpdatedCategoryName = "Computer Science";
}
