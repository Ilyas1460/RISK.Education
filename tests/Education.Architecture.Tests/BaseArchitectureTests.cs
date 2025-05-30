using System.Reflection;
using Education.API.Controllers;
using Education.Application.Categories.CreateCategory;
using Education.Exceptions.Exceptions;
using Education.Infrastructure;
using Education.Persistence.Categories;

namespace Education.Architecture.Tests;

public class BaseArchitectureTests
{
    protected static Assembly APIAssembly => typeof(CategoryController).Assembly;
    protected static Assembly InfrastructureAssembly => typeof(ApplicationDbContext).Assembly;
    protected static Assembly ApplicationAssembly => typeof(CreateCategoryCommand).Assembly;
    protected static Assembly ExceptionsAssembly => typeof(BaseException).Assembly;
    protected static Assembly PersistenceAssembly => typeof(Category).Assembly;

    protected static string APIAssemblyName => APIAssembly.GetName().Name ?? string.Empty;
    protected static string InfrastructureAssemblyName => InfrastructureAssembly.GetName().Name ?? string.Empty;
    protected static string ApplicationAssemblyName => ApplicationAssembly.GetName().Name ?? string.Empty;
    protected static string ExceptionsAssemblyName => ExceptionsAssembly.GetName().Name ?? string.Empty;
    protected static string PersistenceAssemblyName => PersistenceAssembly.GetName().Name ?? string.Empty;
}
