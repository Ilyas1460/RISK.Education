using System.Net;
using System.Net.Http.Json;
using Education.Application.Courses.DeleteCourse;
using Education.Exceptions.Exceptions;
using Education.Infrastructure;
using Education.Integration.Tests.Common;
using Education.Integration.Tests.Common.Response;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Education.Integration.Tests.Courses;

public class DeleteCourseCommandTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public DeleteCourseCommandTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Theory]
    [InlineData(CourseConstants.SampleCourseId)]
    public async Task Should_Delete_Course_When_CourseExists(int courseId)
    {
        var response = await _client.DeleteAsync($"/api/courses/{courseId}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadFromJsonAsync<DeleteCourseCommandResponse>();
        content.Should().NotBeNull();

        var deletedCourse = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
        deletedCourse.Should().BeNull();
    }

    [Theory]
    [InlineData(CourseConstants.EmptyCourseId)]
    public async Task Should_Return_BadRequest_When_CourseIdIsEmpty(int courseId)
    {
        var response = await _client.DeleteAsync($"/api/courses/{courseId}");

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ValidationException));
        content.Detail.Should().Be("One or more validation errors occurred.");
        content.Status.Should().Be((int)HttpStatusCode.BadRequest);
        content.Errors.Should().ContainKey("CourseId");
        content.Errors["CourseId"].Should().Contain("Course ID must not be empty.");
    }

    [Theory]
    [InlineData(CourseConstants.NonExistentCourseId)]
    public async Task Should_Return_NotFound_When_CourseDoesNotExist(int courseId)
    {
        var response = await _client.DeleteAsync($"/api/courses/{courseId}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(NotFoundException));
        content.Detail.Should().Be($"Course with ID '{courseId}' not found.");
        content.Status.Should().Be((int)HttpStatusCode.NotFound);
    }
}
