using FluentAssertions;
using NetArchTest.Rules;

namespace Education.Architecture.Tests.LayerDependency;

public class InfrastructureLayer : BaseArchitectureTests
{
    [Fact]
    public void InfrastructureLayer_ShouldNotDependOn_HigherLayers()
    {
        var result = Types
            .InAssembly(InfrastructureAssembly)
            .Should()
            .NotHaveDependencyOn(APIAssemblyName)
            .GetResult();

        result.IsSuccessful.Should().Be(true);
    }
}
