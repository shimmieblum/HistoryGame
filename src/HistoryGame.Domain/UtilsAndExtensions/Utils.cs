using System;
using System.Collections.Generic;
using System.Linq;
using HistoryGame.Domain.GameMapModel.GameMapElements;

namespace HistoryGame.Domain.Utils;

public static class Utils
{
    private static readonly Random Random = new Random();

    public static double NextPercentage(double min, double max)
    {
        if (min >= max || min < 0 || min > 1 || max < 0 || max > 1)
        {
            throw new ArgumentException("min must be less than max. min & max must be between 0 & 1");
        }

        return Random.NextDouble() * (max - min) + min;
    }
    
    public static int NextRandomNumber(int min, int max) 
        => Random.Next(min, max);

    public static MapCoordinate GetRandomCoordinate(int width, int lenght)
        => new(NextRandomNumber(0, width), NextRandomNumber(0, lenght));

    public static MapCoordinate GetRandomCoordinate(int width, int length, int offset)
        => new(NextRandomNumber(offset, width - offset), NextRandomNumber(offset, length - offset));

    public static List<T> Shuffle<T>(this List<T> mapSquares) =>
        mapSquares.OrderBy(_ => NextRandomNumber(0, mapSquares.Count)).ToList();

    public static IEnumerable<T> Slice<T>(this IEnumerable<T> collection, int from, int count)
        => collection.Skip(from).Take(count);
}