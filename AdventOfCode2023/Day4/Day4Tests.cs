﻿namespace AdventOfCode2023.Day4;

public class Day4Tests(ITestOutputHelper Output)
{
    [Fact]
    public void Part1()
    {
        var sumOfCardScores = Card.SumCardScores(InputLines);
        Output.WriteLine(sumOfCardScores.ToString());
    }

    [Fact]
    public void Part2()
    {
        var cardCount = Card.Count(InputLines);
        Output.WriteLine(cardCount.ToString());
    }

    private static string Input => """
        Card   1: 58 96 35 20 93 34 10 27 37 30 | 99 70 93 11 63 41 37 29  7 28 34 10 40 96 38 35 27 30 20 21  4 51 58 39 56
        Card   2: 64 84 57 46 53 86 90 99 59 70 | 99 59 30 83 84 70 31 57  6 29 18 82 15 88 86 53 51 64 32 47 44 46 80 39 90
        Card   3: 55 87 51 18 86  5 66 83 92 95 | 73 68 49 57 29 14 41 42 65 10 84 34 67 44  6 48 61 13 28 38 52 19 78 64 11
        Card   4: 52 21 59 78 18 42 46 91 31 10 | 48 83 13 68 42 72  4 10  6 36 63 81 21 94  8  3 78 53  2 47 62 77 56 97  7
        Card   5:  8 79 31  1 26 57 90 62 93 10 | 26 70 73  6 16 15 93 57 34 56 87 31 10 45  1 22 79 77 90 47 42 58 41 62  8
        Card   6: 90 75 24 69 81 93 39 38 96 33 |  2 78 68 31 99 35 49 66 36 84 54 27 43 80 50  3 22 74 60 98 57 83 13 82 91
        Card   7: 74 86 51 70 28 54  6 34 48 53 | 51 82 34 74 40 24 42 66 20 61 84 15 89 62 69 48 95 31 93 52 76 12 90 75 99
        Card   8: 54 44 69  6 51 24 84 39 20 99 | 89 93 96 85 18 94 15 87 72 67  5 52 45 43 55 65 14 47 30 61 82 41 76 29 38
        Card   9: 26 44 60 20 11 15 16 95 18 47 | 71 56 10 57 65 90 32 30 13 42 19 55 29 12 89 91  2 67 79 58 99  4 81 41 69
        Card  10: 68 65 79  3 44 55 12 71 47 84 | 47 65 93  4 71 23 17 30 59 85  3 28 95 36 88 12  7 97 68 62 84 21 79 61 44
        Card  11: 96 57 36 49 80 73  3 60 11 53 | 83 78  6 39 42  4 96 84  3 80 95 60 97 57 49 66 27 93 31 45 86 90 50  9 73
        Card  12: 85 69 14  3 54 56 61 43 77 80 | 84  8 53 72  9 24 52 88 40  2 95 31 34 90 61 70 89 97 58 56 14 65 98 38  3
        Card  13: 69 29 79 83 89 94 44 68 15 35 | 37 39 29 55  2 82 96 42 73 32 31 79  8 53 88 40 44 49 69 94 87 62 41 81 89
        Card  14: 27 40 19 34 91 84 98 49 21 68 | 58 94  2  1 55 53 52 44 98  8 75 46 50 79  9 56 43 67 10  3 11 19 69 95 17
        Card  15:  3 47 44 77 95 25 60 65 93 53 | 15 40  3 93 33 44 60 19 62 90 35 50 30 65 10 94 38 47  1 29 56 46 99 91 42
        Card  16: 96 27 10 19 93 22 87 53 97  1 | 52 36 77 72 13 61 48 22 94  5 76 51 62  4 41 81 11 17 79 64 40 24 54 23 33
        Card  17: 58 74 26 97 13 61 88 82 89 22 |  9 90 82 88 61 80  3 95 94 81 75 34 71 98 89 74 97 14 47 22 64 52 73 45 35
        Card  18: 29 90  8 16 69 48 40 21 18  9 | 79 26 84 12 40 36 85 19 69 25 21  9 13 16 83  4 22 90 54 97 17  2 89 73 50
        Card  19: 10 66 52 31 72 16 62  1 58  5 | 59 36 75 11 73 92 91 12 37  9 40 52 85 53 24 69 57 82 99 35 27 34  3  2 77
        Card  20: 96  5  9 50 28 34 80  2 36 43 | 90 77 12 17 75 24 32 67 28 22 73 23 68 84  6 25 96 95 85  9 11 36 49 39 98
        Card  21: 84 16 48 91 50  1 94 45  8 88 | 45 96 15 85 62 81 77 61 92 22 76 52 59 36 73 80 64 72 89 79 93 82 83 60 67
        Card  22: 21 46 26 27 28  3  8 44 32 24 | 76  6 90 80 26 11 83  2 18 81 93 95 53 85 31 78 66 35  5  1 56 65 89 14 94
        Card  23: 58 52  2 38  5 63  8 20 99 73 | 23 29 97 91 43  1 37 95 89 80 94 41 22 72 77 62 85  4 24 16 10 39 88 56 19
        Card  24: 36 94 57 12 16 64  4 62 39 41 | 19  6 72  9 17 46 68 34 28 80 59 74 18 13 76 77 43 82 48 58  5 52 30 25 23
        Card  25: 19 14 23 16  7 35 57 40 83 80 | 80 85  7 68 91 22 40 49 35 87 83 93 19 57 23 84 14 16 18 51 77 69 28 54 56
        Card  26: 25 58 34 14 13 30 56 22 97  6 | 38 13 97 24 94 88 30 77 14 34 73  6 44 17 26 57 47 22 31 85 58 56 25 96 10
        Card  27: 41 64 75 24 62 67 45 99 73 27 | 33  9 14  5 32 50 54 20 46  4 45 71 26 59 58 22  7 30 96 34 48 37 23 15 85
        Card  28: 89 90 33 58 59 69 49 72  2 32 | 79 43 28 97 72 92 58 59 31 33 44 89 71 90 11 80 51  2 30 32 69 82 77 49 95
        Card  29: 15  6 27 80 12  2 36 34 64 58 | 15 38 53 34 32 47 64 16 60  2  3 14 62 80 79 27 12 36  6 85 58 33 69 24 57
        Card  30: 54 63 65 76 87  6 47 89 10 79 | 87 73 12 10 92 86 39 76 79  6 97 67 84 47 65 54 22 51 19 31  9 37 89 82 63
        Card  31: 23 96 48 30 75  9 72 11 78 62 | 75 24 23  1 14 72 54  2 47 95 48 18 50 12 94 78  9 96 34 30 11 98 46 62 66
        Card  32: 41 27  4 60 29 24 82 31 17 26 |  4 40 59 27 70 37 60 77 31 46 99 43 61 67 45  5 73 35 30 33 41 17 24 29 76
        Card  33: 90 49 23 13 57  1 72  5 20 81 | 61 20 51 83 54 85  8 23 17  7  1 49 39 11 92 27 90 76 10 25 57 93 13 81 66
        Card  34: 12 16 36 14 17 73 97 74 83 11 | 76 91 97 26 36 12 10 73 85  7 17 14 25 29 80 16 74 32 60 94 83 11 67 37 35
        Card  35: 92 80 27 26 61 91 28 66 15 76 | 19 64 36 42 70 77 27 91 29 66 61 18 58 15 32  8 68 67 92 80 93 76 28 26 48
        Card  36: 70 49  5 86 84 71 72 40 22 47 | 98 68 10 75 88 16 61 17 21 91 14 48 44 73 81  2 82 83 80 93 87 59 92 41 34
        Card  37: 18  9 71 88 72 74 33 50  4 40 | 96 72 41 21 40 33 18 73 91 53 71 74 46 61 80 12 88 36 70 26 66 69 39 38  9
        Card  38: 52 91  3  1 58 80 78 15 99 25 | 70 55 27 59 62 56 78 97 91 52 18  2 23 80  9  8 89 51 19 46 10 71 25 49 99
        Card  39: 85  9 86 88 36 60 90 56 77 16 | 34 26 85 46 86  2 28 31 16 22 36 83 60 37 74 81 19 27  7 17 91 49 56  3 47
        Card  40: 38 12 23 15 31 48 24 76 82 54 | 44 30 45 97  3 20 38 52 43 53 47  8 71 92 12 41 79 42 28 25 65 59 83 89 24
        Card  41: 78 11 68  8 89 13 26 93 65 54 | 84 22 71  3 53  4 15  9 81 96 26  6 40 56 95 75 30 62 65 13 33 78 41 66 44
        Card  42: 41 90 34 15 47 56 39 59 21 53 | 11 87  9 37 47 78  5 61 93 89 58 81 46 48  4 42 40 33 67 27 97 43 55 22 26
        Card  43: 42 99 37 62 40 79 15 55 76 82 | 91 21 53  1 54 63  4 51 28 59 71 61 18 66 23 10 25 38  6 20 30 87 44 11 14
        Card  44: 59 19  4 75 62 55 38 82 60 22 | 25 89 80 19 87 97 40 53 98 10 73 77 81 76 48 83 44 69 34 36 24 42 27 78 88
        Card  45: 19 76 23 87 25 13 67 52  3 60 | 92  1 96 22 26 42 54 24 57 41 49 33 72 17 77 14 78 62 11 74 73  4 47 99 59
        Card  46: 80 48 27 98 36 29 28 83 82 39 |  2 74 47 43 27 48 82 91 28 99  9 29 36 80 66  4 46 25 83 20 37 72 49 39 98
        Card  47: 39 12  2 66 78  8 58 98 95 15 | 63 78 90 49 83 72 66 56 82 92 20 21 11 89 17 51  5 55 39 48 97 19 33 22 12
        Card  48: 91 29 16 88 11 46 75 55  3 51 | 99 71  4 26 16  2 98 44 32  1 46 28 36 67 14 49 93 72 83 35 65  8 27 96 74
        Card  49: 71 93 41  5 84 26  1 33  2 94 |  2 41 54 74 33  5 13 91  1 19 65 14 34 58 84 94 23 61 85 26 20 11 71 93 22
        Card  50:  9 69 66 54  4 18 56 15 80 63 | 35 59 38 62 54 16  8 69 89 74 71 93 64 15 80 39 13 84  9 28 79 27 18 45 75
        Card  51: 83 65 33  4 48  7 68 77 42 81 | 84  4 65 48 15 77 79 92 42  7 68 96 33 85 17 87 81 58 54 83 36 75 18 94 97
        Card  52: 86 34 54 12 13 67 61 57 41  4 | 91 35 27  3 68 39 12 30 65  9 50 46 66 80 20 77 29 45 72 98 19 10 55 47 73
        Card  53: 54 98 74 15 77 79 13 41 56 33 | 18 87 53 94 98 54 92 17 72 32 10 46 47 69  6 35 63 61 89 52 55 77 49 14 60
        Card  54: 55 76 46 69 22 60 13 90 86 48 | 90 57 63 23 39 47 34 65 97  6 93 95 13 48 60 22 86 96 33 92 94 29 56 72 18
        Card  55: 90 10 36 50  2 87 48 25 56  3 | 36 16 40 26 74 57 56  6 67  3 10  2 87 25 48 69 49 61 65 68 42 91 90 50 72
        Card  56: 79 48 63 72 24 98 64 80 42 87 | 98 63 15 40 28 39 85 81 60 48 64 92 80 82 74 91 72 41 23 99 17 93 42 59 87
        Card  57: 17 95 91 39 51 56 16 14 54 33 | 20 65 34 80 27 13  1 43 59 26 76 54 41 85 14 83 17 39 23 16 12 37 49 44 24
        Card  58: 50  9 39 92 89 62 74 56 73 61 | 78 92 68 31 13 28 83 61  8 14 56 62  6 16 50 39 24  9 58  1 17 89 48 15 12
        Card  59:  6 92 15 50 99 29  3 72 12 95 | 73 72 80 92 88 19 55 12 53 93 91 45 26 15 99 43 84 62 59 49  6 64 77  3 16
        Card  60: 14 93 76 15  7 90 39 30 83 32 | 83 35 69 40 60 77 73 75 36 27 94 80 90  1 56 99 93 13 37 45 22 26 31 20 70
        Card  61: 50 64 24 26 72  8 33 13 22 27 | 45 60 37 19 55 95 76 52  4  9 75 44 78 20 53 41 69 11 47 36  2 48 74 94 21
        Card  62: 55 87  6 12 83 97 11 94 56 19 |  4 71 56 25 88 50 55 42 10 28 81 60 59 22 44 49 86 66 94 31 62 84 57 90 51
        Card  63: 89 13 38 94 61  8 79  1 11 80 |  5 55 56 13 84 39 54 32 79 74 58 96 82 53 21 91 64 42 41 94 44 97 95 28 14
        Card  64: 39 73 72 12 74 58 57 50 25 24 |  1 49  3 46 89 26 78 24 28 21 54 64 86 88 30 91 43 15 98 23 99 12 22 79 33
        Card  65: 58 65 74 21  7  3 95 71 50 41 |  3 53 28 78 18 65 52 89 33 30 87 13 62 72 88 37 71 26 27 19 46 98 84 76  4
        Card  66: 27 73 68 71 55 33 88 30 56 87 | 50 74 97 18 34  5 65 66 93 31 57 32 69 38 28 60 81 43 87 98 53 86 59 49 14
        Card  67:  9 50 66 57 33 76 65 84 44 88 | 34 85 27 32 12 77 63  3 95 93  4 10 70 38 49 19 41 83 14 72 16  5 40 57 24
        Card  68: 71 27 65 58 38 62 73 23 77 57 | 51 56 61 78 41 68 22  2 20 64  6 24 45  5 72 79 13 67 85  7 50 48 93 80 26
        Card  69: 36 60  4 27 41 67 61 88 50 83 | 67 45 29 66 36 59 95 60 41 28 43 37 61  4 84 88 23 49 92 65 89 27 50 83 58
        Card  70: 34 37 95 65 11 29 98 15 55 68 | 13 58 34 52 29 46 72 25 68  5  7 87 42 51 61 98 75 15 65 33 95 11 83 55 60
        Card  71: 13 67  2 41 43 52 47  6 54 51 |  2 81 22 30 13 52  5 10 67 50 86 54  3 51 92 15 37 79 43 11 41  6 69 47 25
        Card  72: 51 72 65 50 55 80 48 87 13 10 | 28  5 41 51 42 45 87 98 35 64 93 72 65 55 50 88 13 74 48 63 80 10 34 86 40
        Card  73: 98 36 68 48 17 75 64 11 70 61 | 17 50  8 89 93  3 65 14 85 33 23 55 42 40 63 84  1 62 20 86 36 51 80 16 77
        Card  74: 75 10 74 42 71 63 14  2 12 96 | 33  7 65 96 38  6 17 34 18 40 71 61 95 14 27 46  2 91 66 58  8 19 31 16 25
        Card  75: 88 90 82 53 34  4 28 57  2 51 |  2 16 46 87 34 51 88 90  3 79 28 57 20 80 44 22 42 12 82  1 53  4 56 83 99
        Card  76: 75 48  5 98 51  7 34 67 66 32 | 93 92 75 43  1 98 71 19 13 40 29 85 67 66 12 25 83 39 48  8  7  5 31 65 33
        Card  77: 87 73  2 20 57  7 99 23  4 81 |  3 10 65 56 26 84 34 78 17 66 44 72 69 76 30 95  5 38 28  8 70 22 99 82 54
        Card  78:  2 48 95  8 80 41 26 96 47 50 |  1  5 21 24 91 29 22 47 98 57 82 42 72 94 62 90  2 95 49 36  6 71 27 70 33
        Card  79: 32 35  6 27 72  8 81 44 28 43 | 59 79 54 18 51 82 25 61 83 37 12 94 41 74 69 16 73 65  1 26  9 33 29 34 66
        Card  80: 46 43 77 74 73 26 84 50 86 24 |  6 29 89 70 16  3 98 92 17 27 79 86 31 93 85 41 96 91 77 48 14 66 18 54 99
        Card  81: 69 60 90 30 65 28 96 97 41 38 | 40  3 44 62 94 97 57 60  9 85 17 88 28 96 22 77 72 36 30 52 83 95 73 48 80
        Card  82: 27 47 86 26 46 44 59 63 31 58 | 51 13 11 50 35 89  8 78 54 82 67 64 15 83 73 74 57  4 76 29 43 90 91 37 22
        Card  83: 84  6  1 64 33 37 68 83 72 90 | 41 69 59 91 46 40 22  5 51 27 76 45 32 43 37  3 10 85 26 81 87 56 25 67 55
        Card  84: 61 83 50 49 91 12 98 38  6 78 | 93 73 96 62 70 39 59  5 48 18 40 63 90 22 61 46 50 66 91 95 88 71 76 87 29
        Card  85:  3 60 82 33 22 43  9 98 50 89 | 48 56 15 77 25 92  6 41 84  2 49 29 61 57 51 64 96 36  7 22 31 32 28 30 59
        Card  86: 48 22 41 64 65 16 25 36 29 76 | 86  5 19 89 36 60 27  1 11 67 98 73 35 75 61 21 92 91 93 66 47 39 87 68 52
        Card  87: 68 42 18 51 79 37  9 34  8 85 | 12  7 19 30 91 84 29 53 73 65 48 94 17 22  4 32 33 15 93 75 38 31 41 86 67
        Card  88: 50 35 98 64 91 37 80 75 39  8 | 37 13 35 24 64 91 75  4 63 45 98 56 85  8  1 29 43 97 65 50 80 74 25 32 39
        Card  89: 55 87  4 74 33  2 61 37 94 57 | 37 25 55 48  2 40  5 38 94 85 87  4  7 51 57 75 43 61 34 67 17 74 24 10 33
        Card  90: 76 98 38 16 60 19 93 26 48 43 | 72  8 26 45 98 61 67 16 42 43 29 76 93 50 79 38 27 15 19 54 99 60  3 88 48
        Card  91: 64 67  7 18 71 96 45 89 39  2 | 71 21 98 87 39 19 57 45 86  7 49  2 67 20 96 74 90 64 18 17 89 99 23 59 16
        Card  92: 68 66 33 78 22 62 39 31 37  5 | 95 40 33 37  5 22 66 78 10 68 63 43 90 31 46  8 62 32 98 73 39 21 45 13 20
        Card  93: 21 25  2 91 58 37 51 60 12 74 | 47 40 51 66 77 63 84 68  2  4 60 75 91 21 22 35 32 80 74 37 58 20 12 14 27
        Card  94: 81 48 43 59 86 85  2 92 27 35 | 34 84 11  6 25  1 96 24 30  8 21 33 74 57 70 91 66 20  7 75 36 73 53 87 62
        Card  95: 15  2 41 54 12 45  3 56 77  9 | 12 60  7 97 49 96 99 32 24 63 16 62 68 88 26 43 54 20 27 33 47 19 58 15 75
        Card  96: 90 47 53 86 39 54  7 82 65 22 | 84 62 70 82 78 65 53 86 30 73 57 47 72 54 39 11 35 83 22 40 28  7 21 90 63
        Card  97: 17 25 87 43 20 84 75 78  6 53 | 75  6 64 90 87 61 11 31 36 60 38 78 46 27 82 72 16 95 57 17 30 53 94 77  3
        Card  98: 45 18 60 22 16 91 39 27 38 88 | 18 88 92 49 79 10 38 98 35 99 89 91 23 32  9 39  1 64 48 11 22 15 66 82 21
        Card  99:  6 42 69 91 94 38 87 11 97 26 |  6 71 11 69 16 97 49 73 45 48 38 87 42  2 67 26 89 95 81 30  1 91 20 10 66
        Card 100: 57  7 39 52 99 68 48 24  2 16 |  1 43 77 38 25 18 41 73 26 12 90  3 95 54 22 72 65 83 11 32 37 85 14 71 29
        Card 101: 48 71 81 27 52 26 75 95 19 54 | 19 59 90 24 17 56 34 39 49 88 80 75 10 58 86 55 26 67 89 85 65 40 30 81  6
        Card 102: 35 62 57 40 79 63 37 33 60 17 | 37 35 33 97 79 75  7 19 59 67 23 63 41 17 85 58 42 38 53 36 83 60 62 76 95
        Card 103: 91 18 51  5 41 61 26 94 47 85 | 26 58 65 41 96 83 30 63 78 87 90  4 53 95  6  8 98 36 82 76 92 34 28 94 56
        Card 104: 45 38 79 42 74 18 16 61 65 89 | 58  5 84 72 51 22 52 56 64 11 23 38 16 93 24 25 29 66 41 35 77 20 95 17  1
        Card 105:  9 97 56 51 55 62 19 75 83 47 | 58 15 96 43 24  9 47 80 95 71 62 29 72 39 40 19 61 52  8 32 88 69 27 70 86
        Card 106: 82 26 96 33 35 50 19 78 64 91 |  9 17 70 96 89 91  4 52 75 56 64 14 63 32 50 73  7 81 46 10 53 42 99 95 26
        Card 107: 66 58 63  7 95 46 42 97 67 59 | 96 23 86  7 58 61 14 17 93 45 39 60 28 32 15 46 55 35  2 44 22 27 78 94 68
        Card 108: 48  3 54 58 30 47 71 74 28 37 | 44 62 60 16 97 71 23 35 49 24 93  7 65 87 19 99 89 28 34 45 90 70 64 20 66
        Card 109:  3 90 39 83 16 47 44  1 28 65 | 38 48 24 37 96 81 60 54  6 58 68 23 21 35 26 45 98 85 40 63 64 80 29 97 34
        Card 110:  3 12 59 28 93 26 92 52 38 64 | 65 36  5 49 72 86  6 33 84 73 98 89 47 61 57 14 32 44 10 97 69 40 99  7 51
        Card 111:  3  2 30 72 16 80 46 52 51 64 | 76 86 57 44 89 26 96 10  1 23 59 32 60 41 77 73 68 29 78 75 62 28  6 99 71
        Card 112: 84 34 17 40 47 44 33 99 65 79 | 65 74 97 55 33 13 52 34 47 40 17 56  6 96 76  8 59 51 99 84 18 48 79 44 24
        Card 113: 13 92  5 86 85 36 74 28 82 18 | 48 36  5 37 46 95 90 82 19 68 10  8 11 18 80 69 63 86 85 28 92 64 71 32 94
        Card 114: 96 50 90 97 11 42 79 78 56 26 | 78 50 27 47 96 97 62 42 26 86 84 72 79 20 11 43  8 64 87 95 56 68 90 67 52
        Card 115: 29 36 84 82 38 61 86 73 25 45 | 37 58 28 45  6 36 29 43 95 92 56 73 44 83 25 97 61 82 84 71 69 38 77 86 42
        Card 116: 97 19 96 10 44 26 81 79  7 89 | 39 55 63  4 94 24 29 12 65 84 68 31 75 23 15 71 54 82 56 42  5 53 96 40 51
        Card 117: 74 94 58 42 30 40 97 33 73 93 | 62 59  9 41 71 98 97 19 32 24 40  1 56 14 74 87 52 92 61 90 37 45 20 80 31
        Card 118: 96 45 27 88  2 82 87 99 39 17 | 53 36 44 55 21 88 33 74 26 22 61 46 18 43 20 68 54 49 87 67 35 73  3 63  1
        Card 119: 80 19  2  6 68 32 23 22 99 28 | 20 40 66 38 87 59 41 55 54 57 21 12 11 45 65 16 24  3 63 68 73 98 99 14 17
        Card 120: 84 92 65 58 80 55  2 72 78 75 | 66 64 44 88  1 41 59 13 29 52 30 71 90 21 76 87 73 70 25 61 26 69 32 81 95
        Card 121: 52 32 92 91 42  8 15 19  1 30 | 89 92 96 46 25 24 48 90 59 83 15 75 28 57 61 39 43 42 84 95 45 73 41 98 67
        Card 122: 70 89 60 43  1 58 49 46 28 45 | 74 62 66 13 67 95 55 10  9 70 54 84 29 31  8 96 59 81 27  3 63 12  1 82 87
        Card 123: 41 51 96 76 48 54  4 71 45 84 | 68 66  2  4 78 15  1 62 75 94 59  7 12 28 60 39 16 42 61  8 84 89 46 95 35
        Card 124: 48 61 35 81 94 73 98 46 53 85 | 55  2 40  3 84  4 11 88 77 62 79 39 85 27 36 82 33 93 29 47 67 50 12 91 19
        Card 125: 63 44 28 58  5 26 85 93 50 76 | 39 10 25 30  2  3 42 60 94 83 57  9 75 13 67 90 36 81 18 72 23 37 48 19 69
        Card 126: 41 28 15 87 88 50 57 27 78 30 |  3 24 89 91 47 40 11 83 76 33 53 74  9 42 43 66 70 17 99 29 75 19 98 90 64
        Card 127: 77 24 27  2 59 54  6 61 65 12 | 34 42 68 15 70 75  2 27 61 40  6 13 24 54 12 59 44 65 22 88 86 77  3 79 64
        Card 128:  3 15 55  7 80 69 64 13 77 33 | 34 50  3 17 88 66 79 59 38  1 41 11 55  8  7 80 68 25 16 46 61 19 13 74 33
        Card 129: 26 19 39 29  4  6 55 49 67 12 | 72 53 12 63 64 49 19 98  3 45  4 35 28 43 51 26 38 23 96 44 22  7 79 80 67
        Card 130: 80 61  1 62 46  5 84 17 14 49 | 75 84 61 85 29 62 46  1 17 63  3 31 57 79 19 58 96 14 76 42 32 49  5 80 56
        Card 131: 63 30  2 29 71 37 12 36 16 47 | 14 82 99 98 52 39 19 60  4 90 74 33 65 27 62  7 32 64 10 37 35 15 11 69 59
        Card 132: 68 81 89 42 36 34 18 53 74 41 | 24 37 14 73 97 54 59 90  9 29 49 10 47 32 85 87 99 98 78 39 27 22 57 81 33
        Card 133: 89  9 10 61 30 81 36 84 70 12 | 69 10  4 90 65 50 93 34 54 13 80 16 98 49 42 35 77 61 85 55 86  6 11 23 39
        Card 134: 27 19 90 30 85 41 58 79 53 11 | 15 58 36 52 11 93 54 24 26 39 51 79 56 35 30 85 53  6 17 32  5 16 87 27 33
        Card 135: 26 44 30 42 99 89 76 27 64 48 | 38 70 95 25 60  2 49 35 71  5 17 63 62 88 20 41 79 19 67 72 40 46 81 10 74
        Card 136: 70 64 49 85 48 16 41 52 91 24 | 48  2 62 28 54 78 50 52 83  7 43 90 96 60 10 26 12  6 95 51 91 25 47 67 87
        Card 137: 10  6 53 80  8 93 62 98 60 82 | 28 19 36  1 14 73 85 16  8 32 21 13 97 90  2 29 34 69 55 80  6 27 62 37 10
        Card 138: 28 25 60 17 99 39 35 48 34 26 | 46 32 33 43 98 10 62 70 41 17 40 27 34 67  4 26 85 63 58 60 16 97 14 57 20
        Card 139: 42 49 16 73 10 23 35 41 93  8 | 76 28 17 32 91 96 92 19 61 97 88 27 83 80 72 57 87 33 14 67 42 10 64 94 65
        Card 140: 81 17 80 94 54 21 57 12 60 48 | 88 27  7 11  6 28 98 33 94 77 14 53  1 92 50 22 93 49 18 86 84 63 42 64 90
        Card 141: 98 31 93 30 72 39 33 35 57 54 | 45 95 69 89 51 55 21 67 50 68 46  5 86 65 17 82 29 48  8 91 71 63 25 52  1
        Card 142: 81 61 78 99 24 42 13 10  3  9 |  8 41 38 63  5 82 54 46 67 83 45 20 44 19 91 92  1  4 77 32 17 59 21 50 94
        Card 143: 78 65 47 51 54 16 23 59 39 34 | 34 53 78  4 29 59  3 87 23 73 16 65 24 38 58 21 89 92 54 39 47 30 66 37 88
        Card 144: 61 73 60 75  2 23 24 44  1 40 | 45 72  5 22 77 88 78 21 76 16 39 85 46 51 97 80  4 27 41 37  9 71 38 28 65
        Card 145: 28 24 22 79 56 23 51 50 54 63 | 22 25 11 44 59 28 50  2 29 85 79 24 54  8  6 23 92 20 71 56 81 95 51 26 63
        Card 146: 28 74 36 10 32 15 72 30 83 73 | 76  7 10 49 11 74 20 62 24 26 21 40 79 41 34 55 98 95 82 43 89 37  9 45 52
        Card 147: 80 20 78 59 53 42 31 95 63 11 | 80 59 61 57 86 42 78 53 21 95 92 75 15 31 97 72  5 11 41 90 63 56 44 25 20
        Card 148: 58 73 92 17  9 24 30 49  5 20 | 95 77 78 72 20 24  1 27 82 92 58 49 74 59  5 65 73  9 84  4 14 76 43 17 30
        Card 149: 87 18 12 98 41 27 13 48 82 37 | 87 78  2 88 61 36 95 25 81 18 41 33  1 69 34 57 27 73 55 12 82 31 59 48  6
        Card 150: 35 47 42 66 43 72 76 68 21 20 | 83 85  8 71 21  6 60 74 96 55  2 19  9 11 98 62 20 39 41 10 30 81 33 51 31
        Card 151: 83 24 73 61 49 67 89 95 60 43 | 59 84 28 21 26 72 37 43 38  3 13  6  9 27  7 42 77 19 65 16 71 52 29 80 33
        Card 152: 99 54 98 50 69 82 51 95 73 62 | 86 38 88 79  9 63 45 34 23 80 47 30 83 14 93  4 96 49 15 52 16 20 33 76 75
        Card 153: 76 36  9 23 70 53 41 74 27 64 | 40 71 39 29 88 19 76 97 46 23  4 68 67 33 52 95 62 91 60 11 75 13 81 99 37
        Card 154: 27 71 72  6 69 76 59 44 51 80 |  5  2 17 82 58 83  7  9 61 70 43 96 87 78 69 42 88 74 85 31 99 13 16 81 15
        Card 155: 82 71 39 56  8 42  1 63 92 11 | 16 52 94 85 67 11 98 65 50 71  2 78 43  1 41 66 86 72 77 36 30  6 46 70 38
        Card 156: 90 44 46 70 71 60  5 68 57 77 |  1 28 62 56 87 32 23 37 40 68 18 94 20 97 72 21  4 33 50 73 16 80 22 14 45
        Card 157: 60 51  2 24 69 85 55 47 62 48 |  6 86 49 55 78 42 61 98 30 77 65  4 21 20 38 93 54 18 72 44 32  8 14 58 37
        Card 158: 50 45 37  6 18 12  2 69 23 76 | 10 70 54 79 95  4 36 87 73 22 94 42 26 21 57 15  7 14 74 90 67  3 33 49 63
        Card 159: 26 12 57 16 96 61 42 99 71 25 | 25 51 26  9 47 57  4 53 61 12 97 36 76 39 99 65 92 16 78 41 71 62 48 96 42
        Card 160: 48 43 26  9 31 62 10 60 38 59 | 59 26 38  4 10 85 55  6 62 18 35 33 29 95  9 60 79 11 24 34 43 22 88 16 12
        Card 161: 15 82 90 63 18 26 57  9 47 35 | 63 23 43 56 82 92  9 42 94  4 90 89 10 26 62 32 20 30 52 85 18 19 47 66 57
        Card 162:  4 37 67 35 71 22 17 14 49 16 | 10 82  7 16 87 99 84 45 20 21 97 79 43 29 86 54 19  9 81 85 62 78  1 61 24
        Card 163: 41  6 57 96  5 21  9 89 65 27 | 26 12 23  9 17 89 33  2 28 65 92 10 97 27 96 56 80 64 90 50 52 46 42  6  5
        Card 164: 53 51 16 32 60 84 55 14 18 25 | 18 52 56 28  6 89 80 19 23 29 57 34  8 70 79 41 91 90 96 88 66 35 97 44 82
        Card 165: 17 66 59 23 35 45 32 49 56 26 |  2 74 97  9 80 76 12 50 31 15 53 41 56 33 30 98 20 44 25 81 91 45 55 99 24
        Card 166: 92 25 70 80 85 88 62 81 61 43 | 40 62 21 83 44 18 87  5 81 43 13 10 85 30  1 53 99 79 68 16 49 20 56  7 15
        Card 167: 36 63 98 92 11 59  6 47  2 83 | 41 90 83 68 54 64 25 80 56  7 99 16  5 30 27 88 63 11 22 67 81 17  9 39 95
        Card 168: 64 20 56 74  5 21 70 52 33 58 |  4 64 28  7 44 80 12 38  8 89 83 57 37 54 87 69 48 63  2 72 78 85 62 60 15
        Card 169: 13 92 14  8 98 84 54 85 97 38 | 51 90 69 98 38 13  4  8 67  5 91 14 54 68 10 18 83 56 41 25 81 73 58 17 62
        Card 170: 54 39 20 12 50  6 83 85 33 45 |  3 97 19  5 61 66 81 46 24 56 29 92 52 85 73 43 71 13 60 12 36 62 64 35 32
        Card 171: 33 36 27 29 93 73 83 62 60 82 |  4 71 14 72 45 58 10 38 12 69 27  3 95 31 84 34 66 83 21 87 22  5 75 53 35
        Card 172: 92  9 73 82 15  6 44 28 88 34 | 99 78 11 46  9 36 89 65 17  8 16 94 68 63 12 54 25 33 69 47 13 38 93 50 59
        Card 173: 41 10 43 83 81 39 66 17 28 63 | 48 79 29 20 64 59 55 46 47 45 70 62 37 16 84 68 82 88 67  2 65 97 18 56 14
        Card 174: 53 73 55 83  9 57 87 35  1 42 | 66 52 56 76 19 92 78 91 82 87 20 39 31 72 43 71 11 33 15 18 75 84 46 47 22
        Card 175: 93 51 74 60 92 84 87 58 81 34 | 67  7 99 68 30 66 27 43 65 71 28 50  2 13 32 26 72 76 17 31 49  3 54 95 82
        Card 176:  3 92 48 97 73 37 84 44 53 91 | 21 35 42 99 87 36 31 43 79 52 89  6 59 14 57 26 76 33 38 19 82 63 74 25 39
        Card 177: 46 93  6 62 56  3 76 64 59  7 | 88 46  7 98 93 76 60 59  6  3 72 64 21 40 77 78 62 47 61 42 45 99 56 28 41
        Card 178: 43 69 96 12 88 93 97 33 80 20 | 58 94 56 93 12  2 20 24 14 40 27 73 97 80 99 43 74 16 91 88 33 96 71 25 69
        Card 179: 59  1 88 53 87 90 39 32 97 89 | 70 57 90 20 73 35 32 88 58 71 36 59 33  1 55 97 87 98 45 39  9 96 53 60 89
        Card 180: 33 19 87 82 90  1 14 78 84 35 | 89 19 20  3 66 23 87 54 78 39 65 84 35 83 33 69 14 90 44 49 72 38 75 82  1
        Card 181: 60 32 78 83 82 29 90 14 46 87 | 63 72 92 39 75 10 43 40  7 89 11 32 86 54  4 90 68 45 95 91 13  1 56  6 29
        Card 182: 11 18 63 73 64 39  9 92 82 62 |  8 27 69 64  3 53 73 11 21 39 10 18 35 44 56 62 75 72  4 51  6 42 82 37 76
        Card 183: 88 56 32 39 23 49 92 50 59 28 | 92  2 48 32 63 49 59 83 56  1 91 41 50 88 28 17 39 57 20 36 34  6 60 23 42
        Card 184: 34 97 99 76 32 75 69 83 60 79 | 44 86 52 99 85 32 34  4 28 79 76 46 22 83 54 56 60 31 75 51 80 89 45 69 97
        Card 185: 74 35 67  1 55 18 60 37 17 50 | 85 50 44 20 87 14 22 32 55 18 17 59 28 93  1 96 68 37 74 60 98 97 67 35  4
        Card 186: 44 36  3 80  6 24 90 81 34 61 | 76 69 14 77 53 21  4 16 18 46  9 59 34 38 98 13 30 11  7 17 88 41 42 99 23
        Card 187: 54 53 39 24 80 78 13 46 17 67 | 62 91 86 52 80 59 26 78 73 46 16 77 18 37  9 55 13 17 72 69 32 68 67 34 81
        Card 188: 50 19 11 73 61 75 67 54 12 84 | 73 84 97 56 74 59 35 75 61 14 15 19 24 12 51  6 58 11 89 67 53 25 21 54 50
        Card 189: 76 48 38 17 97 67 42 23 82  6 | 73 10 17 70 85 95 54 43 93 91  3 82 26 16 23 76 33 38 67 48  5 53 97  6 42
        Card 190: 61 19 93 50 11 56 32  5 84 37 | 32 62 82 84 50 61 91 15 69 19 68 20 74 92 10 55 11 93 39 37 18  5 47 22 46
        Card 191:  2 58 93 26 23 31 60 74 35 47 | 74 64 26 68  8 60 11 73 93 42 87  2 31 97 61 47 65 24 58 66 53 38 94 46 88
        Card 192: 64 37 49 88 95 79 29 59  2 99 | 39 63 31 68 36 24 60  9 94 89 93 13 45 77 38 55 14 23 92 83 29 33 44 34 71
        Card 193: 19 23 99 89 26 80 63 60 59 66 | 78 80 99 60 66 47 84 59 24 61  5 63 67 26 87 42 96 10 54 98 19 81  4 43  8
        Card 194:  6 36 31 40 89 19 63 16 60 68 | 75 84 91 77 40  5 81 10 52 86 19 96 16 58 30  6 78 61 82 74 97 89 90 62 37
        Card 195: 45 54 92 67 47 65 91 98 87 29 |  5 72 15 25 88 36 73 20 91 90 83 46 87 47 10 22 69  2 62 57 28 93  3 59  1
        Card 196: 88 34 96 16 54  9 17 89 20 52 | 20 54 47 61 12 57 38 11  8 85 74 52 90 77 41 46  4 89 19 39 34 83 55  7 97
        Card 197: 38  3 57 72 97 45 66 73 56  8 | 83 68 28 64 58 66 85 15 53 65 23  3 37 87 20 17 47 63 55 69 88 70 62 92 76
        Card 198: 98 66 29 17 83  9  6 84 36 70 | 21 10 31 84 93 14 67 29 24 91 12 41 99 19  5 56 83 74  2  8 79 95 64 49 53
        Card 199: 41 93 33 26 45 65 97 39 20 95 | 82  8 30  6 34 58 49 16 29 91 64 80 50  9 74 59 19 60 69 53 61  3 83 67 35
        Card 200: 86 85 91  2 27 65 45 73 60 69 | 66 26 28  7 98 80 14 52  6 35 57 46 39  4 30 55 94 75 82 83 96 13 74  9 58
        Card 201: 30 53 41 42 10 51 37 63 46 67 | 84 74 33  5 86 32 45 83 52  1 13 43 65 49 98 91  9 11 96 66 15 62 27 44 24
        """;

    private static IEnumerable<string> InputLines => Input.SplitByLine();
}
