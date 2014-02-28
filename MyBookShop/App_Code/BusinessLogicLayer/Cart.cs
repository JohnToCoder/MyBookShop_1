using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using MyBookShop.DataAccessHelper;
using MyBookShop.DataAccessLayer;

namespace MyBookShop.BusinessLogicLayer
{
	/// <summary>
	/// Cart 的摘要说明。
	/// </summary>
	public class Cart
	{
		#region 私有成员

		private int _cartId;		//购物篮ID
		private int _userId;		//用户ID
		private ArrayList _books=new ArrayList();		//购物篮中的购物篮ID集合
		private ArrayList _amount=new ArrayList();		//购物篮中购物篮的数量

		private bool _exist;			//是否存在标志

		#endregion 私有成员

		#region 属性
		
		public int CartId
		{
			set
			{
				this._cartId=value;
			}
			get
			{
				return this._cartId;
			}
		}
		public int UserId
		{
			set
			{
				this._userId=value;
			}
			get
			{
				return this._userId;
			}
		}
		public ArrayList Books
		{
			set
			{
				this._books=value;
			}
			get
			{
				return this._books;
			}
		}
		public ArrayList Amount
		{
			set
			{
				this._amount=value;
			}
			get
			{
				return this._amount;
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
		/// 根据参数userId，获取购物篮详细信息
		/// </summary>
		/// <param name="userId">用户ID</param>
		public void LoadData(int userId)
		{
			Database db=new Database();		//实例化一个Database类

			string sql="";
			sql="Select * from [Cart] where UserID = "+ userId ;

			SqlDataReader reader=db.GetDataReader(sql);	//利用Database类的GetDataRow方法查询用户数据

			//根据查询得到的数据，对成员安全赋值
			while(reader.Read())
			{
				if(this._cartId==0)
				{
					this._cartId=GetSafeData.ValidateDataReader_N(reader,"CartId");
					this._userId=GetSafeData.ValidateDataReader_N(reader,"UserId");	
				}
				this._books.Add(GetSafeData.ValidateDataReader_N(reader,"BookId"));
				this._amount.Add(GetSafeData.ValidateDataReader_N(reader,"Amount"));
				
				this._exist=true;
			}
			if(this._cartId==0)
			{
				this._exist=false;
			}
		}

		/// <summary>
		/// 向数据库添加一个购物篮中的一种图书
		/// </summary>
		/// <param name="topicInfo">购物篮中的一种图书的信息哈希表</param>
		public void Add(Hashtable cartInfo)
		{
			Database db=new Database();		//实例化一个Database类
			db.Insert("[Cart]",cartInfo );	//利用Database类的Inser方法，插入数据
		}

		/// <summary>
		/// 修改购物篮中的一种图书内容
		/// </summary>
		/// <param name="newCartInfo">新的购物篮信息哈希表</param>
		/// <param name="condition">Update的Where子句</param>
		public void Update(Hashtable newCartInfo,int cartId)
		{
			Database db=new Database();
			string condition = "Where CartID = "+cartId.ToString();
			db.Update("[Cart]",newCartInfo,condition);
		}

		/// <summary>
		/// 删除整个购物篮
		/// </summary>
		public void Delete()
		{
			Database db=new Database();
			string strSql="Delete From [Cart] Where CartID = "+this._cartId;
			db.ExecuteSQL(strSql);
		}

		/// <summary>
		/// 删除购物篮种某种图书
		/// </summary>
		/// <param name="cartId">将要删除购物篮的项目编号</param>
		public void RemoveBook(int cartId)
		{
			Database db=new Database();
			string strSql="Delete From [Cart] Where cartId = "+cartId.ToString();
			db.ExecuteSQL(strSql);
		}

		/// <summary>
		/// 查询userId的购物篮中的信息，并以DataTable返回
		/// </summary>
		/// <param name="userId">用户编号</param>
		/// <returns>购物篮信息DataTable</returns>
		public static DataTable Query(int userId)
		{
			string sql="";
			sql="Select * From [Cart],[Book] Where [Cart].UserId = "+userId
				+" And [Cart].bookId=[Book].bookId";
			Database db=new Database();
			return db.GetDataTable(sql);
		}

		#endregion 方法
	}
}
