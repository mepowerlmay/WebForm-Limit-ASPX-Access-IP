using System;
namespace WebSite20210103IP登入限制.Model
{
	/// <summary>SYSAA表实体类
	/// 作者:alonso(line id: menshin7)
	/// 创建时间:2021-01-03 13:25:13
	/// </summary>
	[Serializable]
	public partial class SYSAA
	{
		public SYSAA()
		{}
		private int _AA001 ;
		/// <summary>
		/// 
		/// </summary>
		public int AA001
		{
			set{ _AA001=value;}
			get{return _AA001;}
		}
		private string _AA002 ;
		/// <summary>
		/// 
		/// </summary>
		public string AA002
		{
			set{ _AA002=value;}
			get{return _AA002;}
		}
		private string _AA003 ;
		/// <summary>
		/// 
		/// </summary>
		public string AA003
		{
			set{ _AA003=value;}
			get{return _AA003;}
		}
	}
}
