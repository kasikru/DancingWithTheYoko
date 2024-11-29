using System;
using System.Collections.Generic;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime parsedDate;
        bool isValid = DateTime.TryParse(appointmentDateDescription, out parsedDate);
        
        return parsedDate;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        if (DateTime.Compare(appointmentDate, DateTime.Now) < 0) 
            return true;

        return false;
    }   

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        if(appointmentDate.Hour >= 12 && appointmentDate.Hour < 18) 
            return true;
        
        return false;  
    }

    public static string Description(DateTime appointmentDate)
    {
        string date = DateOnly.FromDateTime(appointmentDate).ToString();
        string time = appointmentDate.TimeOfDay.ToString();
        return $"You have an appointment on {appointmentDate}.";
    }

    public static DateTime AnniversaryDate()
    {   
        int currentYear = DateTime.Now.Year;       
        return new DateTime(currentYear, 9, 15, 0, 0, 0);
    }
}
