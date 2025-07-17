﻿using System.Text.Json;
using Education.Application.Abstractions.Localization;

namespace Education.Infrastructure.Localization;

public class LanguageCodeProvider : ILanguageCodeProvider
{
    private readonly HashSet<string> _validCodes;

    public LanguageCodeProvider()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Resources", "languageCodes.json");
        var json = File.ReadAllText(path);
        var codes = JsonSerializer.Deserialize<List<string>>(json) ?? [];
        _validCodes = new HashSet<string>(codes, StringComparer.OrdinalIgnoreCase);
    }

    public IReadOnlySet<string> GetValidLanguageCodes() => _validCodes;
}
