using System;
using System.Collections.Generic;
using System.Text;

public class DateTimeFormat
{

    public string GetDateTimeFormatFromUser()
    {
        Console.WriteLine("Please select the format for Date used in the text file by entering one of the below options ( 1 - 12 ).");
        Console.WriteLine("Please keep in mind the following: 'd' represents day, 'M' represents Month and 'y' represents year. All dates in the text file MUST BE in the same format.");
        Console.WriteLine("1. MM/dd/yyyy - US Format with '/' separator");
        Console.WriteLine("2. MM-dd-yyyy - US Format with '-' separator");
        Console.WriteLine("3. M/d/yyyy - US Format without leading zeroes");
        Console.WriteLine("4. M/d/yy - US Format without leading zeroes and a two-digit year representation");
        Console.WriteLine("5. yyyy-MM-dd - European Format with '-' separator");
        Console.WriteLine("6. yyyy/MM/dd - European Format with '/' separator");
        Console.WriteLine("7. yyyy/M/d - European Format without leading zeroes '/' separator");
        Console.WriteLine("8. yy/M/d - European Format without leading zeroes and a two-digit year representation '/' separator");
        Console.WriteLine("9. dd-MM-yyyy - Format day-month-year");
        Console.WriteLine("10. dd/MM/yyyy - Format day/month/year");
        Console.WriteLine("11. d/M/yyyy - Format day/month/year without leading zeroes");
        Console.WriteLine("12. d/M/yy - Format day/month/year without leading zeroes and with two-digit year representation");

        Console.WriteLine();
        int dateTimeFormatNumber = int.Parse(Console.ReadLine());
        string dateTimeFormat = null;
        switch (dateTimeFormatNumber)
        {
            case 1:
                dateTimeFormat = "MM/dd/yyyy";
                break;
            case 2:
                dateTimeFormat = "MM-dd-yyyy";
                break;
            case 3:
                dateTimeFormat = "M/d/yyyy";
                break;
            case 4:
                dateTimeFormat = "M/d/yy";
                break;
            case 5:
                dateTimeFormat = "yyyy-MM-dd";
                break;
            case 6:
                dateTimeFormat = "yyyy/MM/dd";
                break;
            case 7:
                dateTimeFormat = "yyyy/M/d";
                break;
            case 8:
                dateTimeFormat = "yy/M/d";
                break;
            case 9:
                dateTimeFormat = "dd-MM-yyyy";
                break;
            case 10:
                dateTimeFormat = "dd/MM/yyyy";
                break;
            case 11:
                dateTimeFormat = "d/M/yyyy";
                break;
            case 12:
                dateTimeFormat = "d/M/yy";
                break;
        }

        return dateTimeFormat;
    }
}

