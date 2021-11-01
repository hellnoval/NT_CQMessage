using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NT_CQMsg
{
	/// <summary>
	/// 消息基础数据
	/// </summary>
	[Serializable]
	public class NT_BaseAttribute
	{
		/// <summary>
		/// 事件发生的时间戳
		/// </summary>
		public int time;
		/// <summary>
		/// 收到事件的机器人 QQ 号
		/// </summary>
		public int self_id;
		/// <summary>
		/// 事件类型
		/// </summary>
		public string post_type;
		/// <summary>
		/// 事件类型(转义)
		/// </summary>
		public NT_Post_Type_E _Post_Type;

		public NT_BaseAttribute()
		{ }

		public NT_BaseAttribute(string _JsonData)
		{
			_Post_Type = Enum.IsDefined(typeof(NT_Post_Type_E), post_type) ? (NT_Post_Type_E)Enum.Parse(typeof(NT_Post_Type_E), post_type) : NT_Post_Type_E._Null;
		}

		public virtual void Initializer(string _JsonData = null)
		{
		}

	


	
		/// <summary>
		/// 群号
		/// </summary>
		public int group_id;
		/// <summary>
		/// 匿名消息发送者信息
		/// </summary>
		public NT_UID_Anonymous _Anonymous;
	

	}

	/// <summary>
	/// 消息类型
	/// </summary>
	public enum NT_Post_Type_E
	{
		/// <summary>
		/// 消息事件，包括私聊消息、群消息等
		/// </summary>
		message,
		/// <summary>
		/// 通知事件，包括群成员变动、好友变动等
		/// </summary>
		notice,
		/// <summary>
		/// 请求事件，包括加群请求、加好友请求等
		/// </summary>
		request,
		/// <summary>
		/// 元事件，包括 OneBot 生命周期、心跳等
		/// </summary>
		meta_event,
		/// <summary>
		/// 未知事件
		/// </summary>
		_Null
	}

	/// <summary>
	/// 消息子类型
	/// </summary>
	public enum NT_Sub_Type_E
	{
		friend,
		group,
		other,
		normal,
		anonymous,
		notice,
		connect,
		_Null
	}

	[Serializable]
	public class NT_BaseAttribute_Message : NT_BaseAttribute
	{
		/// <summary>
		/// 消息 ID
		/// </summary>
		public int message_id;
		/// <summary>
		/// 消息类型
		/// </summary>
		public string message_type;
		/// <summary>
		/// 消息子类型
		/// </summary>
		public string sub_type;
		/// <summary>
		/// 消息子类型(转义)
		/// </summary>
		public NT_Sub_Type_E _Subtype;
		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		public int user_id;
		/// <summary>
		/// 消息内容
		/// </summary>
		public string message;
		/// <summary>
		/// 原始消息内容
		/// </summary>
		public string raw_message;
		/// <summary>
		/// 字体
		/// </summary>
		public int font;
		public string sender;
		/// <summary>
		/// 发送人信息(转义)
		/// </summary>
		public NT_UID _Sender;
	}

	[Serializable]
	public class NT_BaseAttribute_Notice : NT_BaseAttribute
	{

	}

	[Serializable]
	public class NT_BaseAttribute_Request : NT_BaseAttribute
	{

	}

	[Serializable]
	public class NT_BaseAttribute_Metaevent : NT_BaseAttribute
	{

	}





	//[Serializable]
	//public class NT_BaseAttribute_Json : NT_BaseAttribute
	//{
	//	public string sub_type;
	//	public string anonymous;
	//	public string sender;

	//	/// <summary>
	//	/// 初始化base NT_BaseAttribute
	//	/// </summary>
	//	public void Initializer()
	//	{
	//		_Subtype = Enum.IsDefined(typeof(NT_Sub_Type_E), sub_type) ? (NT_Sub_Type_E)Enum.Parse(typeof(NT_Sub_Type_E), sub_type) : NT_Sub_Type_E._Null;
	//		_Anonymous = JsonReader<NT_UID_Anonymous>.ReadObjectFormData(anonymous);
	//		_Sender = JsonReader<NT_UID_MoreInfo>.ReadObjectFormData(anonymous);
	//	}
	//}
}