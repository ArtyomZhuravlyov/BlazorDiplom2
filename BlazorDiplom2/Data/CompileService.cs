using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace BlazorDiplom2.Data
{
    public class CompileService
    {


        public List<string> CompileLog { get; set; }

        private List<MetadataReference> _references;

        public void Init()
        {
            if (_references == null)
            {
                _references = new List<MetadataReference>();

                string[] libs = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\wwwroot\\Libs\\");

                foreach (var lib in libs)
                    _references.Add(MetadataReference.CreateFromFile(lib));
            }
        }


        public async Task<(string, bool)> CompileAndRun(string code)
        {
            //await InitAsync();

            var assembly = await this.Compile(code);
            try
            {
                if (assembly != null)
                {
                    Dictionary<MethodInfo, Type> dict = new();
                    foreach (var type in assembly.GetExportedTypes())
                    {
                        var methodInfo = type.GetMethod("Run");
                        if (methodInfo != null)
                        {
                            dict.Add(methodInfo, type);
                            if (dict.Count > 1)
                                return ("Найдено больше одной точки входа", false);
                        }

                    }

                    if (dict.Count == 0)
                        return ("Не найдена точка входа(метод Run)", false);


                    var instance = Activator.CreateInstance(dict.First().Value);
                    dict.First().Key.Invoke(instance, null);
                    return ("Задача решена верно", true);
                }
            }
            catch (Exception ex)
            {
                return ($"Задача решена неверно: {ex.InnerException?.Message}", false);
            }
            return ("Ошибка", false);

        }

        public async Task<Assembly> Compile(string code)
        {

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
                _references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

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

                //                var context = new CollectibleAssemblyLoadContext();
                Assembly assembly = AppDomain.CurrentDomain.Load(stream.ToArray());
                return assembly;
            }

        }



    }
}
