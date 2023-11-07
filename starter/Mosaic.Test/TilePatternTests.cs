namespace Mosaic.Test;

public sealed class TilePatternTests : TestBase
{
    [Fact]
    public void Area()
    {
        Tile[] tiles = CreateSampleTiles();
        var pattern = new TilePattern(PatternStyle.Simple, tiles);

        pattern.Area
            .Should().Be(0.04095, "the pattern reports its area in m2");
    }

    [Fact]
    public void CalcProductionCost()
    {
        Tile[] tiles = CreateSampleTiles();
        var pattern1 = new TilePattern(PatternStyle.Simple, tiles);
        var pattern2 = new TilePattern(PatternStyle.Complex, tiles);

        pattern1.CalcProductionCost()
            .Should().Be(9.4616M, "the production cost of a pattern is the sum of the production cost of its tiles");
        pattern2.CalcProductionCost()
            .Should().Be(pattern1.CalcProductionCost(), "pattern style does not change the production cost");
    }

    [Fact]
    public void Construction()
    {
        Tile[] tiles = CreateSampleTiles();

        var instance = new TilePattern(PatternStyle.Complex, tiles);

        instance.Style
            .Should().Be(PatternStyle.Complex, "ctor has to set Style property correctly");
        CheckField(instance, tiles, $"_{nameof(tiles)}")
            .Should().BeTrue("ctor has to set tiles field correctly");
    }

    [Fact]
    public void Pieces()
    {
        Tile[] tiles = CreateSampleTiles();
        var pattern = new TilePattern(PatternStyle.Simple, tiles);

        pattern.Pieces
            .Should().Be(tiles.Length, "a pattern has as many pieces as it has individual tiles");
    }
}