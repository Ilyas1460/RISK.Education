﻿using Education.Application.Abstractions.Localization;
using Education.Infrastructure.Interceptors;
using Education.Infrastructure.Localization;
using Education.Infrastructure.Repositories;
using Education.Persistence;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using Education.Persistence.Courses;
using Education.Persistence.Languages;
using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Education.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // ✅ Singleton for LanguageProvider (example: localization fallback etc.)
        services.AddSingleton<ILanguageCodeProvider, LanguageCodeProvider>();

        // ✅ Add DbContext + Repositories
        AddPersistence(services, configuration);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new ArgumentNullException(nameof(configuration), "Database connection string is missing.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseLazyLoadingProxies()
                   .UseNpgsql(connectionString)
                   .UseSnakeCaseNamingConvention()
                   .AddInterceptors(new AuditableEntityInterceptor());
        });

        // ✅ Register your repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>(); // ✅ Added!

        // ✅ Optional: register your UnitOfWork
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
    }
}
