using System;

namespace backend
{
	public class BackendFactory
	{
		public static Backend CreateBackend(String operation)
		{
			if (operation.Equals("compile")) {
				return new CodeGen(); 
			} else if (operation.Equals("execute")) { 
				return new Executor();
			}
			else {
				throw new Exception("Backend factory: Invalid operation &apos;" + operation + "&apos;");
			} 
		}
	}
}

