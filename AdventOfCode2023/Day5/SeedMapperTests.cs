namespace AdventOfCode2023.Day5;

public class SeedMapperTests
{
    private const string MappingsString = """
        seeds: 79 14 55 13

        seed-to-soil map:
        50 98 2
        52 50 48

        soil-to-fertilizer map:
        0 15 37
        37 52 2
        39 0 15

        fertilizer-to-water map:
        49 53 8
        0 11 42
        42 0 7
        57 7 4

        water-to-light map:
        88 18 7
        18 25 70

        light-to-temperature map:
        45 77 23
        81 45 19
        68 64 13

        temperature-to-humidity map:
        0 69 1
        1 0 69

        humidity-to-location map:
        60 56 37
        56 93 4
        """;
    private readonly SeedMapper seedMapper = new(MappingsString, false);

    [Theory]
    [InlineData(79, 81)]
    [InlineData(14, 14)]
    [InlineData(55, 57)]
    [InlineData(13, 13)]

    public void ShouldMapToSoil(int seedValue, int expectedValue)
    {
        seedMapper.MapForward(seedValue, "soil").Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(79, 81)]
    [InlineData(14, 53)]
    [InlineData(55, 57)]
    [InlineData(13, 52)]

    public void ShouldMapToFertilizer(int seedValue, int expectedValue)
    {
        seedMapper.MapForward(seedValue, "fertilizer").Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(79, 81)]
    [InlineData(14, 49)]
    [InlineData(55, 53)]
    [InlineData(13, 41)]

    public void ShouldMapToWater(int seedValue, int expectedValue)
    {
        seedMapper.MapForward(seedValue, "water").Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(79, 74)]
    [InlineData(14, 42)]
    [InlineData(55, 46)]
    [InlineData(13, 34)]
    public void ShouldMapToLight(int seedValue, int expectedValue)
    {
        seedMapper.MapForward(seedValue, "light").Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(79, 78)]
    [InlineData(14, 42)]
    [InlineData(55, 82)]
    [InlineData(13, 34)]
    public void ShouldMapToTemperature(int seedValue, int expectedValue)
    {
        seedMapper.MapForward(seedValue, "temperature").Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(79, 78)]
    [InlineData(14, 43)]
    [InlineData(55, 82)]
    [InlineData(13, 35)]
    public void ShouldMapToHumidity(int seedValue, int expectedValue)
    {
        seedMapper.MapForward(seedValue, "humidity").Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(79, 82)]
    [InlineData(14, 43)]
    [InlineData(55, 86)]
    [InlineData(13, 35)]
    public void ShouldMapToLocation(int seedValue, int expectedValue)
    {
        seedMapper.MapForward(seedValue, "location").Should().Be(expectedValue);
    }

    [Fact]
    public void ShouldReturnSeeds()
    {
        seedMapper.Seeds.Should().BeEquivalentTo([79, 14, 55, 13]);
    }

    [Fact]
    public void ShouldFindMinimumLocation()
    {
        seedMapper.FindMinimumLocationForward().Should().Be(35);
    }

    [Fact]
    public void FindMinimumLocationForwardRange()
    {
        SeedMapper seedMapper = new(MappingsString, true);
        seedMapper.FindMinimumLocationForwardRange().Should().Be(46);
    }
}
