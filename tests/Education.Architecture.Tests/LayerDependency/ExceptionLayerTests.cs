using FluentAssertions;
using NetArchTest.Rules;

namespace Education.Architecture.Tests.LayerDependency;

public class ExceptionLayerTests : BaseArchitectureTests
{
    [Fact]
    public void ExceptionLayer_ShouldNotDependOn_HigherLayers()
    {
        var result = Types
            .InAssembly(ExceptionsAssembly)
            .Should()
            .NotHaveDependencyOn(ApplicationAssemblyName)
            .And()
            .NotHaveDependencyOn(PersistenceAssemblyName)
            .And()
            .NotHaveDependencyOn(InfrastructureAssemblyName)
            .And()
            .NotHaveDependencyOn(APIAssemblyName)
            .GetResult();

        result.IsSuccessful.Should().Be(true);
    }
}
