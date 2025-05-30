using FluentAssertions;
using NetArchTest.Rules;

namespace Education.Architecture.Tests.LayerDependency;

public class ApplicationLayer : BaseArchitectureTests
{
    [Fact]
    public void ApplicationLayer_ShouldNotDependOn_HigherLayers()
    {
        var result = Types
            .InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(APIAssemblyName)
            .And()
            .NotHaveDependencyOn(InfrastructureAssemblyName)
            .GetResult();

        result.IsSuccessful.Should().Be(true);
    }
}
