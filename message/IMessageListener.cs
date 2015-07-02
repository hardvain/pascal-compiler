using System;

namespace message
{
	public interface IMessageListener
	{
		void MessageReceived(Message message);
	}

}

