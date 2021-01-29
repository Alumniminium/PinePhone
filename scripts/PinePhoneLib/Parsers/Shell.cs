using System;
using System.Diagnostics;
using CliWrap;
using CliWrap.Buffered;

namespace PinePhoneLib.Parsers
{
    public class Shell
    {
        public static string GetValue(string executable,string arguments)
        {
            var cmd = Cli.Wrap(executable).WithArguments(arguments).WithValidation(CommandResultValidation.None).ExecuteBufferedAsync().Task.Result;
            Debug.WriteLine($"Command: {executable} {arguments} -> {Environment.NewLine}{cmd.StandardOutput.Trim()}");
            return cmd.StandardOutput.Trim();
        }        
        public static string FindByPattern(string cmd, string args, string pattern)
        {
            var val = GetValue(cmd, args);
            foreach (var line in val.Split(Environment.NewLine))
            {
                if (line.Contains(pattern))
                {
                    val = line;
                    break;
                }
            }
            var patternIndex = val.IndexOf(pattern);
            var found = val.Substring(patternIndex + pattern.Length, val.Length - (patternIndex + pattern.Length)).Split(' ')[0];
            return found;
        }
    }
}
