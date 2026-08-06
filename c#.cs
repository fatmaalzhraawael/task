using System;
using System.Numerics;
enum DayEnum
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}
class program
{
    public static void Main()

    {

       Console.Clear();
       Console.WriteLine(GetDayName(DayEnum.Wednesday));
       Console.ReadLine();

    }
     public static string GetDayName(DayEnum day)
    {
        string dayName;
        switch(day)
        {
            case DayEnum.Sunday:
                dayName = "Sunday";
                break;
            
            case DayEnum.Monday:
                dayName = "Monday";
                break;

            case DayEnum.Tuesday:
                dayName = "Tuesday";
                break;
            
            case DayEnum.Wednesday:
                dayName = "Wednesday";
                break;

            case DayEnum.Thursday:
                dayName = "Thursday";
                break;
            
            case DayEnum.Friday:
                dayName = "Friday";
                break;
            
            case DayEnum.Saturday:
                dayName = "Saturday";
                break;
            
            default:
                dayName = "Unknown day";
                break;

        }
        return dayName;
    }

}

