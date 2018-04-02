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
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough parameters. First parameters must be the Javascript files to read, and the last one the C# output file");
                return;
            }

            List<string> inputFiles = args.ToList();
            inputFiles.RemoveAt(inputFiles.Count - 1);

            string outputFile = args.LastOrDefault();

            if (string.IsNullOrEmpty(outputFile) || outputFile.ToLowerInvariant().EndsWith(".cs") == false)
            {
                Console.WriteLine("The output file is not a .cs file");
                return;
            }

            StringBuilder sb = new StringBuilder();

            //Header
            sb.Append(@"namespace Daddoon.Blazor.Extensions
                        {
                            public class DaddoonBlazorExtensionScripts : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
                            {
                                protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
                                {
                                    builder.OpenElement(0, ""script"");
                                    builder.AddContent(1, @""");

            //Reading all files
            foreach (string path in inputFiles)
            {
                if (!File.Exists(path))
                    continue;

                sb.Append(File.ReadAllText(path).Replace("\"", "\"\"")); // Replace double quote by double double quote for verbatim
                sb.AppendLine();
            }

            sb.Append(@""");
                                        builder.CloseElement();
                                }
                            }
                        }");
            sb.AppendLine();

            File.WriteAllText(outputFile, sb.ToString());
        }
    }
}
