using System;

namespace frontend
{
	public class FrontEndFactory
	{
		public static Parser CreateParser(String language, String type, Source source)
		{
			if (language.Equals ("pascal") && type.Equals ("top-down")) {
				Scanner scanner = new PascalScanner (source);
				return new PascalParserTD (scanner);
			} else if (!(language.Equals ("parser"))) {
				throw new Exception ("Parser factory: Invalid Language :" + language);
			} else {
				throw new Exception ("Parser factory: Invalid Type :" + type);
			}
		}
	}
}

