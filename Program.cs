using System;
using System.IO;
using System.Text;

namespace CscCars
{
    class Program
    {  

        static void Main(string[] args)
        {
            LogWriter logger = InitLogger();



            CarPool pool = new CarPool();
            pool.Name = "Volkswagen";

            Coupe item = new Coupe()
            {
                Model = "Bentley"
            };

            // catch all exceptions, which can happen, by using catch (Exception ex)
            try
            {
                pool.Cars.Add(item);
            }
            catch (Exception ex)
            {
                // When you catch Exceptions, always do these two things: 
                //      1) Notify the user that something has happened, but hide the technical details
                //      2) Write into a log (console output, log file, log table in a database ... ) and add technical information here
                //         in a way, that you can find the Error, just by reading the Log 
                //         (insert exception message, stack trace, etc - whatever is useful, to track down the exception source)

                // (1) notify User
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("An Error occured!");
                Console.WriteLine("Please check the Logs for more information");

                // (2) write Log
                // TODO: Research about StringBuilder Class
                string timeStamp = $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToLongTimeString()}";
                StringBuilder errorBuilder = new StringBuilder();
                errorBuilder.Append(timeStamp);
                errorBuilder.Append(" | ");
                errorBuilder.Append(ex.Message);
                errorBuilder.Append(" | ");
                errorBuilder.Append(ex.Source);
                errorBuilder.Append(" | ");
                errorBuilder.Append(ex.StackTrace);
                errorBuilder.Append(Environment.NewLine); // Alternative: "\n"  
                // Best Practise: use Environment.NewLine, in order to understand right away whats happening here, without digging into the code
                // Environment.NewLine also takes care about Unix and non-Unix Systems --> hover with the mouse above "NewLine" and read the Tooltip

                logger.WriteToFile(errorBuilder.ToString());
            }
            finally
            {
                // Clean up: reset console color
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ReadLine();
        }

        private static LogWriter InitLogger()
        {
            // TODO: Research about String.Format() Method
            // TODO: Research about Interpolated Strings
            // TODO: Research about DateTime.Now() Method
            string logPath = $"{AppDomain.CurrentDomain.BaseDirectory}//LOGS//";
            string logFile = $"{logPath}\\{DateTime.Now:yyyy_MM_dd}.Log.txt";

            // TODO: Research about Directory Class         https://docs.microsoft.com/en-us/dotnet/api/system.io.directory?view=netcore-3.1
            // TODO: Research about File Class
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            return new LogWriter(logPath, logFile);
        }
    }
}
