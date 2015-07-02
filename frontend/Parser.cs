using System;
using intermediate;
using message;

namespace frontend
{
	public abstract class Parser : IMessageProducer
	{
		public static SymbolTable SymbolTable = null;  
		protected static MessageHandler messageHandler = new MessageHandler();
		public IntermediateCode IntermediateCode;
		protected Scanner Scanner;

		protected Parser (Scanner Scanner)
		{
			this.Scanner = Scanner;
			this.IntermediateCode = null;
		}

		public abstract void Parse();

		public abstract int GetErrorCount();

		public Token CurrentToken()
		{
			return Scanner.CurrentToken();
		}

		public Token NextToken()
		{
			return Scanner.NextToken ();
		}

		public void AddMessageListener(IMessageListener listener) 
		{
			messageHandler.AddListener(listener); 
		}

		public void RemoveMessageListener(IMessageListener listener) 
		{
			messageHandler.RemoveListener(listener); 
		}

		public void SendMessage(Message message) 
		{
			messageHandler.SendMessage(message); 
		}
		
	}
}
