using System;
using intermediate;
using message;

namespace backend
{
	public class Executor : Backend
	{
		public Executor ()
		{
		}

		#region implemented abstract members of Backend

		public override void Process (IntermediateCode interMediateCode, SymbolTable symbolTable)
		{
			int instructionCount = 0;
			SendMessage (new Message(MessageType.INTERPRETER_SUMMARY,new object[]{instructionCount}));
		}

		#endregion
	}
}

