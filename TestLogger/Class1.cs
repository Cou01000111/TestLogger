using System;
using System.IO;

namespace TestLogger {
    public class Logger {
        public static string logPath = ".\\logs\\Zipper.txt";
        private static int outputLevel = 3;


        public Logger(string p, int ol) {
            logPath = p;
            outputLevel = ol;
        }
        public Logger(string p) {
            logPath = p;
        }

        public Logger() {

        }

        public void Base(int level, string message) {
            string logLevelStr;
            switch (level) {
                case 3:
                    logLevelStr = "DEBUG";
                    break;
                case 2:
                    logLevelStr = "INFO ";
                    break;
                case 1:
                    logLevelStr = "WARN ";
                    break;
                case 0:
                    logLevelStr = "ERROR";
                    break;
                default:
                    logLevelStr = "NONE";
                    break;
            }
            if (level <= outputLevel) {
                string logMessage = $"{DateTime.Now.ToString($"yyyy/MM/dd-HH:mm:ss")} [{logLevelStr}]:{message}\n";
                Console.WriteLine(logMessage);
                File.AppendAllText(logPath, logMessage);
            }
        }
        public void Debug(string message) {
            Base(3, message);
        }
        public void Info(string message) {
            Base(2, message);
        }
        public void Warn(string message) {
            Base(1, message);
        }
        public void Error(string message) {
            Base(0, message);
        }
    }
}
