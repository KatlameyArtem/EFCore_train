using learn_practice.efcore;
using NorthwindDb db = new();
WriteLine($"Provider - {db.Database.ProviderName}");