using System;

namespace frontend
{
	public class PascalScanner : Scanner
	{
		private Source source;

		public PascalScanner (Source source) : base(source)
		{
			this.source = source;
		}

		#region implemented abstract members of Scanner

		protected override Token ExtractToken ()
		{
			Token token;
			char currentChar = CurrentChar();
			// Construct the next token. The current character determines the // token type.
			if (currentChar == Source.EOF) {
				token = new EofToken(source); }
			else {
				token = new Token(source);
			}
			return token;
		}

		#endregion
	}
}

