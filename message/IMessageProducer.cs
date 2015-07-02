using System;

namespace message
{
	public interface IMessageProducer
	{
		void AddMessageListener(IMessageListener listener);
		void RemoveMessageListener(IMessageListener listener);
		void SendMessage(Message message);
	}
}

