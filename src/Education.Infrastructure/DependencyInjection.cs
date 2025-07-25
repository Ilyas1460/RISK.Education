﻿using Education.Application.Abstractions.Localization;
using Education.Infrastructure.Extensions;
using Education.Infrastructure.Localization;
using Education.Infrastructure.Repositories;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using Education.Persistence.Courses;
using Education.Persistence.Languages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Education.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ILanguageCodeProvider, LanguageCodeProvider>();

        AddPersistence(services, configuration);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database") ??
                                  throw new ArgumentNullException(nameof(configuration),
                                      "Database connection string is missing.");

        services.AddApplicationDbContext(connectionString);

        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<ILanguageRepository, LanguageRepository>();

        services.AddScoped<ICourseRepository, CourseRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
    }
}
