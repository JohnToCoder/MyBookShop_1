using System;
using System.Data;
using System.Collections;

using MyBookShop.DataAccessLayer;
using MyBookShop.DataAccessHelper;

namespace MyBookShop.BusinessLogicLayer
{
	/// <summary>
	/// Category 的摘要说明。
	/// </summary>
	public class Category
	{
		#region 私有成员

		private int _categoryId;			//图书类别ID
		private string _categoryName;		//图书类别名

		private bool _exist;				//是否存在标志

		#endregion 私有成员

		#region 属性
		
		public int CategoryID
		{
			set
			{
				this._categoryId=value;
			}
			get
			{
				return this._categoryId;
			}
		}
		public string CategoryName
		{
			set
			{
				this._categoryName=value;
			}
			get
			{
				return this._categoryName;
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
		/// 根据参数categoryId，获取图书类别详细信息
		/// </summary>
		/// <param name="topicID">图书类别ID</param>
		public void LoadData(int categoryId)
		{
			Database db=new Database();		//实例化一个Database类

			string sql="";
			sql="Select * from [Category] where CategoryId = "+ categoryId ;

			DataRow dr=db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

			//根据查询得到的数据，对成员赋值
			if(dr!=null)
			{
				this._categoryId=GetSafeData.ValidateDataRow_N(dr,"CategoryId");
				this._categoryName=GetSafeData.ValidateDataRow_S(dr,"CategoryName");
				
				this._exist=true;
			}
			else
			{
				this._exist=false;
			}
		}

		/// <summary>
		/// 根据查询条件哈希表,查询数据
		/// </summary>
		/// <param name="queryItems">查询条件哈希表</param>
		/// <returns>查询结果数据DataTable</returns>
		public static DataTable Query(Hashtable queryItems)
		{
			string where=SqlStringConstructor.GetConditionClause(queryItems);
			string sql="Select * From [Category]"+where;
			Database db = new Database();
			return db.GetDataTable(sql);
		}
		#endregion 方法
	}
}
