using System;

namespace frontend
{
	public class Token
	{
		protected ITokenType type;
		protected object value;
		protected Source source;
		public int LineNumber{ get; set;}
		protected int position;

		protected string Text { get; set; }

		protected char CurrentCharacter 
		{
			get{ return source.CurrentCharacter ();}
		}

		public Token (Source source)
		{
			this.source = source;
			this.LineNumber = source.LineNumber;
			this.position = source.CurrentPosition;

			Extract ();
		}

		protected void Extract()
		{
			Text = Char.ToString (CurrentCharacter);
		}

		protected char NextCharacter()
		{
			return source.NextChar();
		}

		protected char PeekChar()
		{
			return source.PeekChar ();
		}
	}
}

