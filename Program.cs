using System.IO;

internal class Program {
    private static void Main(string[] args) {
        Console.WriteLine("Ingresar el path");
        string? path = Console.ReadLine();
        while(path == null) {
            Console.WriteLine("\nIngresar un directorio valido");
            path = Console.ReadLine();
        }
        var directory = Directory.GetFiles(path);
        using(StreamWriter directoriesList = new StreamWriter("index.csv", true)) {
            foreach(string file in directory) {
                directoriesList.WriteLine((string)file);
            }
        }
    }
}