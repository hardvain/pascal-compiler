using System;
using message;
namespace frontend
{
	public abstract class Scanner 
	{
		protected Source Source;
		private Token currentToken;

		public Scanner (Source Source)
		{
			this.Source = Source;
		}

		public Token CurrentToken()
		{
			return currentToken;
		}

		public Token NextToken()
		{
			currentToken = ExtractToken ();
			return currentToken;
		}

		public char CurrentChar()
		{
			return Source.CurrentCharacter ();
		}

		public char NextChar()
		{
			return Source.NextChar ();
		}

		protected abstract Token ExtractToken();


	}
}