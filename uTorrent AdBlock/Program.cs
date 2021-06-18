using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uTorrent_AdBlock
{
    static class Program
    {
        static string local = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options";

        private static void Bloquear()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(local, true);

                key.CreateSubKey("bittorrentie.exe");
                key.CreateSubKey("utorrentie.exe");
                key.Close();

                key = Registry.LocalMachine.OpenSubKey(local + "\\bittorrentie.exe", true);
                key.SetValue("Debugger", "C:\\", RegistryValueKind.String);
                key.Close();

                key = Registry.LocalMachine.OpenSubKey(local + "\\utorrentie.exe", true);
                key.SetValue("Debugger", "C:\\", RegistryValueKind.String);
                key.Close();

                MessageBox.Show("Sucesso, os anúncios serão bloqueados após a reinicialização do torrent.\r\n\r\n" +
                    "Código fonte do programa: https://github.com/elDimasX/Torrent-AdBlocker", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Environment.Exit(0);
        }

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bloquear();
        }
    }
}
