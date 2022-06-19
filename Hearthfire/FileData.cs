using Hearthfire.Enities;
using Hearthfire.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Hearthfire.Logic
{
    public static class FileData
    {
        private const string DB_PATH = "./Database/";
        private const string LOGS_PATH = "./Logs/";

        public static MainSavesData LoadMainSaves()
        {
            string path =  "./Saves/main.main";
            MainSavesData data;

            if (!Directory.Exists("./Saves"))
                Directory.CreateDirectory("./Saves");

            try
            {
                using(FileStream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    data = (MainSavesData)formatter.Deserialize(fs);

                }
            }
            catch (Exception)
            {
                data = new MainSavesData
                {
                    HourWaiting = 200,
                    PersonWaiting = 100,
                    Time = 635424480000000000
                };
            }

            return data;
        }

        public static string CreateItemLog(string id, string log)
        {
            string dir = LOGS_PATH  + "Items/";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string path = dir + id + ".txt";
            string line = Supervisor.Instance.Time.DateAndTimeToString + ": " + log + Environment.NewLine;
            File.AppendAllTextAsync(path, line);

            return line;
        }

        public async static Task<IEnumerable<string>> LoadItemLog(string id)
        {
            string path = LOGS_PATH  + "Items/" + id + ".txt";

            if (!File.Exists(path)) 
                return null;

            List<string> logs = new List<string>();

            using (StreamReader reader = File.OpenText(path))
            {
                while (!reader.EndOfStream)
                {
                    string log = await reader.ReadLineAsync();
                    logs.Add(log);
                }
            }

            return logs;
        }

        public async static Task<IEnumerable<string>> LoadItemContent(string id)
        {

            string path = DB_PATH + "ItemsContent/" + id + ".txt";

            if (!File.Exists(path))
                return null;

            List<string> content = new List<string>();

            using (StreamReader reader = File.OpenText(path))
            {
                while (!reader.EndOfStream)
                {
                    string c = await reader.ReadLineAsync();
                    content.Add(c);
                }
            }

            return content;
        }

        public static void ClearLogs()
        {
            DirectoryInfo di = new DirectoryInfo(LOGS_PATH);

            if (!di.Exists)
            {
                Directory.CreateDirectory(LOGS_PATH);
                return;
            }

            foreach (FileInfo file in di.EnumerateFiles())
                file.Delete();

            foreach (DirectoryInfo dir in di.EnumerateDirectories())
                dir.Delete(true);
        }

        public static void SaveMainLogs(IEnumerable<ConsoleMessage> lines, string day, bool userLog = false)
        {
            string opt = userLog ? "/mainLogs_user_" : "/mainLogs_";
            string dir = LOGS_PATH + opt + day + ".txt";

            using (StreamWriter sw = new StreamWriter(dir))
            {
                foreach (ConsoleMessage mes in lines)
                    sw.WriteLine(mes.Date + " : " + mes.Text + "\n");
            }
        }

        public static void OpenLogFolder()
        {
            Process.Start("explorer.exe", ".\\Logs");
        }
    }
}
