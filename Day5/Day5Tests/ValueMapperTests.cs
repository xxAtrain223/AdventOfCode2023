namespace AdventOfCode2023.Day5.Day5Tests;

public class ValueMapperTests
{
    [Fact]
    public void ShouldMapSeedToSoil()
    {
        var mapString = """
            seed-to-soil map:
            50 98 2
            52 50 48
            """;

        var mapper = new ValueMapper(mapString);

        mapper.Source.Should().Be("seed");
        mapper.Destination.Should().Be("soil");

        mapper[98].Should().Be(50);
        mapper[99].Should().Be(51);

        mapper[50].Should().Be(52);
        mapper[51].Should().Be(53);

        mapper[1].Should().Be(1);
    }

    [Fact]
    public void ShouldMapSoilToFertilizer()
    {
        var mapString = """
            soil-to-fertilizer map:
            0 15 37
            37 52 2
            39 0 15
            """;

        var mapper = new ValueMapper(mapString);

        mapper.Source.Should().Be("soil");
        mapper.Destination.Should().Be("fertilizer");

        mapper[15].Should().Be(0);
        mapper[16].Should().Be(1);

        mapper[52].Should().Be(37);
        mapper[53].Should().Be(38);

        mapper[0].Should().Be(39);
        mapper[1].Should().Be(40);

        mapper[55].Should().Be(55);
    }
}
