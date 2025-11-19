using System.ComponentModel;

namespace OOP;

class Program
{
    static void Main(string[] args)
    {
        
        // Вывод ЗП + БОНУСЫ
        
        // Расчёт Работодателей
        List<string> employee = new List<string>();
        employee.Add("Семён Викторович");
        employee.Add("Василий Николаевич");

        List<decimal> sallaryEmployee = new List<decimal>();
        sallaryEmployee.Add(500000m);
        sallaryEmployee.Add(550000m);

        for (int i = 0; i < employee.Count; i++)
        {
            var informationEmployee = new Employee(employee[i], sallaryEmployee[i]);
            Console.WriteLine(informationEmployee.DisplayFormalInfo() + informationEmployee.GetInfo());
        }

        // Расчёт Менеджеров;
        List<string> manager = new List<string>();
        manager.Add("Василий Петрович");
        manager.Add("Антон Павлович");
        manager.Add("Салим Романович");

        List<decimal> sallaryManager = new List<decimal>();
        sallaryManager.Add(300000m);
        sallaryManager.Add(350000m);
        sallaryManager.Add(400000m);

        List<int> teamSize = new List<int>();
        teamSize.Add(10);
        teamSize.Add(15);
        teamSize.Add(18);

        for (int i = 0; i < teamSize.Count; i++)
        {
            var informationManager = new Manager(manager[i], sallaryManager[i], teamSize[i]);
            Console.WriteLine(informationManager.DisplayFormalInfo() + informationManager.GetInfo());
        }


        // Расчёт Програмистов 
        string positionDeveloper = "[Программист] ";
        List<string> developer = new List<string>();
        developer.Add("Фёдор Николаевич");
        developer.Add("Данил Владимирович");
        developer.Add("Роман Петрович");
        developer.Add("Владислав Тимурович");

        List<decimal> sallaryDeveloper = new List<decimal>();
        sallaryDeveloper.Add(150000m);
        sallaryDeveloper.Add(180000m);
        sallaryDeveloper.Add(200000m);
        sallaryDeveloper.Add(250000m);

        List<int> projectComplexityScore = new List<int>();
        projectComplexityScore.Add(10);
        projectComplexityScore.Add(10);
        projectComplexityScore.Add(10);
        projectComplexityScore.Add(10);

        for (int i = 0; i < developer.Count; i++)
        {
            var informationDeveloper = new Developer(developer[i], sallaryDeveloper[i], projectComplexityScore[i]);
            Console.WriteLine(informationDeveloper.DisplayFormalInfo() + informationDeveloper.GetInfo());
        }

        // Расчёт стажёра

        List<string> trainee = new List<string>();
        trainee.Add("Матвей Семёнович");
        trainee.Add("Олег Петрович");

        List<string> schoolName = new List<string>();
        schoolName.Add("Гимназия 183");
        schoolName.Add("Лицей 174");

        List<decimal> sallaryTrainee = new List<decimal>();
        sallaryTrainee.Add(60000m);
        sallaryTrainee.Add(65000m);

        for (int i = 0; i < sallaryTrainee.Count; i++)
        {
            var informationTrainee = new Trainee(trainee[i], sallaryTrainee[i], schoolName[i]);
            Console.WriteLine(informationTrainee.DisplayFormalInfo() + informationTrainee.GetInfo());
        }

        
        // Вывод Бонусов
        var manager1 = new Manager("Иванов И.И.", 70000m, 5);
        var dev1 = new Developer("Петров П.П.", 50000m, 20);
        var dev2 = new Developer("Сидорова А.В.", 60000m, 10);

        Console.WriteLine("--- Созданные Объекты и ID (Статика) ---");
        Console.WriteLine($"ID менеджера: {manager1.Id}");
        Console.WriteLine($"ID разработчика 2: {dev2.Id}");

        // 2. Инкапсуляция: Проверка валидации (покажите, что это вызовет исключение)
        try
        {
            dev1.Salary = -5000m;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"\n[Ошибка Инкапсуляции]: {ex.Message}");
        }


        // 3. Полиморфизм: Создание списка базовых типов
        List<Employee> staff = new List<Employee>
        {
            manager1, // Manager представлен как Employee
            dev1, // Developer представлен как Employee
            dev2
        };


        // 4. Запуск полиморфического процесса
        PayrollProcessor processor = new PayrollProcessor();
        processor.Process(staff);


        // 5. Демонстрация метода расширения (используется в Process)
        decimal cash = 1234567.89m;
        Console.WriteLine($"\nРасширение DecimalExtensions (демонстрация): {cash.ToCurrencyFormat()}");
    }

}