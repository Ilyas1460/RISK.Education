﻿namespace Education.Persistence.Users;

public class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }
}
