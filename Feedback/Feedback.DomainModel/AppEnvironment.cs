using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Feedback.DomainModel
{
    public static class AppEnvironment
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static string GetConnectionString(string prefix, string key)
        {      
            return Configuration.GetConnectionString(key);
        }
    }
}
