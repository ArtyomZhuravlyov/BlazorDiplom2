using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace Compile
{
    public class CompileService
    {
        private readonly HttpClient _http;

        public List<string> CompileLog { get; set; }
        private List<MetadataReference> references { get; set; }

        public async Task Init()
        {
            if (references == null)
            {
                references = new List<MetadataReference>();

                references.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
                references.Add(MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location));
                references.Add(MetadataReference.CreateFromFile(@"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\6.0.4\System.Runtime.dll"));

                references.Add(MetadataReference.CreateFromFile(AppDomain.CurrentDomain.BaseDirectory + "//xunit.abstractions.dll"));
                references.Add(MetadataReference.CreateFromFile(AppDomain.CurrentDomain.BaseDirectory + "//xunit.assert.dll"));
                references.Add(MetadataReference.CreateFromFile(AppDomain.CurrentDomain.BaseDirectory + "//xunit.core.dll"));
                references.Add(MetadataReference.CreateFromFile(AppDomain.CurrentDomain.BaseDirectory + "//xunit.execution.dotnet.dll"));
                //var a = AppDomain.CurrentDomain.GetAssemblies();
                //foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                //{
                //    if (assembly.IsDynamic)
                //    {
                //        continue;
                //    }
                //    var name = assembly.GetName().Name + ".dll";
                //    Console.WriteLine(name);
                //    //references.Add(MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName(name)).Location));
                //    references.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
                //    references.Add(MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location));




                //    references.Add(
                //        MetadataReference.CreateFromFile(myType.Assembly.Location));
                //    //references.Add(
                //    //    MetadataReference.CreateFromStream(
                //    //        await this._http.GetStreamAsync(_uriHelper.BaseUri + "/_framework/_bin/" + name)));
                //}
            }
        }


        public async Task<Assembly> Compile(string code)
        {
            await Init();

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code, new CSharpParseOptions(LanguageVersion.Preview));
            foreach (var diagnostic in syntaxTree.GetDiagnostics())
            {
                CompileLog.Add(diagnostic.ToString());
            }

            if (syntaxTree.GetDiagnostics().Any(i => i.Severity == DiagnosticSeverity.Error))
            {
                CompileLog.Add("Parse SyntaxTree Error!");
                return null;
            }

            CompileLog.Add("Parse SyntaxTree Success");

            CSharpCompilation compilation = CSharpCompilation.Create("CompileBlazorInBlazor.Demo", new[] { syntaxTree },
                references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (MemoryStream stream = new MemoryStream())
            {
                EmitResult result = compilation.Emit(stream);

                foreach (var diagnostic in result.Diagnostics)
                {
                    CompileLog.Add(diagnostic.ToString());
                }

                if (!result.Success)
                {
                    CompileLog.Add("Compilation error");
                    return null;
                }

                CompileLog.Add("Compilation success!");

                stream.Seek(0, SeekOrigin.Begin);

                //                var context = new CollectibleAssemblyLoadContext();
                Assembly assemby = AppDomain.CurrentDomain.Load(stream.ToArray());
                return assemby;
            }

            return null;
        }


        public async Task<string> CompileAndRun(string code)
        {
            await Init();

            var assemby = await this.Compile(code);
            try
            {
                if (assemby != null)
                {
                    var type = assemby.GetExportedTypes().FirstOrDefault();
                    var methodInfo = type.GetMethod("Run");
                    var instance = Activator.CreateInstance(type);
                    methodInfo.Invoke(instance, null);
                    return "Задача решена верно";
                }
            }
            catch (Exception ex)
            {
                return $"Задача решена неверно: {ex.InnerException.Message}";
            }
            return "Ошибка";

        }
    }
}
