using System.Windows.Forms;

namespace SeoRename;

internal class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            switch (args[0].ToLowerInvariant())
            {
                case "--install":
                    RegistryManager.Install(Environment.ProcessPath!);

                    MessageBox.Show(
                        "Контекстное меню успешно установлено.",
                        "SEO Rename",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;

                case "--uninstall":
                    RegistryManager.Uninstall();

                    MessageBox.Show(
                        "Контекстное меню удалено.",
                        "SEO Rename",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
            }
        }

        if (args.Length == 0)
        {
            MessageBox.Show(
                "Перетащите один или несколько файлов на SEO Rename\nили воспользуйтесь пунктом контекстного меню.",
                "SEO Rename",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        List<string> paths = args.ToList();

        int success = 0;

        foreach (string path in paths)
        {
            if (FileRenamer.Rename(path))
                success++;
        }

        // Показываем сообщение только при пакетном переименовании
        if (paths.Count > 1)
        {
            MessageBox.Show(
                $"Успешно переименовано: {success} из {paths.Count}",
                "SEO Rename",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}