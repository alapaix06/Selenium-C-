using System.IO;

namespace Selenium_CSharp.Extent.Utility;

/// <summary>
/// Class that stores methods, functions, string, int that serve as utilities.
/// </summary>
public sealed class Utility
{
    /// <summary>
    /// Method to obtain in string format a direct path of the project
    /// </summary>
    /// <returns>The project path</returns>
    public static string GetProjectDirectory()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        return currentDirectory.Split("bin")[0];
    }
}