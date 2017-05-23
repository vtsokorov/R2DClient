using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

#region
/// <summary>
/// WRITTEN BY TSOKOROV V.V. 22/02/2016
/// </summary>
#endregion

namespace R2DClient
{
    class SettingsIni
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        // Запись данных в ini файл
        // [Название секции] (Section) ключ (Key) = значение (Value)
        public static void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, Directory.GetCurrentDirectory() + "\\settings.ini");
        }
        // Чтение данных с ini  файла
        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder buffer = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", buffer, 255, Directory.GetCurrentDirectory() + "\\settings.ini");
            return buffer.ToString();
        }
    }
}
