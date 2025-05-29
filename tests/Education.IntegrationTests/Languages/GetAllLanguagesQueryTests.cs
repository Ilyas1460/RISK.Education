using System.Net;
using System.Net.Http.Json;
using Education.Application.Languages.GetAllLanguages;
using Education.Infrastructure;
using Education.IntegrationTests.Common;
using FluentAssertions;

namespace Education.IntegrationTests.Languages;

public class GetAllLanguagesQueryTests : IClassFixture<IntegrationTestFixture>
{
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;

    public GetAllLanguagesQueryTests(IntegrationTestFixture fixture)
    {
        _client = fixture.Client;
        _dbContext = fixture.DbContext;
    }

    [Theory]
    [InlineData(LanguageConstants.RecordsCount,
        LanguageConstants.SampleLanguageId,
        LanguageConstants.SampleLanguageCode)]
    public async Task Should_Return_All_Languages_When_LanguagesExist(int expectedCount,
        int languageId,
        string languageName)
    {
        var response = await _client.GetAsync("/api/languages");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<GetAllLanguagesQueryResponse>();
        content.Should().NotBeNull();
        content.Languages.Should().HaveCount(expectedCount);
        content.Languages.Should().Contain(l => l.Id == languageId && l.Code == languageName);
    }
}
