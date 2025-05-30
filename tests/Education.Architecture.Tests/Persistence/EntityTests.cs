using Education.Persistence.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;

namespace Education.Architecture.Tests.Persistence;

public class EntityTests : BaseArchitectureTests
{
    [Fact]
    public void Entities_Should_Have_PrivateSetters()
    {
        var entityTypes = Types.InAssembly(PersistenceAssembly)
            .That()
            .AreClasses()
            .And()
            .Inherit(typeof(BaseEntity))
            .GetTypes();

        foreach (var entityType in entityTypes)
        {
            var properties = entityType.GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetMethod.Should().NotBeNull()
                        .And.Match(setMethod =>
                            setMethod.IsPrivate || setMethod.IsFamily || setMethod.IsFamilyOrAssembly);
                }
            }
        }
    }
}
