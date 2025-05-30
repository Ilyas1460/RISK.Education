using Education.Application.Categories.CreateCategory;
using Education.Infrastructure;
using Education.Persistence.Categories;
using FluentAssertions;
using NetArchTest.Rules;

namespace Education.ArchitecturalTests;

public class LayerDependencyTests : BaseArchitecturalTests
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
