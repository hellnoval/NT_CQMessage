using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NT_CQMsg
{
	public  class NT_Message
	{
		//public NT_Message_Block _NT_Message_Block;
		public string _Json_MessageData;

		public NT_Message(string _JsonData)
		{
			_Json_MessageData = _JsonData;

		}
	}
}
