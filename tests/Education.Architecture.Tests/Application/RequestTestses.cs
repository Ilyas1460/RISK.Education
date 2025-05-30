using FluentAssertions;
using MediatR;
using NetArchTest.Rules;

namespace Education.Architecture.Tests.Application;

public class RequestTests : BaseArchitectureTests
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
}
