using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NT_CQMsg
{
	[Serializable]
	public class NT_Message
	{
		public string type;
		public NT_Message_Item_Type_E _Type ;
		public NT_Message_Data data;

		/// <summary>
		/// 消息段基础类型
		/// </summary>
		public enum NT_Message_Item_Type_E
		{
			text,
			face,
			image,
			record,
			video,
			at,
			rps,
			dice,
			shake,
			poke,
			anonymous,
			share,
			contact,
			location,
			music,
			reply,
			forward,
			node,
			xml,
			json,
			_Null = default
		}

		public virtual void Initializer(NT_Object _NT_Object = null)
		{
			if (type != string.Empty)
			{
				_Type = Enum.IsDefined(typeof(NT_Message_Item_Type_E), type) ? (NT_Message_Item_Type_E)Enum.Parse(typeof(NT_Message_Item_Type_E), type) : NT_Message_Item_Type_E._Null;
			}

			switch (_Type)
			{
				default:
					UnityEngine.Debug.Log(_Type.ToString());
					break;
			}
		}
	}

	[Serializable]
	public class NT_Message_Data
	{
		public string text;
		public string id;
		public string file;
		public string qq;
		public string type;
		public NT_Message_DataType_E _Type;
		public string url;
		public string title;
		public string lat;
		public string lon;
		public string audio;
		public long user_id;
		public string nickname;
		public NT_Message_Data[] content;
		public string data;

		/// <summary>
		/// data数据类型
		/// </summary>
		public enum NT_Message_DataType_E
		{
			custom,
			qq,
			group,
			///戳一戳
			poke = 126,
			music = 163,
			_Null = default
		}

		public void Initializer()
		{
			try
			{
				_Type = (NT_Message_DataType_E)int.Parse(type);
			}
			catch
			{
				if (type != string.Empty)
				{
					_Type = Enum.IsDefined(typeof(NT_Message_DataType_E), type) ? (NT_Message_DataType_E)Enum.Parse(typeof(NT_Message_DataType_E), type) : NT_Message_DataType_E._Null;
				}
			}

			if (content != null)
			{
				foreach (var v in content)
				{
					v.Initializer();
				}
			}
		}
	}
}
