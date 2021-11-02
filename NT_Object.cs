using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NT_CQMsg
{
	/// <summary>
	/// 消息主体
	/// </summary>
	public class NT_Object
	{
		public string _JsonData;
		public NT_BaseAttribute _BaseAttribute;		
		//public NT_Message _Message_Data;

		public NT_Object(string _JsonData)
		{
			this._JsonData = _JsonData;
			Initializer();
		}

		public virtual void Initializer()
		{
			_BaseAttribute = JsonReader<NT_BaseAttribute>.ReadObjectFormData(_JsonData);
			_BaseAttribute.Initializer(this);
		}
	}
}