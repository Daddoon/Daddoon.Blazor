using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daddoon.JsToCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Not enough parameters. First parameters must be the \"InsertTag\" that will be used for matching the replacement zones. Additional parameters are the Javascript files to read, and the last one the C# output file.\n");
                Console.WriteLine("Usage example: Daddoon.JsToCsharp.exe BLAZOR_ZONE ./file1.js ./file2.js ./fileOutput.cs\n");
                Console.WriteLine("Output cs file usage: ");
                Console.WriteLine(@"namepace MyNamespace
{
    public class MyClass : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, ""script"");
            #region BLAZOR_ZONE
            //JS FILES WILL BE INSERTED HERE WITH builder.AddContent(1, BEFORE FILE CONTENT
            #endregion BLAZOR_ZONE
            builder.CloseElement();
        }
    }
}");
                return;
            }

            string inserTag = args[0];

            List<string> inputFiles = args.ToList();
            inputFiles.RemoveAt(inputFiles.Count - 1);
            inputFiles.RemoveAt(0);

            string outputFile = args.LastOrDefault();

            if (string.IsNullOrEmpty(outputFile)
                || outputFile.ToLowerInvariant().EndsWith(".cs") == false
                || File.Exists(outputFile) == false)
            {
                Console.WriteLine("The output file is not a .cs file or it does not exist");
                return;
            }

            string outputFileContent = File.ReadAllText(outputFile);

            StringBuilder sb = new StringBuilder();

            //Header
            sb.Append(@"builder.AddContent(1, @""");

            //Reading all files
            foreach (string path in inputFiles)
            {
                if (!File.Exists(path))
                    continue;

                sb.Append(File.ReadAllText(path).Replace("\"", "\"\"")); // Replace double quote by double double quote for verbatim
                sb.AppendLine();
            }

            sb.Append(@""");");
            sb.AppendLine();

            string addedContent = sb.ToString();

            outputFileContent = System.Text.RegularExpressions.Regex.Replace(outputFileContent, $"#region {inserTag}.*?#endregion", $"#region {inserTag}\n#endregion", System.Text.RegularExpressions.RegexOptions.Singleline);

            outputFileContent = outputFileContent.Replace($"#region {inserTag}\n#endregion", $"#region {inserTag}\n{addedContent}\n#endregion");

            File.WriteAllText(outputFile, outputFileContent);
        }
    }
}
