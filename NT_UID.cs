using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NT_CQMsg
{
	public class NT_UID
	{
		public string _QUID;
		public string _NickName;

		public string _Title;
		public NT_Sex_E _Sex;
		public NT_QUID_Type_E _Type;
	}

	public class NT_UID_Json : NT_UID
	{
		public string age;
		public string area;
		public string card;
		public string level;
		public string nickname;
		public string role;
		public string sex;
		public string title;
		public string user_id;

		public NT_UID_Json()
		{
			_QUID = user_id;
			_NickName = nickname;
		}
	}

	public enum NT_Sex_E
	{
		_Null,
		_Man,
		_Women,
		//Json
		unknown = 11
	}

	public enum NT_QUID_Type_E
	{
		_Null,
		_Prive,
		_Group,
		_System
	}
}
