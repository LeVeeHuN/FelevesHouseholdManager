using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesHouseholdManager
{
    public static class AppPaths
    {
        public static string DataFilePath => Path.Combine(FileSystem.AppDataDirectory, "appdata.json");
    }
}
