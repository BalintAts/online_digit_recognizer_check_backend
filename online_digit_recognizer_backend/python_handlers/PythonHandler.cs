using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace online_digit_recognizer_backend.python_handlers
{
    public static class PythonHandler
    {
        public static string GetDigitFromPyScript(string dataString)
        {
            ProcessStartInfo runPyScript = new ProcessStartInfo();
            //python interprater location
            runPyScript.FileName = @"C:\anaconda\python.exe";
            //argument with file name and input parameters
            string argus = string.Format("{0} {1}", @"C:\Users\Áts Bálint\source\repos\python_ai_test\python_ai_test\py_test.py", "I am an argument");
            runPyScript.Arguments = argus;
            runPyScript.UseShellExecute = false;
            runPyScript.CreateNoWindow = true;
            runPyScript.RedirectStandardOutput = true;
            runPyScript.RedirectStandardError = true;
            runPyScript.LoadUserProfile = true;
            string pathToMyExe = @"C:\anaconda";
            runPyScript.WorkingDirectory = Path.GetDirectoryName(pathToMyExe);
            string digit;
            using (System.Diagnostics.Process process = Process.Start(runPyScript))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    process.WaitForExit();
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    digit = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    //Console.WriteLine("output= " + output);
                }
            }
            return digit;
        }
    }
}
