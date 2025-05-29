using System.Net;
using System.Net.Http.Json;
using Education.Application.Languages.UpdateLanguage;
using Education.Exceptions.Exceptions;
using Education.Infrastructure;
using Education.IntegrationTests.Common;
using Education.IntegrationTests.Common.Response;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Education.IntegrationTests.Languages;

public class UpdateLanguageCommandTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public UpdateLanguageCommandTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Theory]
    [InlineData(LanguageConstants.SampleLanguageId, "be")]
    public async Task Should_Update_Language_When_LanguageExists(int languageId, string newCode)
    {
        var request = new UpdateLanguageCommand
        {
            LanguageId = languageId,
            Code = newCode
        };

        var response = await _client.PutAsJsonAsync($"/api/languages/{languageId}", request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<UpdateLanguageCommandResponse>();
        content.Should().NotBeNull();
        content.Id.Should().Be(languageId);

        var updatedLanguage = await _dbContext.Languages.FirstOrDefaultAsync(l => l.Id == languageId);
        updatedLanguage.Should().NotBeNull();
        updatedLanguage.Code.Should().Be(newCode);
    }

    [Theory]
    [InlineData(LanguageConstants.EmptyLanguageId, "be")]
    public async Task Should_Return_BadRequest_When_LanguageIdIsEmpty(int languageId, string newCode)
    {
        var request = new UpdateLanguageCommand
        {
            LanguageId = languageId,
            Code = newCode
        };

        var response = await _client.PutAsJsonAsync($"/api/languages/{languageId}", request);

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
    [InlineData(LanguageConstants.NonExistentLanguageId, "be")]
    public async Task Should_Return_NotFound_When_LanguageDoesNotExist(int languageId, string newCode)
    {
        var request = new UpdateLanguageCommand
        {
            LanguageId = languageId,
            Code = newCode
        };

        var response = await _client.PutAsJsonAsync($"/api/languages/{languageId}", request);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(NotFoundException));
        content.Detail.Should().Be($"Language with ID '{languageId}' not found.");
        content.Status.Should().Be((int)HttpStatusCode.NotFound);
    }

    [Theory]
    [InlineData(LanguageConstants.SampleLanguageId, LanguageConstants.EmptyLanguageCode)]
    public async Task Should_Return_BadRequest_When_LanguageCodeIsEmpty(int languageId, string newCode)
    {
        var request = new UpdateLanguageCommand
        {
            LanguageId = languageId,
            Code = newCode
        };

        var response = await _client.PutAsJsonAsync($"/api/languages/{languageId}", request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ValidationException));
        content.Detail.Should().Be("One or more validation errors occurred.");
        content.Status.Should().Be((int)HttpStatusCode.BadRequest);
        content.Errors.Should().ContainKey("Code");
        content.Errors["Code"].Should().Contain("Code is required.");
    }

    [Theory]
    [InlineData(LanguageConstants.SampleLanguageId, "aze")]
    [InlineData(LanguageConstants.SampleLanguageId, "a")]
    public async Task Should_Return_BadRequest_When_LanguageCodeIsNotTwoCharactersLong(int languageId, string newCode)
    {
        var request = new UpdateLanguageCommand
        {
            LanguageId = languageId,
            Code = newCode
        };

        var response = await _client.PutAsJsonAsync($"/api/languages/{languageId}", request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ValidationException));
        content.Detail.Should().Be("One or more validation errors occurred.");
        content.Status.Should().Be((int)HttpStatusCode.BadRequest);
        content.Errors.Should().ContainKey("Code");
        content.Errors["Code"].Should().Contain("Code must be exactly 2 characters long.");
    }

    [Theory]
    [InlineData(LanguageConstants.SampleLanguageId, "ad")]
    [InlineData(LanguageConstants.SampleLanguageId, "fe")]
    public async Task Should_Return_BadRequest_When_LanguageCodeIsNotValid(int languageId, string newCode)
    {
        var request = new UpdateLanguageCommand
        {
            LanguageId = languageId,
            Code = newCode
        };

        var response = await _client.PutAsJsonAsync($"/api/languages/{languageId}", request);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ValidationException));
        content.Detail.Should().Be("One or more validation errors occurred.");
        content.Status.Should().Be((int)HttpStatusCode.BadRequest);
        content.Errors.Should().ContainKey("Code");
        content.Errors["Code"].Should().Contain("Code must be a valid ISO 639-1 language code.");
    }

    [Theory]
    [InlineData(LanguageConstants.SampleLanguageId, LanguageConstants.ExistingLanguageCode)]
    public async Task Should_Return_Conflict_When_LanguageCodeAlreadyExists(int languageId, string newCode)
    {
        var request = new UpdateLanguageCommand
        {
            LanguageId = languageId,
            Code = newCode
        };

        var response = await _client.PutAsJsonAsync($"/api/languages/{languageId}", request);

        response.StatusCode.Should().Be(HttpStatusCode.Conflict);

        var content = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
        content.Should().NotBeNull();
        content.Type.Should().Be(nameof(ConflictException));
        content.Detail.Should().Be($"Language with code '{newCode}' already exists.");
        content.Status.Should().Be((int)HttpStatusCode.Conflict);
    }

    [Theory]
    [InlineData(LanguageConstants.NotUpdatedLanguageId, LanguageConstants.NotUpdatedLanguageCode)]
    public async Task Should_Not_Throw_Exception_When_LanguageCodeIsSame(int languageId, string newCode)
    {
        var request = new UpdateLanguageCommand
        {
            LanguageId = languageId,
            Code = newCode
        };

        var response = await _client.PutAsJsonAsync($"/api/languages/{languageId}", request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<UpdateLanguageCommandResponse>();
        content.Should().NotBeNull();
        content.Id.Should().Be(languageId);

        var updatedLanguage = await _dbContext.Languages.FirstOrDefaultAsync(l => l.Id == languageId);
        updatedLanguage.Should().NotBeNull();
        updatedLanguage.Code.Should().Be(newCode);
    }
}
