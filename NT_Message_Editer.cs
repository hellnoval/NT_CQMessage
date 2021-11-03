using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT_CQMsg
{
	[Serializable]
	public class NT_Message_Editer
	{
		public NT_Message_Call _NT_Message_Call;
		public NT_Message_CallBack _NT_Message_CallBack;

		
	}

	public class NT_Message_CallBack
	{
		#region 回调解析类
		/// <summary>
		/// 通用API回调解析类
		/// </summary>
		[Serializable]
		public class NT_Message_CallBack_API : NT_Message_CallBack
		{
			/// <summary>
			/// 发送时间
			/// </summary>
			public long time;
			/// <summary>
			/// 消息类型
			/// </summary>
			public string message_type;
			/// <summary>
			/// 消息类型(转义)
			/// </summary>
			public NT_BaseAttribute_Message.NT_Message_Type_E _Message_type;
			/// <summary>
			/// 消息 ID
			/// </summary>
			public int message_id;
			/// <summary>
			/// 消息真实 ID
			/// </summary>
			public int real_id;
	/// <summary>
			/// 发送人信息(转义)
			/// </summary>
			public NT_UID sender;
			/// <summary>
			/// 消息内容
			/// </summary>
			public NT_Message[] message;

			/// <summary>
			/// 好友列表
			/// </summary>
			public NT_UID[] _List_Friend;
			/// <summary>
			/// 群列表
			/// </summary>
			public NT_Group[] _List_Group;
			/// <summary>
			/// 群成员列表
			/// </summary>
			public NT_UID[] _List_GroupMember;

			/// <summary>
			/// QQ UID
			/// </summary>
			public long user_id;
			/// <summary>
			/// 群UID
			/// </summary>
			public long group_id;
		
			/// <summary>
			/// 群名
			/// </summary>
			public string group_name;

			/// <summary>
			/// 本机文件路径
			/// </summary>
			public string file;
			/// <summary>
			/// 检查结果(图片 语音)
			/// </summary>
			public bool yes;

			public void Initializer(NT_Object _NT_Object = null)
			{
				if (message_type != string.Empty)
				{
					switch (message_type)
					{
						case "private":
							_Message_type = NT_BaseAttribute_Message.NT_Message_Type_E._private;
							break;
						case "group":
							_Message_type = NT_BaseAttribute_Message.NT_Message_Type_E.group;
							break;
						default:
							_Message_type = NT_BaseAttribute_Message.NT_Message_Type_E._Null;
							break;

					}
				}

				if (message != null)
				{
					foreach (var v in message)
					{
						v.Initializer(_NT_Object);
					}
				}
			}
		}

		/// <summary>
		/// QQ相关接口凭证类
		/// </summary>
		[Serializable]
		public class NT_Message_CallBack_Info_Credentials : NT_Message_CallBack
		{
			public string cookies;
			/// <summary>
			/// CSRF Token
			/// </summary>
			public int token = -1;
			/// <summary>
			/// CSRF Token
			/// </summary>
			public int csrf_token = -1;
		}

		/// <summary>
		/// 运行状态类
		/// </summary>
		[Serializable]
		public class NT_Message_CallBack_Info_Version : NT_Message_CallBack
		{
			/// <summary>
			/// Json数据
			/// </summary>
			public string _Raw;
			/// <summary>
			/// 应用标识，如 mirai-native
			/// </summary>
			public string app_name;
			/// <summary>
			/// 应用版本，如 1.2.3
			/// </summary>
			public string app_version;
			/// <summary>
			/// OneBot 标准版本，如 v11
			/// </summary>
			public string protocol_version;

			//其他参数详见raw

			public NT_Message_CallBack_Info_Version()
			{
			}

			public NT_Message_CallBack_Info_Version(string _Raw)
			{
				this._Raw = _Raw;
			}
		}

		/// <summary>
		/// 信息-群内荣誉类
		/// </summary>
		[Serializable]
		public class NT_Message_CallBack_Info_Honor : NT_Message_CallBack
		{
			/// <summary>
			/// 群UID
			/// </summary>
			public long group_id;
			/// <summary>
			/// 当前龙王，仅 type 为 talkative 或 all 时有数据
			/// </summary>
			public NT_Message_CallBack_Info_Honor_Item_Current current_talkative;
			/// <summary>
			/// 历史龙王，仅 type 为 talkative 或 all 时有数据
			/// </summary>
			public NT_Message_CallBack_Info_Honor_Item_Other[] talkative_list;
			/// <summary>
			/// 群聊之火，仅 type 为 performer 或 all 时有数据
			/// </summary>
			public NT_Message_CallBack_Info_Honor_Item_Other[] performer_list;
			/// <summary>
			/// 群聊炽焰，仅 type 为 legend 或 all 时有数据
			/// </summary>
			public NT_Message_CallBack_Info_Honor_Item_Other[] legend_list;
			/// <summary>
			/// 冒尖小春笋，仅 type 为 strong_newbie 或 all 时有数据
			/// </summary>
			public NT_Message_CallBack_Info_Honor_Item_Other[] strong_newbie_list;
			/// <summary>
			/// 快乐之源，仅 type 为 emotion 或 all 时有数据
			/// </summary>
			public NT_Message_CallBack_Info_Honor_Item_Other[] emotion_list;

			/// <summary>
			/// 信息-群内荣誉当前龙王信息
			/// </summary>
			[Serializable]
			public class NT_Message_CallBack_Info_Honor_Item_Current
			{
				public long user_id;
				public string nickname;
				/// <summary>
				/// 头像 URL
				/// </summary>
				public string avatar;
				public int day_count;
			}

			/// <summary>
			/// 信息-群内荣誉其他信息
			/// </summary>
			[Serializable]
			public class NT_Message_CallBack_Info_Honor_Item_Other
			{
				public long user_id;
				public string nickname;
				/// <summary>
				/// 头像 URL
				/// </summary>
				public string avatar;
				/// <summary>
				/// 荣誉描述
				/// </summary>
				public string description;
			}
		}
		#endregion
	}

	/// <summary>
	/// 定义的Call主类
	/// </summary>
	public class NT_Message_Call
	{
		public NT_Call_Type_E _NT_Call_Type_E;
		public string _NT_Call_Json;
		public enum NT_Call_Type_E
		{
			send_private_msg,
			send_group_msg,
			send_msg,
			delete_msg,
			get_msg,
			get_forward_msg,
			send_like,
			set_group_kick,
			set_group_ban,
			set_group_anonymous_ban,
			set_group_whole_ban,
			set_group_admin,
			set_group_anonymous,
			set_group_card,
			set_group_name,
			set_group_leave,
			set_group_special_title,
			set_friend_add_request,
			set_group_add_request,
			get_login_info,
			get_stranger_info,
			get_friend_list,
			get_group_info,
			get_group_list,
			get_group_member_info,
			get_group_member_list,
			get_group_honor_info,
			get_cookies,
			get_csrf_token,
			get_credentials,
			get_record,
			get_image,
			can_send_image,
			can_send_record,
			get_status,
			get_version_info,
			set_restart,
			clean_cache
		}

		#region 消息
		/// <summary>
		/// 发送消息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Message : NT_Message_Call
		{
			/// <summary>
			/// 消息类型
			/// </summary>
			public string message_type;
			public long user_id;
			public long group_id;
			public NT_Message[] message;
			public bool auto_escape = false;
		}

		/// <summary>
		/// 撤回消息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Delete : NT_Message_Call
		{
			public int message_id;
		}

		/// <summary>
		/// 获取消息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get : NT_Message_Call
		{
			public int message_id;
		}

		/// <summary>
		/// 获取合并转发消息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Forward : NT_Message_Call
		{
			public string id;
		}
		#endregion

		#region 群内功能
		/// <summary>
		/// 发送好友赞
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Like : NT_Message_Call
		{
			public long user_id;
			/// <summary>
			/// 赞的次数，每个好友每天最多 10 次
			/// </summary>
			public int times = 1;
		}

		/// <summary>
		/// 群组踢人
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Kick : NT_Message_Call
		{
			public long group_id;
			public long user_id;
			public bool reject_add_request = false;
		}

		/// <summary>
		/// 群组单人禁言
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Ban : NT_Message_Call
		{
			public long group_id;
			public long user_id;
			/// <summary>
			/// 禁言时长，默认30分钟，0则为取消
			/// </summary>
			public int duration = 30 * 60;
		}

		/// <summary>
		/// 群组全员禁言
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Ban_Anonymous : NT_Message_Call
		{
			public long group_id;
			/// <summary>
			/// 可选，要禁言的匿名用户对象（群消息上报的 anonymous 字段）
			/// anonymous 和 anonymous_flag 两者任选其一传入即可，若都传入，则使用 anonymous。
			/// </summary>
			public NT_Anonymous anonymous;
			/// <summary>
			/// 可选，要禁言的匿名用户的 flag（需从群消息上报的数据中获得）
			/// </summary>
			public string flag;
			/// <summary>
			/// 禁言时长，默认30分钟，0则为取消
			/// </summary>
			public int duration = 30 * 60;
		}

		/// <summary>
		/// 群组全员禁言
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Ban_Whole : NT_Message_Call
		{
			public long group_id;
			public bool enable = true;
		}

		/// <summary>
		/// 群组设置管理员
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Group_Admin : NT_Message_Call
		{
			public long group_id;
			public long user_id;
			public bool enable = true;
		}

		/// <summary>
		/// 群组匿名
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Group_Anonymous : NT_Message_Call
		{
			public long group_id;
			public bool enable = true;
		}

		/// <summary>
		/// 设置群名片（群备注）
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Group_Card : NT_Message_Call
		{
			public long group_id;
			public long user_id;
			public string card;
		}

		/// <summary>
		/// 设置群名
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Group_Name : NT_Message_Call
		{
			public long group_id;
			public string group_name;
		}

		/// <summary>
		/// 退出群组
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Group_Leave : NT_Message_Call
		{
			public long group_id;
			/// <summary>
			/// 是否解散，如果登录号是群主，则仅在此项为 true 时能够解散
			/// </summary>
			public bool is_dismiss = false;
		}

		/// <summary>
		/// 设置群组专属头衔
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Group_Special_Title : NT_Message_Call
		{
			public long group_id;
			public long user_id;
			/// <summary>
			/// 专属头衔，不填或空字符串表示删除专属头衔
			/// </summary>
			public string special_title;
			/// <summary>
			/// 专属头衔有效期，单位秒，-1 表示永久，不过此项似乎没有效果，可能是只有某些特殊的时间长度有效，有待测试
			/// </summary>
			public int duration = -1;
		}
		#endregion

		#region 信息获取以及处理功能
		#region 处理功能
		/// <summary>
		/// 处理加好友请求
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Friend_Add_Request : NT_Message_Call
		{
			/// <summary>
			/// 加好友请求的 flag（需从上报的数据中获得）
			/// </summary>
			public string flag;
			/// <summary>
			/// 是否同意请求
			/// </summary>
			public bool approve = true;
			/// <summary>
			/// 添加后的好友备注（仅在同意时有效）
			/// </summary>
			public string remark;
		}

		/// <summary>
		/// 处理加群请求／邀请
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Group_Add_Request : NT_Message_Call
		{
			/// <summary>
			/// 加群请求的 flag（需从上报的数据中获得）
			/// </summary>
			public string flag;
			/// <summary>
			/// add 或 invite，请求类型（需要和上报消息中的 sub_type 字段相符
			/// </summary>
			public string sub_type = "invite";
			/// <summary>
			/// 是否同意请求
			/// </summary>
			public bool approve = true;
			/// <summary>
			/// 	拒绝理由（仅在拒绝时有效）
			/// </summary>
			public string reason;
		}
		#endregion

		#region 获取指定信息
		/// <summary>
		/// 获取陌生人信息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Stranger : NT_Message_Call
		{
			public long user_id;
			/// <summary>
			/// 是否不使用缓存（使用缓存可能更新不及时，但响应更快
			/// </summary>
			public bool no_cache = true;
		}

		/// <summary>
		/// 获取群成员信息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_GroupMember : NT_Message_Call
		{
			/// <summary>
			/// 群号
			/// </summary>
			public long group_id;
			public long user_id;
			/// <summary>
			/// 是否不使用缓存（使用缓存可能更新不及时，但响应更快
			/// </summary>
			public bool no_cache = true;
		}

		/// <summary>
		/// 获取群信息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Group : NT_Message_Call
		{
			/// <summary>
			/// 群号
			/// </summary>
			public long group_id;
			/// <summary>
			/// 是否不使用缓存（使用缓存可能更新不及时，但响应更快
			/// </summary>
			public bool no_cache = true;
		}

		/// <summary>
		/// 获取好友列表
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_FriendList : NT_Message_Call
		{
		}

		/// <summary>
		/// 获取群列表
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_GroupList : NT_Message_Call
		{
		}

		/// <summary>
		/// 获取群成员列表
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_GroupMemberList : NT_Message_Call
		{
			/// <summary>
			/// 群号
			/// </summary>
			public long group_id;
		}

		/// <summary>
		/// 获取群荣誉信息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_GroupHonor : NT_Message_Call
		{
			/// <summary>
			/// 群号
			/// </summary>
			public long group_id;
			/// <summary>
			/// 要获取的群荣誉类型，可传入 talkative performer legend strong_newbie emotion 以分别获取单个类型的群荣誉数据，或传入 all 获取所有数据
			/// </summary>
			public string type = "all";
		}
		#endregion

		#region 运行状态信息
		/// <summary>
		/// 获取登录号信息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Login : NT_Message_Call
		{
		}

		/// <summary>
		/// 获取 Cookies
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Cookies : NT_Message_Call
		{
			/// <summary>
			/// 需要获取 cookies 的域名
			/// </summary>
			public string domain;
		}

		/// <summary>
		/// 获取 CSRF Token
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_CsrfToken : NT_Message_Call
		{
		}

		/// <summary>
		/// 获取 QQ 相关接口凭证
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Credentials : NT_Message_Call
		{
			//即上面两个接口的合并

			/// <summary>
			/// 需要获取 cookies 的域名
			/// </summary>
			public string domain;
		}

		/// <summary>
		/// 获取语音
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Record : NT_Message_Call
		{
			//要使用此接口，通常需要安装 ffmpeg，请参考 OneBot 实现的相关说明。

			/// <summary>
			/// 收到的语音文件名（消息段的 file 参数），如 0B38145AA44505000B38145AA4450500.silk
			/// </summary>
			public string file;
			/// <summary>
			/// 要转换到的格式，目前支持 mp3、amr、wma、m4a、spx、ogg、wav、flac
			/// </summary>
			public string out_format;
		}

		/// <summary>
		/// 获取图片
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Image : NT_Message_Call
		{
			/// <summary>
			/// 收到的图片文件名（消息段的 file 参数），如 6B4DE3DFD1BD271E3297859D41C530F5.jpg
			/// </summary>
			public string file;
		}

		/// <summary>
		/// 检查是否可以发送图片
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_CanSendImage : NT_Message_Call
		{

		}

		/// <summary>
		/// 检查是否可以发送图片
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_CanSendRecord : NT_Message_Call
		{

		}

		/// <summary>
		/// 获取运行状态
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Status : NT_Message_Call
		{
		}

		/// <summary>
		/// 获取版本信息
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Get_Info_Version : NT_Message_Call
		{
		}

		/// <summary>
		/// 清理缓存
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_CleanCache : NT_Message_Call
		{
		}

		/// <summary>
		/// 重启Onebot
		/// </summary>
		[Serializable]
		public class NT_Message_Editer_Set_Restart : NT_Message_Call
		{
			/// <summary>
			/// 要延迟的毫秒数，如果默认情况下无法重启，可以尝试设置延迟为 2000 左右
			/// </summary>
			public int delay = 2000;
		}
		#endregion
		#endregion
	}
}