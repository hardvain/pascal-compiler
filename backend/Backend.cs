using System;
using message;
using intermediate;


namespace backend
{
	public abstract class Backend : IMessageProducer
	{
		protected static MessageHandler MessageHandler = new MessageHandler ();
		public Backend ()
		{
			
		}

		public abstract void Process (IntermediateCode interMediateCode, SymbolTable symbolTable);

		#region IMessageProducer implementation

		public void AddMessageListener (IMessageListener listener)
		{
			MessageHandler.AddListener (listener);
		}

		public void RemoveMessageListener (IMessageListener listener)
		{
			MessageHandler.RemoveListener (listener);

		}

		public void SendMessage (Message message)
		{
			MessageHandler.SendMessage (message);
		}

		#endregion
	}
}

