namespace Business_Logic_Layer;

public static class Utilities
{
    public static string CalculateGrade(double percentage)
        => percentage switch
        {
            >= 90 => "A",
            >= 75 => "B",
            >= 65 => "C",
            >= 50 => "D",
            < 50 => "F",
            _ => "Invalid"
        };
}
