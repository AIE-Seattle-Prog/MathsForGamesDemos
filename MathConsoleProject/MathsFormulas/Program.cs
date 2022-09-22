using AIE;

using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Basic Quadratic
        float quad = MathsFormulas.BasicQuadratic(5.0f);
        Debug.Assert(quad == 28, "Invalid result for BasicQuadratic!");
        Debug.Assert(MathF.Abs(quad - 28) < 0.0001, "Invalid result for BasicQuadratic!");

        MathsFormulas.QuadraticRoots roots = MathsFormulas.GetQuadraticRoots(5, -50, 41);

        float lerped = MathsFormulas.Lerp(6, 3, 0.5f);

        float dist = MathsFormulas.Distance(-5.2f, 3.8f, 8.7f, -4.1f);
        float distB = MathsFormulas.Distance(53.2f, 41.8f, -82.7f, -14.1f);

        return;
    }
}