using System;
using frontend;
using intermediate;
using backend;
using System.IO;
using message;

namespace test
{
	public class ParserMessageListener : IMessageListener 
	{
		private static readonly String PARSER_SUMMARY_FORMAT = "\n%,20d source lines." +
			"\n%,20d syntax errors." +
			"\n%,20.2f seconds total parsing time.\n";
		
		public void MessageReceived(Message message) 
		{
			MessageType type = message.Type; 
			switch (type) 
			{
				case MessageType.PARSER_SUMMARY: 
				{
					object[] body = (object[]) message.Body; 
					int statementCount = (int) body[0];
					int syntaxErrors = (int) body[1]; 
					float elapsedTime = (float) body[2];
					Console.WriteLine(PARSER_SUMMARY_FORMAT, statementCount, syntaxErrors,
						elapsedTime);
					break; 
				}
			} 
		}
	}

}

