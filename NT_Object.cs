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
		public NT_Message _Message_Data;
		public NT_Object()
		{ }

		public NT_Object(string _JsonData)
		{
			this._JsonData = _JsonData;
			Initializer();
		}

		public virtual void Initializer()
		{
			#region Initializer
			_BaseAttribute = JsonReader<NT_BaseAttribute>.ReadObjectFormData(_JsonData);
			switch (_BaseAttribute._Post_Type)
			{
				case NT_Post_Type_E.message:
					((NT_BaseAttribute_Message)_BaseAttribute).Initializer(_JsonData);
					_Message_Data = JsonReader<NT_Message>.ReadObjectFormData(_BaseAttribute.message);
					break;
				case NT_Post_Type_E.notice:
					((NT_BaseAttribute_Notice)_BaseAttribute).Initializer(_JsonData);
					break;
				case NT_Post_Type_E.request:
					((NT_BaseAttribute_Request)_BaseAttribute).Initializer(_JsonData);
					break;
				case NT_Post_Type_E.meta_event:
					((NT_BaseAttribute_Metaevent)_BaseAttribute).Initializer(_JsonData);
					break;
				default:
					Console.WriteLine($"[NT_CQMsg Warring Message]Unknow message type.{_BaseAttribute.post_type}");
					return;
			}
			#endregion
		}
	}
}