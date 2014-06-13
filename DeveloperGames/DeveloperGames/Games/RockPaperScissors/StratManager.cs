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
                return new Implementation1();
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
           
           Assembly assembly = CompileSource(source);
           object myStrat = assembly.CreateInstance("Implementation2") as IStrat;
           return (IStrat)myStrat;
       }

        private static Assembly CompileSource(string sourceCode)
        {
            CodeDomProvider cpd = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("mscorlib.dll");
          
            cp.GenerateExecutable = false;
            // Invoke compilation.
            CompilerResults cr = cpd.CompileAssemblyFromSource(cp, sourceCode);

            return cr.CompiledAssembly;
        }

    }
}
