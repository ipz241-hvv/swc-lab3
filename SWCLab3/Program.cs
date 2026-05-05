using System.Text;
using ConsoleApp.src.Utils;
using SWCLab3.src;
using SWCLab3.src.Adapter;
using SWCLab3.src.Bridge;
using SWCLab3.src.Decorator;
using SWCLab3.src.Flyweight;
using SWCLab3.src.LightHTML.Interfaces;
using SWCLab3.src.LightHTML.Iterators;
using SWCLab3.src.Proxy;
using LightElementNode = SWCLab3.src.LightHTML.LightElementNode;
using LightNode = SWCLab3.src.LightHTML.LightNode;
using LightTextNode = SWCLab3.src.LightHTML.LightTextNode;

namespace SWCLab3;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== МЕНЮ ЛАБОРАТОРНОЇ РОБОТИ №3 ===");
            Console.WriteLine("1. Завдання 1: Адаптер (Logger)");
            Console.WriteLine("2. Завдання 2: Декоратор (RPG)");
            Console.WriteLine("3. Завдання 3: Міст (Shapes)");
            Console.WriteLine("4. Завдання 4: Проксі (Reader)");
            Console.WriteLine("5. Завдання 5: Компонувальник (HTML)");
            Console.WriteLine("6. Завдання 6: Легковаговик (Книга)");
            Console.WriteLine("7. МКР 1: LightHTML (Поведінкові шаблони)");
            Console.WriteLine("0. Вихід");
            Console.Write("\nОберіть варіант: ");

            string choice = Console.ReadLine();
            
            if (choice == "0") break;

            Console.Clear();
            switch (choice)
            {
                case "1": RunAdapter(); break;
                case "2": RunDecorator(); break;
                case "3": RunBridge(); break;
                case "4": RunProxy(); break;
                case "5": RunComposite(); break;
                case "6": await RunFlyweight(); break;
                case "7": RunMKR1(); break;
                default: Console.WriteLine("Неправильний номер"); break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення...");
            Console.ReadKey();
        }
    }

    static void RunAdapter()
    {
        Console.WriteLine("--- Завдання 1: Адаптер ---");
        ILogger consoleLogger = new Logger();
        consoleLogger.Log("Інфо");
        consoleLogger.Warn("Ворнінг");
        consoleLogger.Error("Еррор");

        using (FileWriter writer = new FileWriter("log.txt"))
        {
            ILogger fileLogger = new FileLogger(writer);
            fileLogger.Log("Запис у файл через адаптер");
        }
    }

    static void RunDecorator()
    {
        Console.WriteLine("--- Завдання 2: Декоратор ---");
        IHero warrior = new Warrior();
        Console.WriteLine($"Початковий: {warrior.GetFullDescription()}");

        warrior = new Weapon(warrior);
        warrior = new Artefact(warrior);

        Console.WriteLine($"З інвентарем: {warrior.GetFullDescription()}");
    }

    static void RunBridge()
    {
        Console.WriteLine("--- Завдання 3: Міст ---");
        IRenderer vector = new VectorRenderer();
        IRenderer raster = new RasterRenderer();

        Shape circle1 = new Circle(10, 10, 50, vector);
        circle1.Draw();

        Shape circle2 = new Circle(20, 20, 30, raster);
        circle2.Draw();
    }

    static void RunProxy()
    {
        Console.WriteLine("--- Завдання 4: Проксі ---");

        File.WriteAllText("test.txt", "Hello World!\nThis is a proxy test.");
        File.WriteAllText("secret_data.txt", "Top secret content: 12345");

        ITextReader reader = new SmartTextReaderLocker(
            new SmartTextChecker(new SmartTextReader()),
            @"^secret"
        );

        Console.WriteLine("\n[ТЕСТ 1] Читання звичайного файлу:");
        char[][]? result1 = reader.ReadFile("test.txt");

        Console.WriteLine("\n[ТЕСТ 2] Читання секретного файлу:");
        char[][]? result2 = reader.ReadFile("secret_data.txt");
    }

    static void RunComposite()
    {
        Console.WriteLine("--- Завдання 5: Компонувальник ---");
        var table = new src.Composite.LightElementNode("table", "block", "paired", new List<string> { "grid" });
        var tr = new src.Composite.LightElementNode("tr", "block", "paired", null);
        var td = new src.Composite.LightElementNode("td", "inline", "paired", null);

        td.AddChild(new src.Composite.LightTextNode("Ячейка таблиці"));
        tr.AddChild(td);
        table.AddChild(tr);

        Console.WriteLine(table.OuterHTML);
    }

    static async Task RunFlyweight()
    {
        Console.WriteLine("--- Завдання 6: Легковаговик ---");
        string url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
        using var client = new HttpClient();
        string text = await client.GetStringAsync(url);
        string[] lines = text.Split('\n');  

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        long memBeforeSimple = GC.GetTotalMemory(true);

        var rootSimple = new src.Composite.LightElementNode("body", "block", "paired");
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var p = new src.Composite.LightElementNode("p", "block", "paired");
            p.AddChild(new src.Composite.LightTextNode(line));
            rootSimple.AddChild(p);
        }
        long memAfterSimple = GC.GetTotalMemory(true);
        long resSimple = memAfterSimple - memBeforeSimple;

        // --- ТЕСТ 2: З FLYWEIGHT ---
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        long memBeforeFly = GC.GetTotalMemory(true);

        var bodyFly = new LightElementNodeFlyweight("body", "block", "paired");
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var p = new LightElementNodeFlyweight("p", "block", "paired");
            p.AddChild(new src.Composite.LightTextNode(line));
            bodyFly.AddChild(p);
        }

        long memAfterFly = GC.GetTotalMemory(true);
        long resFly = memAfterFly - memBeforeFly;

        Console.WriteLine($"\nКількість елементів: {lines.Length}");
        Console.WriteLine($"Пам'ять БЕЗ Flyweight: {resSimple / 1024.0 / 1024.0:F2} MB");
        Console.WriteLine($"Пам'ять З Flyweight:  {resFly / 1024.0 / 1024.0:F2} MB");

        double savings = 100.0 - ((double)resFly / resSimple * 100.0);
        Console.WriteLine($"Економія пам'яті: {resSimple - resFly} байт (~{savings:F1}%)");
    }

    static void RunMKR1()
    {
        MKR1Demo.ShowAllFeatures();
    }
}