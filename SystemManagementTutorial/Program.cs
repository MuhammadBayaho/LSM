using System;
using System.Diagnostics;

namespace SystemManagementTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("System Management Tutorial\n");
            Console.WriteLine($"Machine Name: {Environment.MachineName}");
            Console.WriteLine($"OS Version: {Environment.OSVersion}");
            Console.WriteLine("\nRunning processes:\n");

            foreach (var process in Process.GetProcesses())
            {
                Console.WriteLine($"{process.Id}: {process.ProcessName}");
            }
        }
    }
}
