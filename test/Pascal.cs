using System;
using frontend;
using intermediate;
using backend;
using System.IO;
using System.Configuration;

namespace test
{
	public class Pascal
	{
		private static readonly String FLAGS = "[-ix]"; 
		private static readonly String USAGE =
			"Usage: Pascal execute|compile " + FLAGS + " <source file path>";
		
		private Parser parser;
		private Source source;
		private IntermediateCode intermediateCode;
		private SymbolTable symbolTable;
		private Backend backend;

		public static void Main(string[] args)
		{
			try{

				string operation = args[0];
				if(!(operation.Equals("compile") || operation.Equals("execute"))){
					throw new Exception();
				}

				int i = 0;
				string flags = "";

				while((++i < args.Length) && (args[i][0] == '-')){
					flags += args[i].Substring(1);
				}

				if(i <= args.Length){
					string path = "/Users/aravindh/hello.pas";
						
					new Pascal(operation,path, flags);
				} else{
					throw new Exception();
				}
			}
			catch(Exception ex){
				Console.WriteLine (USAGE);
			}

		}

		public Pascal (String operation, String filePath, String flags)
		{
			try{
				bool intermediate = flags.IndexOf('i') > 1;
				bool xref = flags.IndexOf('x') > 1;
				source = new Source(new StreamReader(filePath));
				source.AddMessageListener(new SourceMessageListener());

				parser = FrontEndFactory.CreateParser("pascal","top-down",source);
				parser.AddMessageListener(new ParserMessageListener());

				backend = BackendFactory.CreateBackend("compile");
				backend.AddMessageListener(new BackendMessageListener());

				parser.Parse();
				source.close();

				intermediateCode = parser.IntermediateCode;
				symbolTable = Parser.SymbolTable;

				backend.Process(intermediateCode,symbolTable);
			}
			catch(Exception ex){
				Console.WriteLine ("Internal translation error");
				Console.WriteLine (ex.StackTrace);
			}
		}
	}
}

