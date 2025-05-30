using FluentAssertions;
using MediatR;
using NetArchTest.Rules;

namespace Education.Architecture.Tests.Application;

public class RequestHandlerTests : BaseArchitectureTests
{

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
}
