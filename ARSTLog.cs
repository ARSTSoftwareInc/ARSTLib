using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ARSTLog
{
    internal class ARSTLogAPI
    {
        string _logPath = "";
        StringBuilder log = new StringBuilder();

        public void init(string logPath)
        {
            try
            {
                if (logPath == "") throw new Exception("Путь к лог файлу должен быть не пуст");
                _logPath = logPath;
            }
            catch (Exception ex)
            {
                throw new Exception("ARSTLog api error trace::init(): " + ex.ToString());
            }
        }

        public void saveLog()
        {
            try
            {
                File.WriteAllText(_logPath, log.ToString());
            }
            catch(Exception ex)
            {
                throw new Exception("ARSTLog api error trace::sveLog(): " + ex.ToString());
            }
        }

        public void addToLog(string text, bool showDate = true, bool autoApplyToFile = false)
        {
            if (showDate) text = $"[{DateTime.Now.ToString()}]: " + text;
            log.Append(text + "\n");

            if (autoApplyToFile) saveLog();
        }
    }
}