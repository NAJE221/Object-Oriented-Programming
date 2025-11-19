namespace OOP;

public class Employee
{
    private decimal salary;
    public int Id{ get; }
    public string FullName { get; set; }
    public decimal Salary
    {
        get {return salary;}
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),"Зарплата не должна быть меньше 0");
            }
            salary = value;
        }
    }

    public Employee(string fullName, decimal salary)
    {
        FullName = fullName;
        Salary += salary;
        Id = IdGenerator.GenerateNewId();
    }

    public virtual decimal CalculateBonus()
    {
        return 0;
    }
    
}

public class Manager : Employee
{
    public int TeamSize { get; set; }

    public Manager(string fullName, decimal salary, int teamSize) : base(fullName, salary)
    {
        TeamSize = teamSize;
    }
    
    public override decimal CalculateBonus()
    {
        return Salary + (Salary * 0.15m);
    }
    
}

public class Developer : Employee
{
    public decimal ProjectComplexityScore { get; set; }

    public Developer(string fullname, decimal salary, int projectComplexityScore) : base(fullname, salary)
    {
        ProjectComplexityScore = projectComplexityScore;
    }

    public override decimal CalculateBonus()
    {
        return Salary + (Salary * 0.05m) + (ProjectComplexityScore * 0.01m);
    }
    
}


public class Trainee : Employee
{
    public string SchoolName {get;set;}

    public Trainee(string fullName, decimal salary, string schoolName) : base(fullName, salary)
    {
        SchoolName = schoolName;
    }

    public override decimal CalculateBonus()
    {
        return Salary;
    }
}


public static class EmployeeExtensions
{
    public static string DisplayFormalInfo(this Employee emp)
    {
        string position = emp switch
        {
            Manager => "Менеджер",
            Developer => "Программист",
            Trainee => "Стажёр",
            _ => "Сотрудник"
        };
        return $"[{position}] {emp.FullName}, ID: {emp.Id}";
    }
}


public static class DecimalExtensions
{
    public static string ToCurrencyFormat(this decimal value)
    {
        return ($"{value:N2} Р"); 
    }
}


public class PayrollProcessor
{
    public void Process(List<Employee> employees)
    {
        Console.WriteLine("\n--- Начисление бонусов ---");
        foreach (var emp in employees)
        {
            Console.WriteLine(emp.DisplayFormalInfo());
            decimal bonus = emp.CalculateBonus();
            Console.WriteLine($" Бонус + ЗП: {bonus.ToCurrencyFormat()}");
        }
    }
}



