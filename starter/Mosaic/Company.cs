namespace Mosaic;

/// <summary>
///     Represents a flooring company
/// </summary>
public sealed class Company
{
    private const int DefaultPiecesPerHour = 25;
    private readonly decimal _hourlyWage;
    private readonly decimal _m2Price;
    private readonly int _profitMargin;
    private readonly Worker[] _workers;

    /// <summary>
    ///     Constructs a new <see cref="Company"/> instance based on the supplied configuration.
    /// </summary>
    /// <param name="name">The name of the company</param>
    /// <param name="m2Price">Base price per m2 of floor, independent of pattern type</param>
    /// <param name="hourlyWage">Hourly wage of each worker (paid by customer)</param>
    /// <param name="profitMarginPercent">Profit margin put on top of the production cost of the tiles</param>
    /// <param name="workers">Array of the company's employees</param>
    public Company(string name, decimal m2Price, decimal hourlyWage, 
        int profitMarginPercent, Worker[] workers)
    {
        // TODO
    }

    /// <summary>
    ///     Gets the name of the company
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Calculates how much this specific company would charge when tasked with executing the
    ///     supplied pattern. This includes production cost as well as work costs.
    /// </summary>
    /// <param name="pattern">Pattern to create</param>
    /// <returns>Cost estimate for the supplied pattern</returns>
    public decimal GetCostEstimate(TilePattern pattern)
    {
        // TODO
    }

    /// <summary>
    ///     Calculates how many pieces the workers of this company (together) are able to place per hour.
    ///     This takes into account the complexity of the pattern as well as the working speed of
    ///     each employee.
    /// </summary>
    /// <param name="patternStyle">Defines if the pattern is simple or complex</param>
    /// <returns>Number of tiles this company is able to place per hour</returns>
    private double CalcPiecesPerHour(PatternStyle patternStyle)
    {
        // TODO
    }
}