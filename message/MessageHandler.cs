using System;
using System.Collections.Generic;

namespace message
{
	public class MessageHandler
	{
		private Message message;
		private List<IMessageListener> listeners;
		public MessageHandler ()
		{
			listeners = new List<IMessageListener> ();
		}

		public void SendMessage (Message message)
		{
			this.message = message;
			listeners.ForEach (l => l.MessageReceived (message));
		}

		public void RemoveListener (IMessageListener listener)
		{
			listeners.Remove (listener);
		}


		public void AddListener (IMessageListener listener)
		{
			listeners.Add (listener);
		}
	}
}

