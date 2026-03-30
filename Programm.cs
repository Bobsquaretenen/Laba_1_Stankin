public class MainTree
{ 
    public int valueTree { get; set; }

    public void printTree()
    {
        Console.WriteLine($"Значение главного дерева: {valueTree}");
        Tree tree = new Tree(); 
        tree.printTree(); 
    } 
} 

public class Tree: MainTree
{
    public int valueTree { get; set; } 
    public void printTree()
    {
        Console.WriteLine($"Значение дерева: {valueTree}");
        TreePast tree = new TreePast();
        tree.printTree();
    }
}

public class TreePast : Tree
{
    public void printTree()
    {
        Console.WriteLine($"Значение дерева в прошлом: {valueTree}");
        TreeFuture tree = new TreeFuture();
        tree.printTree();
    }
}

public class TreeFuture : TreePast
{
    public void printTree()
    {
        Console.WriteLine($"Значение дерева в будущем: {valueTree}");
    }
}

public class TreeSecondVersion : MainTree
{
    public int valueTree { get; set; }
    public void printTree()
    {
        Console.WriteLine($"Значение дерева (вторая версия): {valueTree}");
    }
} 

class Application
{
    public static void Main(string[] args)
    {
        MainTree mainTree = new MainTree { valueTree = 10 };
        mainTree.printTree(); 
    }
}
