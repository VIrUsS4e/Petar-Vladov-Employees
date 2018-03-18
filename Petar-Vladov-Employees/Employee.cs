using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{

    public Employee(int employeeID, int projectID, DateTime dateFrom, DateTime dateTo)
    {
        this._employeeID = employeeID;
        this._projectID = projectID;
        this._dateFrom = dateFrom;
        this._dateTo = dateTo;
    }

    private int _employeeID;

    public int EmployeeID
    {
        get { return _employeeID; }
    }

    private int _projectID;

    public int ProjectID
    {
        get { return _projectID; }
    }

    private DateTime _dateFrom;

    public DateTime DateFrom
    {
        get { return _dateFrom; }
    }

    private DateTime _dateTo;

    public DateTime DateTo
    {
        get { return _dateTo; }
    }

}

