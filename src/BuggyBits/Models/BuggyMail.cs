using System;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for BuggyMail
/// </summary>
public class BuggyMail
{
    public void SendEmail(string message, string emailAddres)
    {
        try
        {
            if (IsValidEmailAddress(emailAddres))
            {
                // send an email with the message
            }
        }
        catch (Exception ex)
        {
            ExceptionHandler.LogException(ex);
            
        }
    }

    public bool IsValidEmailAddress(string emailAddress)
    {
        if(!Regex.IsMatch(emailAddress, "^([a-zA-Z0-9_]+)@([a-zA-Z0-9]+).([a-zA-Z]{2,5})$")){
            throw new System.Exception("The email entered is not a valid email address");
        }
        else
            return true;

    }
}
