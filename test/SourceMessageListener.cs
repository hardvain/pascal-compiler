using System;
using frontend;
using intermediate;
using backend;
using System.IO;
using message;

namespace test
{
	public class SourceMessageListener : IMessageListener
	{
		private static readonly String SOURCE_LINE_FORMAT = "%03d %s";

		#region IMessageListener implementation
		public void MessageReceived (Message message)
		{
			MessageType type = message.Type;
			object[] body = message.Body;

			switch (type) {
				case MessageType.SOURCE_LINE:{
					int lineNumber = (int) body[0]; 
					string lineText = (string) body[1];
					Console.WriteLine (String.Format(SOURCE_LINE_FORMAT, lineNumber, lineText));
					break;
				}
					
			}
		}
		#endregion
		

	}

}

