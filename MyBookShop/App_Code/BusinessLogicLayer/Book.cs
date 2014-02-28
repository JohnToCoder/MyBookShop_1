using System;
using System.Collections;
using System.Data;

using MyBookShop.DataAccessLayer;
using MyBookShop.DataAccessHelper;


namespace MyBookShop.BusinessLogicLayer
{
	/// <summary>
	/// 图书对象
	/// </summary>
	public class Book
	{
		#region 私有成员

		private int _bookId;			//图书ID
		private string _bookName;		//图书名
		private int _categoryId;		//分类ID
		private double _price;			//价格
		private string _publisher;		//出版社
		private DateTime _publishDate;	//出版时间
		private string _author;			//作者
		private int _pageNum;			//页数
		private string _pictureUrl;		//图片路径
		private string _description;	//描述
		private int _saleCount;	//销售量

		private bool _exist;			//是否存在标志

		#endregion 私有成员

		#region 属性
		
		public int BookID
		{
			set
			{
				this._bookId=value;
			}
			get
			{
				return this._bookId;
			}
		}
		public string BookName
		{
			set
			{
				this._bookName=value;
			}
			get
			{
				return this._bookName;
			}
		}
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
		public double Price
		{
			set
			{
				this._price=value;
			}
			get
			{
				return this._price;
			}
		}
		public string Publisher
		{
			set
			{
				this._publisher=value;
			}
			get
			{
				return this._publisher;
			}
		}
		public DateTime PublishDate
		{
			set
			{
				this._publishDate=value;
			}
			get
			{
				return this._publishDate;
			}
		}
		public string Author
		{
			set
			{
				this._author=value;
			}
			get
			{
				return this._author;
			}
		}
		public int PageNum
		{
			set
			{
				this._pageNum=value;
			}
			get
			{
				return this._pageNum;
			}
		}		
		public string PictureUrl
		{
			set
			{
				this._pictureUrl=value;
			}
			get
			{
				return this._pictureUrl;
			}
		}
		public string Description
		{
			set
			{
				this._description=value;
			}
			get
			{
				return this._description;
			}
		}
		public int SaleCount
		{
			set
			{
				this._saleCount=value;
			}
			get
			{
				return this._saleCount;
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
		/// 根据参数bookID，获取图书详细信息
		/// </summary>
		/// <param name="topicID">图书ID</param>
		public void LoadData(int bookID)
		{
			Database db=new Database();		//实例化一个Database类

			string sql="";
			sql="Select * from [Book] where BookID = "+ bookID ;

			DataRow dr=db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

			//根据查询得到的数据，对成员赋值
			if(dr!=null)
			{
				this._bookId=GetSafeData.ValidateDataRow_N(dr,"BookID");
				this._bookName=GetSafeData.ValidateDataRow_S(dr,"BookName");
				this._categoryId=GetSafeData.ValidateDataRow_N(dr,"CategoryId");
				this._price=GetSafeData.ValidateDataRow_F(dr,"Price");
				this._publisher=GetSafeData.ValidateDataRow_S(dr,"Publisher");
				this._publishDate=GetSafeData.ValidateDataRow_T(dr,"PublishDate");
				this._author=GetSafeData.ValidateDataRow_S(dr,"Author");
				this._pageNum=GetSafeData.ValidateDataRow_N(dr,"PageNum");
				this._pictureUrl=GetSafeData.ValidateDataRow_S(dr,"PictureUrl");
				this._description=GetSafeData.ValidateDataRow_S(dr,"Description");
				this._saleCount=GetSafeData.ValidateDataRow_N(dr,"SaleCount");
				
				this._exist=true;
			}
			else
			{
				this._exist=false;
			}
		}

		/// <summary>
		/// 向数据库添加一本图书
		/// </summary>
		/// <param name="topicInfo">图书信息哈希表</param>
		public void Add(Hashtable bookInfo)
		{
			Database db=new Database();		//实例化一个Database类
			db.Insert("[Book]",bookInfo );	//利用Database类的Inser方法，插入数据
		}

		/// <summary>
		/// 修改图书内容
		/// </summary>
		/// <param name="newBookInfo">新的图书信息哈希表</param>
		/// <param name="condition">Update的Where子句</param>
		public void Update(Hashtable newBookInfo)
		{
			Database db=new Database();
			string condition = "Where BookID = "+this._bookId;
			db.Update("[Book]",newBookInfo,condition);
		}

		/// <summary>
		/// 删除图书
		/// </summary>
		public void Delete()
		{
			Database db=new Database();
			string strSql="Delete From [Book] Where BookID = "+this._bookId;
			db.ExecuteSQL(strSql);
		}

		/// <summary>
		/// 查询图书信息
		/// </summary>
		/// <param name="queryItems">查询条件哈希表</param>
		/// <returns>查询结果集</returns>
		public static DataTable QueryBooks(Hashtable queryItems)
		{
			string where=SqlStringConstructor.GetConditionClause(queryItems);
			string sql="Select * From [Book] "+where;

			Database db = new Database();
			return db.GetDataTable(sql);
		}

		/// <summary>
		/// 按某个属性，升序或者降序获取所有的图书信息
		/// </summary>
		/// <param name="sortedColumn">排序属性</param>
		/// <param name="sortType">可取{desc,asc}，分别代表降序、升序</param>
		/// <returns>查询结果集</returns>
		public static DataTable QueryBooks(Hashtable queryItems,string sortedColumn,string sortType)
		{
			if(sortType.ToUpper()!="DESC" && sortType.ToUpper()!="ASC" && sortType!="")
				return null;

			string where=SqlStringConstructor.GetConditionClause(queryItems);
			string constrains=" Order By "+sortedColumn+" "+sortType;
			string sql="Select * From [Book] "+where+constrains;

			Database db = new Database();
			return db.GetDataTable(sql);
		}

		/// <summary>
		/// 按照类别查询图书的销售量
		/// </summary>
		/// <returns></returns>
		public static DataTable GetSaleCountByCategory()
		{
			string sql="Select [Category].CategoryName,sum(SaleCount) as SaleCount From [Book],[Category] "
				+"Where [Book].CategoryId=[Category].CategoryId "
				+"Group By [Category].CategoryName";

			Database db=new Database();
			DataTable dt=db.GetDataTable(sql);
			return dt;
		}

		/// <summary>
		/// 按照出版社查询图书的销售量
		/// </summary>
		/// <returns></returns>
		public static DataTable GetSaleCountByPublisher()
		{
			string sql="Select Publisher,sum(SaleCount) as SaleCount From [Book]"
				+"Group By Publisher";

			Database db=new Database();
			DataTable dt=db.GetDataTable(sql);
			return dt;
		}

		/// <summary>
		/// 按照价格级别查询图书的销售量
		/// </summary>
		/// <returns></returns>
		public static DataTable GetSaleCountByPrice()
		{
			string sql=
				"Select SUM(SaleCount) AS SaleCount,'1~30' AS PriceGrade from [Book] where price < 30"
				+" UNION "
				+"Select SUM(SaleCount) AS SaleCount,'30~50' AS PriceGrade from [Book] where price >= 30 and price < 50"
				+" UNION "
				+"Select SUM(SaleCount) AS SaleCount,'50+' AS PriceGrade from [Book] where price >= 50 ";

			Database db=new Database();
			DataTable dt=db.GetDataTable(sql);
			return dt;
		}



		#endregion 方法
	}
}