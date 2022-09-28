using System.Collections.Generic;

Console.WriteLine("Бажаєте створити команду? (так) ");
if (Console.ReadLine() == "так")
{
    Team team1 = new Team();
    Console.WriteLine("Хочете додати співробітників у команду? (так) ");
    if (Console.ReadLine() == "так")
    {
        Developer developer1 = new Developer();
        Console.WriteLine("Введіть робочий день розробника");
        developer1.WorkDay = Console.ReadLine();
        team1.AddWorker(developer1);

        Developer developer2 = new Developer();
        Console.WriteLine("Введіть робочий день розробника");
        developer2.WorkDay = Console.ReadLine();
        team1.AddWorker(developer2);

        Developer developer3 = new Developer();
        Console.WriteLine("Введіть робочий день розробника");
        developer3.WorkDay = Console.ReadLine();
        team1.AddWorker(developer3);

        Manager manager1 = new Manager();
        Console.WriteLine("Введіть робочий день менеджера");
        manager1.WorkDay = Console.ReadLine();
        team1.AddWorker(manager1);

        team1.DisplayTeamData();
        Console.WriteLine("\n");
        team1.DisplayDetailedData();
    }
}

abstract class Worker
{
    public Worker()
    {
        Console.WriteLine("Введіть ім'я працівника");
        Name = Console.ReadLine();
    }
    public string Name;
    public string Position;
    public string WorkDay;
    public void Call() { }
    public void WriteCode() { }
    public void Relax() { }
    public abstract void FillWorkDay();
}

class Developer : Worker
{
    public Developer()
    {
        Position = "Розробник";
    }
    override public void FillWorkDay() { WriteCode(); Call(); Relax(); WriteCode(); }
}

class Manager : Worker
{
    public Manager()
    {
        Position = "Менеджер";
    }
    Random r = new Random();
    override public void FillWorkDay()
    {
        int t = r.Next(1, 11);
        for (int i = 0; i < t; i++)
            Call();
        Relax();
        t = r.Next(1, 6);
        for (int i = 0; i < t; i++)
            Call();
    }
}

class Team
{
    string Name;
    public Team()
    {
        Console.WriteLine("Введіть назву своєї команди");
        Name = Console.ReadLine();
    }
    List<Worker> workers = new List<Worker>();
    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }
    public void DisplayTeamData()
    {
        Console.WriteLine(Name);
        for (int i = 0; i < workers.Count; i++)
            Console.WriteLine($"{workers[i].Name}\n");
    }
    public void DisplayDetailedData()
    {
        Console.WriteLine(Name);
        for (int i = 0; i < workers.Count; i++)
            Console.WriteLine($"{workers[i].Name} - {workers[i].Position} - {workers[i].WorkDay}\n");
    }
}