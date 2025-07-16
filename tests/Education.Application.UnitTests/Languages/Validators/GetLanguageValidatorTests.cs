﻿using Education.Application.Languages.GetLanguage;
using Education.Exceptions.Exceptions;
using Education.Persistence.Languages;
using FluentAssertions;
using NSubstitute;

namespace Education.Application.UnitTests.Languages.Validators;

public class GetLanguageValidatorTests
{
    private readonly ILanguageRepository _languageRepository;
    private readonly GetLanguageQueryValidator _validator;

    public GetLanguageValidatorTests()
    {
        _languageRepository = Substitute.For<ILanguageRepository>();
        _validator = new GetLanguageQueryValidator(_languageRepository);
    }

    [Theory]
    [InlineData(1)]
    public async Task Should_Pass_When_ValidData(int languageId)
    {
        var command = new GetLanguageQuery(languageId);
        _languageRepository.GetByIdAsync(languageId, CancellationToken.None).Returns(Language.Create("En"));

        var result = await _validator.ValidateAsync(command);

        result.Errors.Should().BeEmpty();
        result.IsValid.Should().BeTrue();
        await _languageRepository.Received(1).GetByIdAsync(languageId, CancellationToken.None);
    }

    [Fact]
    public async Task Should_Fail_When_LanguageIdIsEmpty()
    {
        var command = new GetLanguageQuery(0);

        var result = await _validator.ValidateAsync(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(f => f.ErrorMessage == "Language ID must not be empty.");
    }

    [Theory]
    [InlineData(1)]
    public async Task Should_Fail_When_LanguageDoesNotExist(int languageId)
    {
        var command = new GetLanguageQuery(languageId);
        _languageRepository.GetByIdAsync(languageId, CancellationToken.None).Returns((Language)null!);

        var act = async () => await _validator.ValidateAsync(command);

        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Language with ID {languageId} not found.");
        await _languageRepository.Received(1).GetByIdAsync(languageId, CancellationToken.None);
    }
}
