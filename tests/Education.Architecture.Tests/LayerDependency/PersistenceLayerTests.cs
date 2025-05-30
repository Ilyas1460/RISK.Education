using FluentAssertions;
using NetArchTest.Rules;

namespace Education.Architecture.Tests.LayerDependency;

public class PersistenceLayerTests : BaseArchitectureTests
{
    [Fact]
    public void PersistenceLayer_ShouldNotDependOn_HigherLayers()
    {
        var result = Types
            .InAssembly(PersistenceAssembly)
            .Should()
            .NotHaveDependencyOn(ApplicationAssemblyName)
            .And()
            .NotHaveDependencyOn(ExceptionsAssemblyName)
            .And()
            .NotHaveDependencyOn(InfrastructureAssemblyName)
            .And()
            .NotHaveDependencyOn(APIAssemblyName)
            .GetResult();

        result.IsSuccessful.Should().Be(true);
    }
}
