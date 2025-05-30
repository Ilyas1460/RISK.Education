using System.Net;
using System.Net.Http.Json;
using Education.Application.Courses.GetAllCourses;
using Education.Infrastructure;
using Education.Integration.Tests.Common;
using FluentAssertions;

namespace Education.Integration.Tests.Courses;

public class GetAllCoursesQueryTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public GetAllCoursesQueryTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Theory]
    [InlineData(CourseConstants.RecordsCount,
        CourseConstants.SampleCourseId,
        CourseConstants.SampleCourseName,
        CourseConstants.SampleCourseShortDescription,
        CourseConstants.SampleCourseDescription,
        CourseConstants.SampleCourseCategoryId,
        CourseConstants.SampleCourseCategoryName,
        CourseConstants.SampleCourseLanguageId,
        CourseConstants.SampleCourseLanguageCode,
        CourseConstants.SampleCourseQuestionAnswerCount,
        CourseConstants.SampleCourseIsActive,
        CourseConstants.SampleCourseSlug)]
    public async Task Should_Return_AllCourses_When_CoursesExist(int expectedCount,
        int sampleCourseId,
        string sampleCourseName,
        string sampleCourseShortDescription,
        string sampleCourseDescription,
        int sampleCourseCategoryId,
        string sampleCourseCategoryName,
        int sampleCourseLanguageId,
        string sampleCourseLanguageCode,
        int sampleCourseQuestionAnswerCount,
        bool sampleCourseIsActive,
        string sampleCourseSlug)
    {
        var response = await _client.GetAsync("/api/courses");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<GetAllCoursesQueryResponse>();
        content.Should().NotBeNull();
        content.Courses.Should().HaveCount(expectedCount);

        content.Courses.Should().Contain(
            c => c.Id == sampleCourseId &&
                 c.Name == sampleCourseName &&
                 c.ShortDescription == sampleCourseShortDescription &&
                 c.Description == sampleCourseDescription &&
                 c.CategoryId == sampleCourseCategoryId &&
                 c.CategoryName == sampleCourseCategoryName &&
                 c.LanguageId == sampleCourseLanguageId &&
                 c.LanguageCode == sampleCourseLanguageCode &&
                 c.QuestionAnswerCount == sampleCourseQuestionAnswerCount &&
                 c.IsActive == sampleCourseIsActive &&
                 c.Slug == sampleCourseSlug);
    }
}
