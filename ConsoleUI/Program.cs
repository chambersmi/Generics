/*
 * Tutorial taken from Tim Corey: https://www.youtube.com/watch?v=l6s7AvZx5j8
*/
using ConsoleUI.Models;
using ConsoleUI.WithGenerics;
using System;
using System.Collections.Generic;

namespace ConsoleUI {
    internal class Program {
        static void Main(string[] args) {
            Console.ReadLine();
            DemonstrateTextFileStorage();
            Console.WriteLine("Press enter to shutdown");
            Console.ReadLine();
        }

        private static void DemonstrateTextFileStorage() {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();
            string peopleFile = @"C:\temp\people2.csv";
            string logFile = @"C:\temp\logs.csv";

            PopulateLists(people, logs);

            /*** DRY / SOLID PRINCIPLES ***/
            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);
            foreach (var p in newPeople) {
                Console.WriteLine($"{p.FirstName} {p.LastName} (isAlive = {p.IsAlive})");
            }

            var newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);
            foreach (var l in newLogs) {
                Console.WriteLine($"{l.ErrorCode} {l.Message} at {l.TimeOfEvent}");
            }

            /*** BAD WAY OF DOING THIS ***/
            //OriginalTextFileProcessor.SavePeople(people, peopleFile);
            //var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);
            //foreach (var p in newPeople) {
            //    Console.WriteLine($"{p.FirstName} {p.LastName} (isAlive = {p.IsAlive})");
            //}
            //OriginalTextFileProcessor.SaveLogs(logs, logFile);
            //var newLogs = OriginalTextFileProcessor.LoadLogs(logFile);
            //foreach(var log in newLogs) {
            //    Console.WriteLine($"{ log.ErrorCode}: { log.Message} At {log.TimeOfEvent}");
            //}
        }

        private static void PopulateLists(List<Person> people, List<LogEntry> logs) {
            people.Add(new Person { FirstName = "Mike", IsAlive = true, LastName = "Chambers" });
            logs.Add(new LogEntry { ErrorCode = 200, Message = "OK" });
        }


    }
}
