using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NT_CQMsg
{
	/// <summary>
	/// 角色信息类（综合了群内数据）
	/// </summary>
	[Serializable]
	public class NT_UID
	{
		/// <summary>
		/// QQ UID
		/// </summary>
		public long user_id;
		/// <summary>
		/// 昵称
		/// </summary>
		public string nickname;
		/// <summary>
		/// 性别，male 或 female 或 unknown
		/// </summary>
		public string sex;
		/// <summary>
		/// 年龄
		/// </summary>
		public int age;
		/// <summary>
		/// 好友备注名
		/// </summary>
		public string remark;



		#region 在群内时的数据
		//获取列表时和获取单独的成员信息时，某些字段可能有所不同，例如 area、title 等字段在获取列表时无法获得，具体应以单独的成员信息为准。

		/// <summary>
		/// 群UID
		/// </summary>
		public long group_id;
		/// <summary>
		/// 群名片
		/// </summary>
		public string card;
		/// <summary>
		/// 是否允许修改群名片
		/// </summary>
		public bool card_changeable;
		/// <summary>
		/// 地区
		/// </summary>
		public string area;
		/// <summary>
		/// 成员等级
		/// </summary>
		public string level;
		/// <summary>
		/// 角色，owner 或 admin 或 member
		/// </summary>
		public string role;
		/// <summary>
		/// 专属头衔
		/// </summary>
		public string title;
		/// <summary>
		/// 专属头衔过期时间戳
		/// </summary>
		public int title_expire_time;

		/// <summary>
		/// 加群时间戳
		/// </summary>
		public int join_time;
		/// <summary>
		/// 最后发言时间戳
		/// </summary>
		public int last_sent_time;
		/// <summary>
		/// 是否不良记录成员
		/// </summary>
		public bool unfriendly;
		#endregion
	}

	[Serializable]
	public class NT_Anonymous 
	{
		public long id;
		public string name;
		public string flag;
	}

	/// <summary>
	/// 群信息类
	/// </summary>
	[Serializable]
	public class NT_Group
	{
		/// <summary>
		/// 群UID
		/// </summary>
		public long group_id;
		/// <summary>
		/// 群名
		/// </summary>
		public string group_name;
		/// <summary>
		/// 成员数
		/// </summary>
		public int member_count;
		/// <summary>
		/// 最大成员数（群容量）
		/// </summary>
		public int max_member_count;
	}
}