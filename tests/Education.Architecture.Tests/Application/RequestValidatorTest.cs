using FluentAssertions;
using FluentValidation;
using NetArchTest.Rules;

namespace Education.Architecture.Tests.Application;

public class RequestValidatorTestses : BaseArchitectureTests
{


    [Fact]
    public void Validator_ShouldHave_NameEndingWith_Validator()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should()
            .HaveNameEndingWith("Validator")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Validators_ShouldBe_SealedAndNotPublic()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .GetTypes();

        var violations = types
            .Where(t => t.IsPublic || !t.IsSealed)
            .ToList();

        violations.Should().BeEmpty();
    }
}
