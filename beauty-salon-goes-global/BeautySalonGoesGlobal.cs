using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static bool isWindows = OperatingSystem.IsWindows();
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();


    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        TimeZoneInfo locationTZInfo = GetTimeZoneInfo(location);
        DateTime time = DateTime.Parse(appointmentDateDescription);
        return TimeZoneInfo.ConvertTimeToUtc(time, locationTZInfo);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel)
        {
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddMinutes(-105);
            case AlertLevel.Late:
                return appointment.AddMinutes(-30);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZoneInfo = GetTimeZoneInfo(location);
        return timeZoneInfo.IsDaylightSavingTime(dt) != timeZoneInfo.IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var cultureInfo = GetLocationCultureInfo(location);
        bool success = DateTime.TryParse(dtStr, cultureInfo, DateTimeStyles.None, out var dateTime);
        return success ? dateTime : new DateTime(1, 1, 1, 0, 0, 0);
    }


    private static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        var timeZoneID = GetTimeZoneID(location);
        return TimeZoneInfo.FindSystemTimeZoneById(timeZoneID);
    }
    private static string GetTimeZoneID(Location location) => location switch
    {
        Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
        Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
        Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
        _ => throw new ArgumentOutOfRangeException(),
    };

    private static CultureInfo GetLocationCultureInfo(Location location)
    {
        var culture = location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => throw new ArgumentOutOfRangeException(),
        };
        return CultureInfo.GetCultureInfo(culture);
    }

}
