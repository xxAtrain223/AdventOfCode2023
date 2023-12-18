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

        mapper.MapForward(98).Should().Be(50);
        mapper.MapForward(99).Should().Be(51);

        mapper.MapForward(50).Should().Be(52);
        mapper.MapForward(51).Should().Be(53);

        mapper.MapForward(1).Should().Be(1);
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

        mapper.MapForward(15).Should().Be(0);
        mapper.MapForward(16).Should().Be(1);

        mapper.MapForward(52).Should().Be(37);
        mapper.MapForward(53).Should().Be(38);

        mapper.MapForward(0).Should().Be(39);
        mapper.MapForward(1).Should().Be(40);

        mapper.MapForward(55).Should().Be(55);
    }

    [Fact]
    public void ShouldMapBackward()
    {
        var mapString = """
            seed-to-soil map:
            50 98 2
            52 50 48
            """;

        var mapper = new ValueMapper(mapString);
        mapper.MapBackward(50).Should().Be(98);
        mapper.MapBackward(51).Should().Be(99);

        mapper.MapBackward(52).Should().Be(50);
        mapper.MapBackward(53).Should().Be(51);

        mapper.MapBackward(1).Should().Be(1);
    }
}
