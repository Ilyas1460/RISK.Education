using FluentAssertions;
using FluentValidation;
using MediatR;
using NetArchTest.Rules;

namespace Education.Architecture.Tests;

public class ApplicationLayerTests : BaseArchitectureTests
{
    [Fact]
    public void Request_ShouldHave_NameEndingWith_CommandOrQuery()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IRequest<>))
            .Or()
            .ImplementInterface(typeof(IRequest))
            .Should()
            .HaveNameEndingWith("Command")
            .Or()
            .HaveNameEndingWith("Query")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Request_ShouldBe_SealedAndPublic()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IRequest<>))
            .Or()
            .ImplementInterface(typeof(IRequest))
            .GetTypes();

        var violations = types
            .Where(t => !t.IsPublic || !t.IsSealed)
            .ToList();

        violations.Should().BeEmpty();
    }

    [Fact]
    public void RequestHandler_ShouldHave_NameEndingWith_Handler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Should()
            .HaveNameEndingWith("Handler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void RequestHandler_ShouldBe_SealedAndNotPublic()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .GetTypes();

        var violations = types
            .Where(t => t.IsPublic || !t.IsSealed)
            .ToList();

        violations.Should().BeEmpty();
    }

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
