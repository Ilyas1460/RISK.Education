using System.Net;
using System.Net.Http.Json;
using Education.Application.Categories.DeleteCategory;
using Education.Exceptions.Exceptions;
using Education.Infrastructure;
using Education.Integration.Tests.Common;
using Education.Integration.Tests.Common.Response;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Education.Integration.Tests.Languages;

public class DeleteLanguageCommandTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public DeleteLanguageCommandTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Theory]
    [InlineData(LanguageConstants.SampleLanguageId)]
    public async Task Should_Delete_Language_When_LanguageExists(int languageId)
    {
        var response = await _client.DeleteAsync($"/api/languages/{languageId}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<DeleteCategoryCommandResponse>();

        content.Should().NotBeNull();
        content.Id.Should().Be(languageId);

        var deletedLanguage = await _dbContext.Languages.FirstOrDefaultAsync(l => l.Id == languageId);
        deletedLanguage.Should().BeNull();
    }

    [Theory]
    [InlineData(LanguageConstants.EmptyLanguageId)]
    public async Task Should_Return_BadRequest_When_LanguageIdIsEmpty(int languageId)
    {
        var response = await _client.DeleteAsync($"/api/languages/{languageId}");

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();

        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ValidationException));
        content.Detail.Should().Be("One or more validation errors occurred.");
        content.Status.Should().Be((int)HttpStatusCode.BadRequest);
        content.Errors.Should().ContainKey("LanguageId");
        content.Errors["LanguageId"].Should().Contain("Language ID must not be empty.");
    }

    [Theory]
    [InlineData(LanguageConstants.NonExistentLanguageId)]
    public async Task Should_Return_NotFound_When_LanguageDoesNotExist(int languageId)
    {
        var response = await _client.DeleteAsync($"/api/languages/{languageId}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(NotFoundException));
        content.Detail.Should().Be($"Language with ID '{languageId}' not found.");
        content.Status.Should().Be((int)HttpStatusCode.NotFound);
    }
}
