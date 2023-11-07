namespace Mosaic;

/// <summary>
///     Represents a single tile of a mosaic floor.
/// </summary>
public sealed class Tile
{
    private readonly TileStyle _style;
    private readonly int _width;
    private readonly int _height;

    public int Area => _width * _height;

    public Tile(TileStyle style, int with, int height)
    {
        this._style = style;
        this._height = height;
        this._width = with;
    }
    public decimal CalcProductionCost()
    {
        return Area * 0.00016M * CalcSizeFactor() * CalcStyleFactor();
    }

    private decimal CalcStyleFactor()
    {
        switch (_style)
        {
            case TileStyle.Raw:
                return 0.8M;
            case TileStyle.Polished:
            case TileStyle.PlainColor:
                return 1M;
            case TileStyle.FancyColor:
                return 1.1M;
            case TileStyle.SimplePattern:
                return 1.25M;
            case TileStyle.Ornate:
                return 2.3M;
            default:
                return -1M;
        }
    }

    private decimal CalcSizeFactor()
    {

        switch (Area)
        {
            case < 100:
                return 1.5M;
            case < 400:
                return 1.2M;
            case <= 2500:
                return 1;
            case > 8100:
                return 1.8M;
            case > 2500:
                return 1.6M;
            default:
                return -1;
        }
    }
}