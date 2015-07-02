using System;
using System.IO;
using message;
namespace frontend
{
	public class Source : IMessageProducer
	{
		public static readonly char EOL = '\n';
		public static readonly char EOF = (char) 0;
		protected MessageHandler messageHandler = new MessageHandler();

		private StreamReader StreamReader; 
		private string Line;
		public int LineNumber;
		public int CurrentPosition;

		public Source (StreamReader StreamReader)
		{
			this.LineNumber = 0;
			this.CurrentPosition = -2;
			this.StreamReader = StreamReader;
		}

		public char CurrentCharacter()
		{
			if (CurrentPosition == -2) {
				ReadLine ();
				return NextChar ();
			} else if (Line == null) {
				return EOF;
			} else if (CurrentPosition > Line.Length) {
				ReadLine ();
				return NextChar ();
			} else {
				return Line [CurrentPosition];
			}
		}

		private void ReadLine()
		{
			Line = StreamReader.ReadLine ();
			CurrentPosition = -1;
			if (Line != null){
				++LineNumber;
				SendMessage (new Message (MessageType.SOURCE_LINE, new object[]{LineNumber, Line}));
			}
		}

		public char NextChar()
		{
			++CurrentPosition;
			return CurrentCharacter ();
		}

		public char PeekChar()
		{
			CurrentCharacter ();
			if (Line == null) {
				return EOF;
			}

			int nextPosition = CurrentPosition + 1;
			return nextPosition < Line.Length ? Line [nextPosition] : EOL;
		}

		public void close()
		{
			if (StreamReader != null) {
				try{
					StreamReader.Close();
				} 
				catch(IOException e){
					Console.WriteLine (e.StackTrace);
					throw e;
				}
			}
		}

		#region IMessageProducer implementation
		public void AddMessageListener (IMessageListener listener)
		{
			messageHandler.AddListener (listener);
		}
		public void RemoveMessageListener (IMessageListener listener)
		{
			messageHandler.RemoveListener (listener);

		}
		public void SendMessage (Message message)
		{

			messageHandler.SendMessage (message);
		}
		#endregion
	}
}

