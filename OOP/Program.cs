using System.ComponentModel;
namespace OOP;

class Program
{
    static void Main(string[] args)
    {
        // Вывод Бонусов
        var manager1 = new Manager("Иванов И.И.", 70000m, 5);
        var dev1 = new Developer("Петров П.П.", 50000m, 20);
        var dev2 = new Developer("Сидорова А.В.", 60000m, 10);
        var trainee1 = new Trainee("Антон Дуров", 40000m, "Лицей 145");

        Console.WriteLine("--- Созданные Объекты и ID (Статика) ---");
        Console.WriteLine($"ID Менеджера: {manager1.Id}");
        Console.WriteLine($"ID Разработчика1: {dev1.Id}");
        Console.WriteLine($"ID Разработчика2: {dev2.Id}");
        Console.WriteLine($"ID Стажёра:  {trainee1.Id}");
        // 2. Инкапсуляция: Проверка валидации (покажите, что это вызовет исключение)
        try
        {
            dev1.Salary = 5000m;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"\nВведено значение меньше нуля , либо отрицательное");
        }
        
        List<Employee> staff = new List<Employee>
        {
            manager1,
            dev1, 
            dev2,
            trainee1
        };
        
        var processor = new PayrollProcessor();
        processor.Process(staff);
        
        // 5. Демонстрация метода расширения (используется в Process)
        decimal cash = 1234567.89m;
        Console.WriteLine($"\nРасширение DecimalExtensions (демонстрация): {cash.ToCurrencyFormat()}");
    }

}