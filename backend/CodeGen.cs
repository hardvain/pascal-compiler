using System;
using intermediate;
using message;

namespace backend
{
	public class CodeGen : Backend
	{
		public CodeGen ()
		{
		}

		#region implemented abstract members of Backend

		public override void Process (IntermediateCode interMediateCode, SymbolTable symbolTable)
		{
			int instructionCount = 0;
			SendMessage (new Message(MessageType.COMPILER_SUMMARY,new object[]{instructionCount}));
		}

		#endregion
	}
}

