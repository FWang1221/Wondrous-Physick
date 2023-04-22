using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easySoulsAI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ArrayList generateCommands = new ArrayList();

                using (StreamReader sr2 = new StreamReader("easySoulsMaker\\easySoulsKVPs.csv"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    bool readHeader = false;
                    while ((line = sr2.ReadLine()) != null)
                    {
                        if (readHeader)
                        {
                            List<String> behaviorAddArgs = new List<String>();
                            behaviorAddArgs = line.Split(',').ToList();
                            generateCommands.Add("EnemyCells:addBehaviorPair(" + behaviorAddArgs[1] + ", " + behaviorAddArgs[2] + ", " + behaviorAddArgs[3] + ", " + behaviorAddArgs[0] + ")");
                        }
                        else {
                            readHeader = true;
                        }
                    }
                }

                var hksAllLines = File.ReadAllLines("action\\script\\c9997.hks");
                bool shouldStopCopy = false;
                using (var output = new StreamWriter("action\\script\\c9997.hks"))
                {
                    foreach (var line in hksAllLines)
                    {
                        if (line == "--REPLACE START EASYSOULSAI")
                        {
                            shouldStopCopy = true;
                            output.WriteLine("--REPLACE START EASYSOULSAI");
                            foreach (var command in generateCommands) {
                                output.WriteLine(command);
                                Console.WriteLine("Command: " + command + " has been added.");
                            }
                        }
                        else if (line == "--REPLACE STOP EASYSOULSAI")
                        {
                            shouldStopCopy = false;
                        }

                        if (shouldStopCopy) {
                            continue;
                        }

                        output.WriteLine(line);
                    }
                }
                Console.WriteLine("Your AIs have been updated.");
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("ENTER to close.");
            String a = Console.ReadLine();
        }
    }
}
