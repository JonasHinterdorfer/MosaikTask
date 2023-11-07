using System.Text;
using Mosaic;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine($"*** Mosaic Prices ***{Environment.NewLine}");

var patterns = new TilePattern[]
{
    new(PatternStyle.Simple, CreateTiles(new TileConfig[]
    {
        new(15, 15, TileStyle.PlainColor, 200),
        new(80, 40, TileStyle.SimplePattern, 160),
        new(20, 20, TileStyle.Polished, 400),
        new(200, 100, TileStyle.Raw, 120)
    })),
    new(PatternStyle.Complex, CreateTiles(new TileConfig[]
    {
        new(12, 12, TileStyle.FancyColor, 318),
        new(20, 10, TileStyle.Ornate, 102),
        new(30, 30, TileStyle.SimplePattern, 200)
    }))
};
var companies = new Company[]
{
    new("Fein & Stein GmbH", 50, 80, 5, new Worker[]
    {
        new("Hans Heimlich", WorkSpeed.Slow),
        new("Sarah Schnell", WorkSpeed.Fast)
    }),
    new("Flooring Perfection AG", 92, 119, 9, new Worker[]
    {
        new("Petra Perfekt", WorkSpeed.Slow),
        new("Moritz Meister", WorkSpeed.Regular),
        new("Günther Genau", WorkSpeed.Slow)
    }),
    new("Schnellbelag GmbH", 38, 56, 4, new Worker[]
    {
        new("Paul Pfusch", WorkSpeed.Fast)
    })
};

for (var i = 0; i < patterns.Length; i++)
{
    PrintEstimates(i + 1, patterns[i], companies);
}

#region helper methods

static void PrintEstimates(int no, TilePattern pattern, Company[] companies)
{
    Console.WriteLine($"For pattern #{no} the companies provided the following quotes:");
    foreach (var company in companies)
    {
        Console.WriteLine($"{company.Name}: {company.GetCostEstimate(pattern):C2}");
    }

    Console.WriteLine();
}

static Tile[] CreateTiles(TileConfig[] configs)
{
    var totalTiles = 0;
    foreach (var config in configs)
    {
        totalTiles += config.Amount;
    }

    var tiles = new Tile[totalTiles];
    var idx = 0;
    foreach (var config in configs)
    {
        for (var i = 0; i < config.Amount; i++)
        {
            tiles[idx++] = new(config.Style, config.Width, config.Height);
        }
    }

    return tiles;
}

internal record TileConfig(int Width, int Height, TileStyle Style, int Amount);

#endregion