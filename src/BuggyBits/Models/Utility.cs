using System;
using System.IO;

/// <summary>
/// Summary description for Utility
/// </summary>
public static class Utility
{
    public static void WriteToLog(string message, string fileName)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                //Log the event with date and time.
                sw.WriteLine("--------------------------");
                sw.WriteLine(DateTime.Now.ToLongTimeString());
                sw.WriteLine("-------------------");
                sw.WriteLine(message);
            }
        }
        catch (Exception ex)
        {
            ExceptionHandler.LogException(ex);
        }
    }
}
