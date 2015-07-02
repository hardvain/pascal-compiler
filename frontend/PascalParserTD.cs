using System;
using message;
namespace frontend
{
	public class PascalParserTD : Parser
	{
		public PascalParserTD (Scanner scanner) : base(scanner)
		{
		}

		#region implemented abstract members of Parser

		public override void Parse ()
		{
			Token token;

			while (!((token = NextToken ()) is EofToken)) {
			}

			SendMessage (new Message(MessageType.PARSER_SUMMARY, new object[]{ token.LineNumber, GetErrorCount () }));
		}

		public override int GetErrorCount ()
		{
			return 0;
		}

		#endregion
	}
}

