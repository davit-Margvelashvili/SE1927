using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionApp
{
    public static class Generator
    {
        private const string get_set = "{ get; set; }";

        public static void GenerateFlatClasses(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in types)
            {
                var classString = GenerateClass(type);
                var filePath = Path.Combine(assembly.Location, @"..\..\..\..\", $"{type.Name}Dto.cs");

                File.WriteAllText(filePath, classString);
            }
        }

        private static string GenerateClass(Type type)
        {
            var sb = new StringBuilder()
                .AppendLine("using System;")
                .AppendLine("using System.Collections.Generic;")
                .AppendLine()
                .AppendLine($"namespace {type.Namespace}")
                .AppendLine("{")
                .AppendLine($"\tpublic class {type.Name}Dto")
                .AppendLine("\t{");

            foreach (var property in type.GetProperties())
            {
                sb.AppendLine($"\t\t{property.PropertyType.Name} {property.Name} {get_set}");
            }

            sb.AppendLine("\t}")
              .AppendLine("}");
            return sb.ToString();
        }
    }
}