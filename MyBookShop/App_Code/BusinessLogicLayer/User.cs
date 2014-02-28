/**********************************************************
 * 说明：用户类User
 * 作者：
 * 创建日期：
 *********************************************************/
using System;
using System.Collections;
using System.Data;

using MyBookShop.DataAccessLayer;
using MyBookShop.DataAccessHelper;

namespace MyBookShop.BusinessLogicLayer
{
	/// <summary>
	/// User 的摘要说明。
	/// </summary>
	public class User
	{
		#region 私有成员

		private int _userID;		//用户ID
		private string _loginName;	//用户登录名
		private string _userName;	//用户姓名
		private string _password;	//用户密码
		private string _address;	//用户地址
		private string _zip;		//用户邮编

		private bool _exist;		//是否存在标志

		#endregion 私有成员

		#region 属性
		
		public int UserID
		{
			set
			{
				this._userID=value;
			}
			get
			{
				return this._userID;
			}
		}
		public string LoginName
		{
			set
			{
				this._loginName=value;
			}
			get
			{
				return this._loginName;
			}
		}
		public string UserName
		{
			set
			{
				this._userName=value;
			}
			get
			{
				return this._userName;
			}
		}
		public string Password
		{
			set
			{
				this._password=value;
			}
			get
			{
				return this._password;
			}
		}
		public string Address
		{
			set
			{
				this._address=value;
			}
			get
			{
				return this._address;
			}
		}
		public string Zip
		{
			set
			{
				this._zip=value;
			}
			get
			{
				return this._zip;
			}
		}
		public bool Exist
		{
			get
			{
				return this._exist;
			}
		}

		#endregion 属性

		#region 方法
		
		/// <summary>
		/// 根据参数loginName，获取用户详细信息
		/// </summary>
		/// <param name="loginName">用户登录名</param>
		public void LoadData(string loginName)
		{
			Database db=new Database();		//实例化一个Database类

			string sql="";
			sql="Select * from [User] where LoginName = "
				+SqlStringConstructor.GetQuotedString(loginName);

			DataRow dr=db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

			//根据查询得到的数据，对成员赋值
			if(dr!=null)
			{
				this._userID=GetSafeData.ValidateDataRow_N(dr,"UserID");
				this._loginName=GetSafeData.ValidateDataRow_S(dr,"loginName");
				this._userName=GetSafeData.ValidateDataRow_S(dr,"UserName");
				this._password=GetSafeData.ValidateDataRow_S(dr,"PassWord");
				this._address=GetSafeData.ValidateDataRow_S(dr,"Address");
				this._zip=GetSafeData.ValidateDataRow_S(dr,"Zip");
			
				this._exist=true;
			}
			else
			{
				this._exist=false;
			}
		}

		/// <summary>
		/// 根据参数loginName，获取用户详细信息
		/// </summary>
		/// <param name="userId">用户ID</param>
		public void LoadData(int userId)
		{
			Database db=new Database();		//实例化一个Database类

			string sql="";
			sql="Select * from [User] where UserId = "+userId.ToString();

			DataRow dr=db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

			//根据查询得到的数据，对成员赋值
			if(dr!=null)
			{
				this._userID=GetSafeData.ValidateDataRow_N(dr,"UserID");
				this._loginName=GetSafeData.ValidateDataRow_S(dr,"loginName");
				this._userName=GetSafeData.ValidateDataRow_S(dr,"UserName");
				this._password=GetSafeData.ValidateDataRow_S(dr,"PassWord");
				this._address=GetSafeData.ValidateDataRow_S(dr,"Address");
				this._zip=GetSafeData.ValidateDataRow_S(dr,"Zip");
			
				this._exist=true;
			}
			else
			{
				this._exist=false;
			}
		}

		/// <summary>
		/// 向数据库添加一个用户
		/// </summary>
		/// <param name="htUserInfo">用户信息哈希表</param>
		public void Add(Hashtable userInfo)
		{
			Database db=new Database();		//实例化一个Database类
			db.Insert("[User]",userInfo );	//利用Database类的GetDataRow方法查询用户数据
		}

		/// <summary>
		/// 判断是否存在登录名为loginName的用户
		/// </summary>
		/// <param name="loginName">用户登录名</param>
		/// <returns>如果存在，返回true；否则，返回false</returns>
		public static bool HasUser(string loginName)
		{
			Database db=new Database();
			
			string sql="";
			sql="Select * from [User] where [LoginName] = "
				+SqlStringConstructor.GetQuotedString(loginName);

			DataRow row=db.GetDataRow(sql);
			if(row!=null)
				return true;
			else
				return false;
		}
		#endregion 方法
	}
}
