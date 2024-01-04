namespace AdventOfCode2023.Day05;

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

    [Fact]
    public void ShouldMapSeedToSoilRanges()
    {
        var mapString = """
            seed-to-soil map:
            52 50 48
            50 98 2
            """;

        var mapper = new ValueMapper(mapString);

        mapper.MapRangesForward([
                (79, 14),
            (55, 13)
            ])
            .Should()
            .BeEquivalentTo([
                (57, 13),
                (81, 14)
            ]);
    }

    [Fact]
    public void ShouldMapSoilToFertilizerRanges()
    {
        var mapString = """
            soil-to-fertilizer map:
            39 0 15
            0 15 37
            37 52 2
            """;

        var mapper = new ValueMapper(mapString);

        mapper.MapRangesForward([
                (57, 13),
            (81, 14)
            ])
            .Should()
            .BeEquivalentTo([
                (57, 13),
                (81, 14)
            ]);
    }

    [Fact]
    public void ShouldMapFertilizerToWaterRanges()
    {
        var mapString = """
            fertilizer-to-water map:
            42 0 7
            57 7 4
            0 11 42
            49 53 8
            """;

        var mapper = new ValueMapper(mapString);

        mapper.MapRangesForward([
                (57, 13),
            (81, 14)
            ])
            .Should()
            .BeEquivalentTo([
                (53, 4),
                (61, 9),
                (81, 14)
            ]);
    }

    [Fact]
    public void ShouldMapWaterToLightRanges()
    {
        var mapString = """
            water-to-light map:
            88 18 7
            18 25 70
            """;

        var mapper = new ValueMapper(mapString);

        mapper.MapRangesForward([
                (53, 4),
            (61, 9),
            (81, 14)
            ])
            .Should()
            .BeEquivalentTo([
                (46, 4),
                (54, 9),
                (74, 14)
            ]);
    }

    [Fact]
    public void ShouldMapLightToTemperatureRanges()
    {
        var mapString = """
            light-to-temperature map:
            81 45 19
            68 64 13
            45 77 23
            """;

        var mapper = new ValueMapper(mapString);

        mapper.MapRangesForward([
                (46, 4),
            (54, 9),
            (74, 14)
            ])
            .Should()
            .BeEquivalentTo([
                (82, 4),
                (90, 9),
                (78, 3),
                (45, 11)
            ]);
    }

    [Fact]
    public void ShouldMapTemperatureToHumidityRanges()
    {
        var mapString = """
            temperature-to-humidity map:
            1 0 69
            0 69 1
            """;

        var mapper = new ValueMapper(mapString);

        mapper.MapRangesForward([
                (45, 11),
            (78, 3),
            (82, 4),
            (90, 9),
        ])
            .Should()
            .BeEquivalentTo([
                (46, 11),
                (78, 3),
                (82, 4),
                (90, 9),
            ]);
    }

    [Fact]
    public void ShouldMapHumidityToLocationRanges()
    {
        var mapString = """
            humidity-to-location map:
            60 56 37
            56 93 4
            """;

        var mapper = new ValueMapper(mapString);

        mapper.MapRangesForward([
                (46, 11),
            (78, 3),
            (82, 4),
            (90, 9),
        ])
            .Should()
            .BeEquivalentTo([
                (46, 10),
                (60, 1),
                (82, 3),
                (86, 4),
                (94, 3),
                (56, 4),
                (97, 2)
            ]);
    }
}
