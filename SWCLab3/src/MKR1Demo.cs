using SWCLab3.src.LightHTML;
using SWCLab3.src.LightHTML.Interfaces;
using SWCLab3.src.LightHTML.Iterators;
using SWCLab3.src.LightHTML.States;

namespace SWCLab3.src;

public static class MKR1Demo
{
    public static void ShowAllFeatures()
    {
        Console.WriteLine("--- МКР 1: Демонстрація LightHTML ---\n");

        ShowTemplateMethod();
        ShowIterator();
        ShowState();
        // ShowCommand();
        // ShowVisitor();
    }

    public static void ShowTemplateMethod()
    {
        Console.WriteLine("[ФІЧА 1: Template Method]");

        var div = new LightElementNode("div", "block", "paired", new List<string> { "container" });
        var text = new LightTextNode("Привіт, МКР!");

        div.AddChild(text);

        Console.WriteLine("\nРезультат рендерингу (спрацює OnStylesApplied всередині OuterHTML):");
        Console.WriteLine(div.OuterHTML);
        Console.WriteLine();
    }

    public static void ShowIterator()
    {
        Console.WriteLine("[ФІЧА 2: Iterator]");

        var section = new LightElementNode("section", "block", "paired");
        var header = new LightElementNode("h2", "block", "paired");
        var p = new LightElementNode("p", "block", "paired");

        header.AddChild(new LightTextNode("Заголовок"));
        p.AddChild(new LightTextNode("Текст абзацу"));

        section.AddChild(header);
        section.AddChild(p);

        Console.WriteLine("--- Обхід у глибину (DFS) ---");
        ILightIterator dfs = new DepthFirstIterator(section);
        while (dfs.HasNext())
        {
            PrintNodeInfo(dfs.Next());
        }

        Console.WriteLine("\n--- Обхід у ширину (BFS) ---");
        ILightIterator bfs = new BreadthFirstIterator(section);
        while (bfs.HasNext())
        {
            PrintNodeInfo(bfs.Next());
        }
        Console.WriteLine();
    }

    public static void ShowState()
    {
        Console.WriteLine("[ФІЧА 3: State]");

        var div = new LightElementNode("div", "block", "paired", new List<string> { "box" });
        div.AddChild(new LightTextNode("Я видимий елемент"));

        Console.WriteLine("--- Поточний стан: Visible ---");
        Console.WriteLine(div.OuterHTML);

        Console.WriteLine("\n--- Перемикаємо стан на Hidden ---");
        div.SetState(new HiddenState());
        Console.WriteLine($"Результат (має бути порожньо): '{div.OuterHTML}'");

        Console.WriteLine("\n--- Повертаємо стан Visible ---");
        div.SetState(new VisibleState());
        Console.WriteLine(div.OuterHTML);
        Console.WriteLine();
    }

    private static void PrintNodeInfo(LightNode node)
    {
        if (node is LightElementNode el)
            Console.WriteLine($"Елемент: <{el.TagName}>");
        else if (node is LightTextNode txt)
            Console.WriteLine($"Текст: \"{txt.InnerHTML.Trim()}\"");
    }
}