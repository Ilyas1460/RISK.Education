using FluentAssertions;
using NetArchTest.Rules;

namespace Education.Architecture.Tests;

public class LayerDependencyTests : BaseArchitectureTests
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
