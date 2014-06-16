using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DeveloperGames.Games.RockPaperScissors.TempImplementations;
using Microsoft.CSharp;

namespace DeveloperGames.Games.RockPaperScissors
{
    public class StratManager
    {
        public static IStrat LoadPlayerStrat(User user)
        {
            if (user.Id == 1)
            {
                return new Test();
            }
            else if (user.Id == 2)
            {
                return new Implementation2();
            }
            else
            {
                return LoadPlayerStratFromCode(user.StratCode);

            }
        }

        private static IStrat LoadPlayerStratFromCode(string source)
       {

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
           compilerParams.ReferencedAssemblies.Add(typeof(IStrat).Assembly.Location);
           compilerParams.ReferencedAssemblies.Add(typeof(Player).Assembly.Location);
           compilerParams.ReferencedAssemblies.Add(typeof(Move).Assembly.Location);
         

           CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);

            if (results.Errors.Count == 0)
           {

           }

           IStrat test = results.CompiledAssembly.CreateInstance("Test") as IStrat;
         
           return test;
       }

      

    }
}
