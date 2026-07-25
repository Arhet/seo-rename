using Microsoft.Win32;

namespace SeoRename;

public static class RegistryManager
{
    private const string MenuKey = @"Software\Classes\*\shell\SeoRename";
    private const string CommandKey = @"Software\Classes\*\shell\SeoRename\command";

    public static void Install(string exePath)
    {
        using RegistryKey key = Registry.CurrentUser.CreateSubKey(MenuKey)!;

        key.SetValue("", "SEO-транслитерировать");
        key.SetValue("Icon", exePath);

        using RegistryKey command = Registry.CurrentUser.CreateSubKey(CommandKey)!;

        command.SetValue("", $"\"{exePath}\" \"%1\"");
    }

    public static void Uninstall()
    {
        Registry.CurrentUser.DeleteSubKeyTree(MenuKey, false);
    }
}