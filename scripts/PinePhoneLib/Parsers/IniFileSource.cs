using System;
using System.Collections.Generic;
using System.IO;

namespace PinePhoneLib.Parsers
{
    public class IniFileSource
    {
        public string Path = string.Empty;
        private Dictionary<string, string> _cache = new Dictionary<string, string>();
        
        public string GetValueOrDefault(string key, string defaultVal = null)
        {
            if(_cache.TryGetValue(key,out var val))
            return val;
            return defaultVal;
        }
        public void UpdateCache()
        {
            var lines = File.ReadAllLines(Path);

            foreach (var line in lines)
            {
                var kvp = line.Split('=', StringSplitOptions.TrimEntries);
                if (_cache.TryGetValue(kvp[0], out var val))
                    val = kvp[1];
                else
                    _cache.Add(kvp[0], kvp[1]);
            }
        }
    }
}
