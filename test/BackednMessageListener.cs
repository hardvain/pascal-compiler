using System;
using frontend;
using intermediate;
using backend;
using System.IO;
using message;

namespace test
{
	public class BackendMessageListener : IMessageListener {

		private static readonly String INTERPRETER_SUMMARY_FORMAT = "\n%,20d statements executed." +
			"\n%,20d runtime errors." +
			"\n%,20.2f seconds total execution time.\n";
		private static readonly String COMPILER_SUMMARY_FORMAT = "\n%,20d instructions generated." +
			"\n%,20.2f seconds total code generation time.\n";

		public void MessageReceived(Message message) 
		{
			MessageType type = message.Type; 
			switch (type) 
			{
				case MessageType.INTERPRETER_SUMMARY: 
				{
					object[] body = (object[]) message.Body; 
					int executionCount = (int) body[0];
					int runtimeErrors = (int) body[1];
					float elapsedTime = (float) body[2];
					Console.WriteLine(INTERPRETER_SUMMARY_FORMAT, executionCount, runtimeErrors,
						elapsedTime);
					break; 
				}
				case MessageType.COMPILER_SUMMARY: 
				{
					object[] body = (object[]) message.Body;
					int instructionCount = (int) body[0];
					float elapsedTime = (float) body[1];
					Console.WriteLine(COMPILER_SUMMARY_FORMAT, instructionCount, elapsedTime);
					break; 
				}
			} 
		}
	}

}

