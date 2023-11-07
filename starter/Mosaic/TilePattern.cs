namespace Mosaic;

/// <summary>
///     Represents a mosaic consisting of several tiles.
/// </summary>
public class TilePattern
{
    private readonly Tile[] _tiles;
    public int Pieces => _tiles.Length;
    public double Area => _tiles.Sum(x => x.Area)*0.000001;
    public PatternStyle Style { get; }

    public TilePattern(PatternStyle style, Tile[] tiles)
    {
        this._tiles = tiles;
        this.Style = style;
    }

    public decimal CalcProductionCost() => _tiles.Sum(x => x.CalcProductionCost());

}