﻿using System;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.CompilerServices;

namespace CsdlToDiagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var usage = "CsdlToDiagram [-p(lant)]|[-y(uml)] <csdlfile>";

            if (args.Length != 2 || string.IsNullOrEmpty(args[0]) || string.IsNullOrEmpty(args[1]))
            {
                Console.WriteLine(usage);
                return;
            }

            var csdlFile = args[1];
            string csdl = File.ReadAllText(csdlFile);

            if (args[0].Equals("-y", StringComparison.OrdinalIgnoreCase))
            {
                var convertor = new YumlConvertor();
                convertor.EmitYumlDiagram(csdl);
                Console.WriteLine(convertor.GetText());
            }
            else if (args[0].Equals("-p", StringComparison.OrdinalIgnoreCase))
            {
                var convertor = new PlantConvertor();
                convertor.EmitPlantDiagram(csdl);
                Console.WriteLine(convertor.GetText());
            }
            else
            {
                Console.WriteLine(usage);
            }
        }

        internal class YumlConvertor : CsdlToYuml
        {
            public string GetText()
            {
                return this.GenerationEnvironment.ToString();
            }
        }
        internal class PlantConvertor : CsdlToPlant
        {
            public string GetText()
            {
                return this.GenerationEnvironment.ToString();
            }
        }
    }
}