using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Security.Principal;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

#region
/// <summary>
/// WRITTEN BY TSOKOROV V.V. 22/02/2016
/// </summary>
#endregion

namespace R2DClient
{
    public static class Helper
    {
        public static bool IsIP4Address(string Host)
        {
            if (Host.Split('.').Length != 4 || Host.Length > 23 || Host.ToLower().IndexOf(".com") > 1)
                return false;
            if (Host.Length > 15) return false;
            IPAddress IP;
            return IPAddress.TryParse(Host, out IP);
        }

        public static string GetIP(string Host)
        {
            try
            {
                IPHostEntry IPE = Dns.GetHostEntry(Host);
                foreach (IPAddress IP in IPE.AddressList)
                {
                    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) return IP.ToString();
                }
            }
            catch { ;}
            return "";
        }

        public static string XorString(string Value, int Shift, bool Outbound)
        {
            if (Outbound)
                Value = Value.Replace(" ", "#SS#");
            string Output = "";
            int Ch = 0;
            for (int f = 0; f <= Value.Length - 1; f++)
            {
                Ch = Convert.ToInt32(Value[f]);
                if (Outbound && Ch == 113)
                    Ch = Convert.ToInt32('¬');
                else if (!Outbound && Ch == 172)
                    Ch = 113;
                else
                    Ch ^= Shift;
                Output += char.ConvertFromUtf32(Ch);
            }
            if (!Outbound)
                return Output.Replace("#SS#", " ");
            else
                return Output;
        }

        private static bool isExistFile(string file)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + file))
                return true;
            else
            {
                MessageBox.Show("Файл "+file+" не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public static bool IsUserAdministrator()
        {
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception)
            {

            }
            return false;
        }

        public static void runProcess(string path, string argument)
        {
            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = argument;
            process.Start();
        }
    }
}
