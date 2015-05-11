using System;
using System.Data;
using System.Collections.Generic;

namespace MA.Model
{

	public partial class MaUser
    {
		/// <summary>
        /// Id
        /// </summary>
		public int Id { get; set; }
		/// <summary>
        /// 用户名
        /// </summary>
		public string Name { get; set; }
		/// <summary>
        /// 密码
        /// </summary>
		public string Pwd { get; set; }
		/// <summary>
        /// 昵称
        /// </summary>
		public string Nickname { get; set; }
		/// <summary>
        /// 注册时间
        /// </summary>
		public DateTime Date { get; set; }
		
     }

	public partial class MaUserSummary
    {
		/// <summary>
        /// Id
        /// </summary>
        public static string IdSummary { get{return "Id";} }
		/// <summary>
        /// Id字符长度
        /// </summary>
        public static int IdCharLength { get{return 11;} }
		/// <summary>
        /// 用户名
        /// </summary>
        public static string NameSummary { get{return "用户名";} }
		/// <summary>
        /// 用户名字符长度
        /// </summary>
        public static int NameCharLength { get{return 50;} }
		/// <summary>
        /// 密码
        /// </summary>
        public static string PwdSummary { get{return "密码";} }
		/// <summary>
        /// 密码字符长度
        /// </summary>
        public static int PwdCharLength { get{return 50;} }
		/// <summary>
        /// 昵称
        /// </summary>
        public static string NicknameSummary { get{return "昵称";} }
		/// <summary>
        /// 昵称字符长度
        /// </summary>
        public static int NicknameCharLength { get{return 50;} }
		/// <summary>
        /// 注册时间
        /// </summary>
        public static string DateSummary { get{return "注册时间";} }
		/// <summary>
        /// 注册时间字符长度
        /// </summary>
        public static int DateCharLength { get{return 0;} }
		
     }
}

