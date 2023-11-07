namespace Mosaic;

public enum TileStyle
{
    Raw,
    Polished,
    PlainColor,
    FancyColor,
    SimplePattern,
    Ornate
}

public enum PatternStyle
{
    Simple,
    Complex
}

public enum WorkSpeed
{
    Slow,
    Regular,
    Fast
}

public record Worker(string Name, WorkSpeed WorkSpeed);