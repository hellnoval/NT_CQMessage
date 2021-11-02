using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NT_CQMsg
{
	[Serializable]
	public class NT_UID
	{
		public long user_id;
		public string nickname;
		public string sex;
		public int age;
		public string card;
		public string area;
		public string level;
		public string role;
		public string title;
	}

	[Serializable]
	public class NT_Anonymous 
	{
		public long id;
		public string name;
		public string flag;
	}
}