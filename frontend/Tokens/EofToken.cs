using System;

namespace frontend
{
	public class EofToken : Token
	{
		public EofToken (Source source) : base(source)
		{
		}

		protected new void Extract()
		{
			
		}
	}
}

