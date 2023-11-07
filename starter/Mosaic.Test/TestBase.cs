#region test helper class - ignore

global using FluentAssertions;
global using Xunit;
using System.Reflection;

namespace Mosaic.Test;

public abstract class TestBase
{
    protected static bool CheckField<TClass, TField>(TClass instance, TField expectedValue, string expectedName)
    {
        var field = typeof(TClass)
            .GetField(expectedName, BindingFlags.Instance | BindingFlags.NonPublic);
        if (field == null
            || field.FieldType != typeof(TField))
        {
            return false;
        }

        var value = field.GetValue(instance);
        return value != null && value.Equals(expectedValue);
    }

    protected static string Prefix(string n) => $"_{n}";

    protected static Tile[] CreateSampleTiles(int set = 1)
    {
        static Tile[] CreateTiles(int width, int height, TileStyle style, int amount)
        {
            var tiles = new Tile[amount];
            var idx = 0;
            for (var i = 0; i < amount; i++)
            {
                tiles[idx++] = new(style, width, height);
            }

            return tiles;
        }

        return set switch
        {
            1 => new Tile[]
            {
                new(TileStyle.Polished, 10, 10),
                new(TileStyle.FancyColor, 15, 30),
                new(TileStyle.Raw, 200, 200),
                new(TileStyle.Ornate, 20, 20)
            },
            2 => CreateTiles(20, 20, TileStyle.FancyColor, 100)
                .Concat(CreateTiles(35, 35, TileStyle.Polished, 350))
                .Concat(CreateTiles(200, 100, TileStyle.Raw, 80))
                .ToArray(),
            _ => Array.Empty<Tile>()
        };
    }
}

#endregion