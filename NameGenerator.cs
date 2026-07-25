namespace SeoRename;

public static class NameGenerator
{
    public static string GetFreeFileName(string folder, string fileName)
    {
        string name = Path.GetFileNameWithoutExtension(fileName);
        string ext = Path.GetExtension(fileName);

        string fullPath = Path.Combine(folder, fileName);

        if (!File.Exists(fullPath))
            return fileName;

        int index = 2;

        while (true)
        {
            string candidate = $"{name}-{index}{ext}";
            fullPath = Path.Combine(folder, candidate);

            if (!File.Exists(fullPath))
                return candidate;

            index++;
        }
    }
}