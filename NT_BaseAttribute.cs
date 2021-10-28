using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NT_CQMsg
{
	/// <summary>
	/// 消息基础属性
	/// </summary>
	public class NT_BaseAttribute
	{
		public NT_QMSG_Type_E _Type;
		public string _ID_Message;
		public string _Message_Seq;
		public NT_UID _Sender;
		public string _Time;
		public NT_BaseAttribute()
		{

		}
	}

	/// <summary>
	/// 消息类型
	/// </summary>
	public enum NT_QMSG_Type_E
	{
		_Null,
		_String,
		_Face,
		_Image,
		_Video,
		_At,
		_Rps,
		_Dice,
		_Shake,
		_Poke,
		_Anonymous,
		_Share,
		_Contact,
		_Location,
		_Music,
		_Reply,
		_Forward,
		_Node,
		_Xml,
		_Json
	}
}