namespace SeoRename;

public static class FileRenamer
{
    public static bool Rename(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден");
            return false;
        }

        string folder = Path.GetDirectoryName(path)!;

        string oldName = Path.GetFileName(path);

        string newName = Transliterator.SeoName(oldName);

        newName = NameGenerator.GetFreeFileName(folder, newName);

        string newPath = Path.Combine(folder, newName);

        File.Move(path, newPath);

        Console.WriteLine($"{oldName}");
        Console.WriteLine("↓");
        Console.WriteLine($"{newName}");

        return true;
    }
}