using System;

namespace message
{
	public class Message
	{
		public MessageType Type { get; set;}
		public object[] Body{ get; set;}
		public Message (MessageType type, Object[] body)
		{
			this.Type = type;
			this.Body = body;
		}
	}
}

