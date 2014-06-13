using System;
using System.Collections.Generic;

namespace Foo
{
    using System.CodeDom.Compiler;

    using Microsoft.CSharp;

    //Example of code compilation. 
    class Program
    {
        static void Main(string[] args)
        {
            // code snippet to compile:   
            string source = @"namespace Foo {

    public class Test:ITest
    {
        public void Write()
        {
            System.Console.WriteLine(""Hello World"");
        }
    }
  
}
   ";//end snippet

            // the "real" code:

            Dictionary<string, string> providerOptions = new Dictionary<string, string>
                {
                    {"CompilerVersion", "v4.0"}
                };
            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

            CompilerParameters compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };
            compilerParams.ReferencedAssemblies.Add(typeof(ITest).Assembly.Location);
            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);

            if (results.Errors.Count == 0)
            {

            }

            ITest test = results.CompiledAssembly.CreateInstance("Foo.Test") as ITest;


         
            test.Write(); // will crash here because it is "null"

            Console.ReadLine();
        }
    }

    public interface ITest
    {

        void Write();
    }
}