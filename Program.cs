using System;

interface IEmployee
{
    // Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Methods
    public string Fullname();
    public double Pay();
}

class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee()
    {
        Id = 0;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Fullname()
    {
        return FirstName + " " + LastName;
    }

    public virtual double Pay()
    {
        double salary;
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        salary = double.Parse(Console.ReadLine());
        return salary;
    }
}

sealed class Executive : Employee
{
    public string Title { get; set; }
    public double Salary { get; set; }

    public Executive() : base()
    {
        Title = string.Empty;
        Salary = 0.0;
    }

    public Executive(int id, string firstName, string lastName, string title, double salary) : base(id, firstName, lastName)
    {
        Title = title;
        Salary = salary;
    }

    public override double Pay()
    {
        return Salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt user to input information for an employee
        Console.WriteLine("Enter Employee ID:");
        int empId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Employee First Name:");
        string empFirstName = Console.ReadLine();

        Console.WriteLine("Enter Employee Last Name:");
        string empLastName = Console.ReadLine();

        // Create an employee object with user-provided information
        Employee emp = new Employee(empId, empFirstName, empLastName);
        Console.WriteLine("\nEmployee Information:");
        Console.WriteLine($"ID: {emp.Id}");
        Console.WriteLine($"Name: {emp.Fullname()}");
        Console.WriteLine($"Weekly Salary: ${emp.Pay()}");

        // Prompt user to input information for an executive
        Console.WriteLine("\nEnter Executive ID:");
        int execId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Executive First Name:");
        string execFirstName = Console.ReadLine();

        Console.WriteLine("Enter Executive Last Name:");
        string execLastName = Console.ReadLine();

        Console.WriteLine("Enter Executive Title:");
        string title = Console.ReadLine();

        Console.WriteLine("Enter Executive Weekly Salary:");
        double salary = Convert.ToDouble(Console.ReadLine());

        // Create an executive object with user-provided information
        Executive exec = new Executive(execId, execFirstName, execLastName, title, salary);
        Console.WriteLine("\nExecutive Information:");
        Console.WriteLine($"ID: {exec.Id}");
        Console.WriteLine($"Name: {exec.Fullname()}");
        Console.WriteLine($"Title: {exec.Title}");
        Console.WriteLine($"Weekly Salary: ${exec.Pay()}");
    }
}
