using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Paths path = new Paths();
        DateTimeFormat dateTimeForm = new DateTimeFormat();

        string file = path.GetFile();

        //Prompts the user to select the desired DateTime format:
        string dateTimeFormatString = dateTimeForm.GetDateTimeFormatFromUser();

        try
        {
            List<Employee> allEmployees = ReadEmployeeAssignments(file, dateTimeFormatString);

            List<Employee> employeesResult = new List<Employee>();
            double count = 0.0;

            for (int i = 0; i < allEmployees.Count; i++)
            {
                for (int j = i + 1; j < allEmployees.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (allEmployees[i].ProjectID == allEmployees[j].ProjectID)
                    {
                        if (allEmployees[i].DateFrom < allEmployees[j].DateTo && allEmployees[j].DateFrom < allEmployees[i].DateTo)
                        {
                            var overlappingDays = GetOverlappingDays(allEmployees[i].DateFrom, allEmployees[i].DateTo, allEmployees[j].DateFrom, allEmployees[j].DateTo);

                            if (overlappingDays > count)
                            {
                                employeesResult.Add(allEmployees[i]);
                                employeesResult.Add(allEmployees[j]);
                                count = overlappingDays;
                            }
                        }
                    }
                }
            }

            foreach (var employee in employeesResult)
            {
                Console.Write($"Employee: {employee.EmployeeID}, Working on project: {employee.ProjectID} From: {employee.DateFrom.ToString(dateTimeFormatString)} Untill: {employee.DateTo.ToString(dateTimeFormatString)}");
                Console.WriteLine();
            }
            Console.WriteLine($"Both employees worked together on the same project a total of {count} days.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("The file that was specified contains date formats different than the selected one. Please run the program again and select compatible file and date format!");
        }
    }




    private static double GetOverlappingDays(DateTime firstStart, DateTime firstEnd, DateTime secondStart, DateTime secondEnd)
    {
        DateTime maxStart = firstStart > secondStart ? firstStart : secondStart;
        DateTime minEnd = firstEnd < secondEnd ? firstEnd : secondEnd;
        TimeSpan interval = minEnd - maxStart;
        double returnValue = interval > TimeSpan.FromSeconds(0) ? interval.TotalDays : 0;
        return returnValue;
    }

    public static void WriteRed(string message)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(message);

        Console.ForegroundColor = currentColor;
    }


    public static List<Employee> ReadEmployeeAssignments(string fileName, string dateTimeFormat)
    {
        var allEmployees = new List<Employee>();

        using (var reader = new StreamReader(fileName))
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                var splitInput = line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                int employeeID = int.Parse(splitInput[0]);
                int projectID = int.Parse(splitInput[1]);

                var dateFrom = DateTime.ParseExact(splitInput[2], dateTimeFormat, CultureInfo.InvariantCulture);
                var dateTo = splitInput[3].Equals("null", StringComparison.OrdinalIgnoreCase) 
                    ? DateTime.Now.Date 
                    : DateTime.ParseExact(splitInput[3].Trim(), dateTimeFormat, CultureInfo.InvariantCulture);

                allEmployees.Add(new Employee(employeeID, projectID, dateFrom, dateTo));

                line = reader.ReadLine();
            }
        }
        return allEmployees;
    }
}

