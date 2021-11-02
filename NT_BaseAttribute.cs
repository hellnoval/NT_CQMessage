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
		public long time;
		/// <summary>
		/// 收到事件的机器人 QQ 号
		/// </summary>
		public long self_id;
		/// <summary>
		/// 事件类型
		/// </summary>
		public string post_type;
		/// <summary>
		/// 事件类型(转义)
		/// </summary>
		public NT_Post_Type_E _Post_Type;

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

		public virtual void Initializer(NT_Object _NT_Object = null)
		{
			if (post_type != string.Empty)
			{
				_Post_Type = Enum.IsDefined(typeof(NT_Post_Type_E), post_type) ? (NT_Post_Type_E)Enum.Parse(typeof(NT_Post_Type_E), post_type) : NT_Post_Type_E._Null;
			}

			switch (_Post_Type)
			{
				case NT_Post_Type_E.message:
					NT_BaseAttribute_Message _NT_BaseAttribute_Message = this as NT_BaseAttribute_Message;
					_NT_BaseAttribute_Message = JsonReader<NT_BaseAttribute_Message>.ReadObjectFormData(_NT_Object._JsonData);
					_NT_BaseAttribute_Message.Initializer(_NT_Object);
					break;
				case NT_Post_Type_E.notice:
					NT_BaseAttribute_Notice _NT_BaseAttribute_Notice = this as NT_BaseAttribute_Notice;
					_NT_BaseAttribute_Notice = JsonReader<NT_BaseAttribute_Notice>.ReadObjectFormData(_NT_Object._JsonData);
					break;
				case NT_Post_Type_E.request:
					NT_BaseAttribute_Request _NT_BaseAttribute_Request = this as NT_BaseAttribute_Request;
					_NT_BaseAttribute_Request = JsonReader<NT_BaseAttribute_Request>.ReadObjectFormData(_NT_Object._JsonData);
					break;
				case NT_Post_Type_E.meta_event:
					NT_BaseAttribute_Metaevent _NT_BaseAttribute_Metaevent = this as NT_BaseAttribute_Metaevent;
					_NT_BaseAttribute_Metaevent = JsonReader<NT_BaseAttribute_Metaevent>.ReadObjectFormData(_NT_Object._JsonData);
					break;
				default:
					Console.WriteLine("[NT_CQMsg Warring Message]Unknow message type." + post_type);
					return;
			}
		}
	}

	#region Message 消息事件
	[Serializable]
	public class NT_BaseAttribute_Message : NT_BaseAttribute
	{

		/// <summary>
		/// 消息类型
		/// </summary>
		public string message_type;
		/// <summary>
		/// 消息类型(转义)
		/// </summary>
		public NT_Message_Type_E _Message_type;
		/// <summary>
		/// 消息子类型
		/// </summary>
		public string sub_type;
		/// <summary>
		/// 消息子类型(转义)
		/// </summary>
		public NT_Sub_Type_E _Sub_type;
		/// <summary>
		/// 消息 ID
		/// </summary>
		public int message_id;
		/// <summary>
		/// 发送者 QQ 号
		/// </summary>
		public long user_id;

		/// <summary>
		/// 消息内容
		/// </summary>
		public NT_Message[] message;

		/// <summary>
		/// 原始消息内容
		/// </summary>
		public string raw_message;
		/// <summary>
		/// 字体
		/// </summary>
		public int font;
		/// <summary>
		/// 发送人信息(转义)
		/// </summary>
		public NT_UID sender;

		/// <summary>
		/// 消息类型
		/// </summary>
		public enum NT_Message_Type_E
		{
			_private,
			group,
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

		public override void Initializer(NT_Object _NT_Object = null)
		{
			if (sub_type != string.Empty)
			{
				_Sub_type = Enum.IsDefined(typeof(NT_Sub_Type_E), sub_type) ? (NT_Sub_Type_E)Enum.Parse(typeof(NT_Sub_Type_E), sub_type) : NT_Sub_Type_E._Null;
			}

			if (message_type != string.Empty)
			{
				switch (message_type)
				{
					case "private":
						_Message_type = NT_Message_Type_E._private;
						break;
					case "group":
						_Message_type = NT_Message_Type_E.group;
						break;
					default:
						_Message_type = NT_Message_Type_E._Null;
						break;

				}
			}

			switch (_Message_type)
			{
				case NT_Message_Type_E.group:
					NT_BaseAttribute_Message_Group _NT_BaseAttribute_Message_Group = this as NT_BaseAttribute_Message_Group;
					_NT_BaseAttribute_Message_Group = JsonReader<NT_BaseAttribute_Message_Group>.ReadObjectFormData(_NT_Object._JsonData);
					_NT_BaseAttribute_Message_Group.Initializer();
					break;
				default:
					break;					
			}
		}
	}

	/// <summary>
	/// 私聊消息
	/// </summary>
	[Serializable]
	public class NT_BaseAttribute_Message_Private : NT_BaseAttribute_Message
	{
	}

	/// <summary>
	/// 群消息
	/// </summary>
	[Serializable]
	public class NT_BaseAttribute_Message_Group : NT_BaseAttribute_Message
	{
		/// <summary>
		/// 群号
		/// </summary>
		public long group_id;
		/// <summary>
		/// 匿名信息
		/// </summary>
		public NT_Anonymous anonymous;
	}
	#endregion

	#region Notice 通知事件
	[Serializable]
	public class NT_BaseAttribute_Notice : NT_BaseAttribute
	{
		//在做了.jpg
	}
	#endregion

	#region Request 请求事件
	[Serializable]
	public class NT_BaseAttribute_Request : NT_BaseAttribute
	{
		//在做了.jpg
	}
	#endregion

	#region Metaevent 元事件
	[Serializable]
	public class NT_BaseAttribute_Metaevent : NT_BaseAttribute
	{
		public string meta_event_type;
	}
	[Serializable]
	public class NT_BaseAttribute_Metaevent_Lifecycle : NT_BaseAttribute_Metaevent
	{
		public int _post_method;
		public string sub_type;
	}

	[Serializable]
	public class NT_BaseAttribute_Metaevent_Heartbeat : NT_BaseAttribute_Metaevent
	{
		public int interval;
		public NT_Heartbeat_Status status;

		/// <summary>
		/// 进程状态
		/// </summary>
		[Serializable]
		public class NT_Heartbeat_Status
		{
			public bool app_enabled;
			public bool app_good;
			public bool app_initialized;
			public bool good;
			public bool online;
			public string plugins_good;
			public NT_Heartbeat_Stat stat;
		}

		/// <summary>
		/// 网络连接状态
		/// </summary>
		[Serializable]
		public class NT_Heartbeat_Stat
		{
			public int packet_received;
			public int packet_sent;
			public int packet_lost;
			public int message_received;
			public int message_sent;
			public int disconnect_times;
			public int lost_times;
			public long last_message_time;
		}
	}
	#endregion
}