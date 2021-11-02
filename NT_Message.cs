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
		public NT_Message_Type_E _Type;
		public NT_Message_Data data;

		/// <summary>
		/// 消息段基础类型
		/// </summary>
		public enum NT_Message_Type_E
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
			json
		}

		/// <summary>
		/// data数据类型
		/// </summary>
		public enum NT_Message_DataType_E
		{
			custom,
			qq,
			group,
			///戳一戳
			poke= 126,
			music = 163			
		}
	}

	[Serializable]
	public class NT_Message_Data : NT_Message
	{
	}

	[Serializable]
	public class NT_Message_Data_Text : NT_Message_Data
	{		
	}

	[Serializable]
	public class NT_Message_Data_Face : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Image : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Record : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Video : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_At : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Rps : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Dice : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Shake : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Poke : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Anonymous : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Share : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Contact : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Location : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Music : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Reply : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Forward : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Node : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Xml : NT_Message_Data
	{
	}

	[Serializable]
	public class NT_Message_Data_Json : NT_Message_Data
	{
	}
}
