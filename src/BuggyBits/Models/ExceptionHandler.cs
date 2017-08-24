using System;

/// <summary>
/// Summary description for ExceptionHandler
/// </summary>
public class ExceptionHandler
{
	public ExceptionHandler()
	{
	}
    public static void LogException(Exception ex)
    {
        Utility.WriteToLog(ex.Message, "c:\\log.txt");
    }
}
