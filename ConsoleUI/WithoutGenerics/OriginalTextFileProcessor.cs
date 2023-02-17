using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleUI.Models;

namespace ConsoleUI.WithoutGenerics {
    internal class OriginalTextFileProcessor {

        public static List<LogEntry> LoadLogs(string filePath) {
            List<LogEntry> output = new List<LogEntry>();
            LogEntry l;
            var lines = File.ReadAllLines(filePath).ToList();

            // Remove header row
            lines.RemoveAt(0);

            foreach (var line in lines) {
                var vals = line.Split(',');
                l = new LogEntry();

                l.ErrorCode = int.Parse(vals[0]);
                l.Message = vals[1];
                l.TimeOfEvent = DateTime.Parse(vals[2]);

                output.Add(l);
            }
            return output;
        }

        public static void SaveLogs(List<LogEntry> logs, string filePath) {
            List<string> lines = new List<string>();

            // Add a header row
            lines.Add("ErrorCode,Time Of Event,Message");

            foreach (var l in logs) {
                lines.Add($"{l.ErrorCode}, {l.Message}, {l.TimeOfEvent}");
            }

            File.WriteAllLines(filePath, lines);

        }

        public static List<Person> LoadPeople(string filePath) {
            List<Person> output = new List<Person>();
            Person p;
            var lines = File.ReadAllLines(filePath).ToList();

            // Remove header row
            lines.RemoveAt(0);

            foreach(var line in lines) {
                var vals = line.Split(',');
                p = new Person();

                p.FirstName = vals[0];
                p.LastName = vals[1];
                p.IsAlive = bool.Parse(vals[2]);

                output.Add(p);
            }
            return output;
        }

        public static void SavePeople(List<Person> people, string filePath) {
            List<string> lines = new List<string>();

            // Add a header row
            lines.Add("FirstName,IsAlive,LastName");

            foreach(var p in people) {
                lines.Add($"{p.FirstName}, {p.IsAlive}, {p.LastName}");
            }

            File.WriteAllLines(filePath, lines);
            
        }
    }
}
