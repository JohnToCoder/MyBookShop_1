using System;
using System.Collections;

using MyBookShop.BusinessLogicLayer;
using MyBookShop.DataAccessHelper;

namespace MyBookShop.BusinessLogicHelper
{
	public class BookHelper
	{
		/// <summary>
		/// Book类的接口帮助类,完成Add方法的数据检查
		/// </summary>
		/// <param name="bookInfo">Add方法的图书哈希表信息</param>
		/// <param name="WarningMessageList">返回的警告信息</param>
		/// <returns>如果数据检查正确:返回true;否则:返回false</returns>
		public static bool Add(Hashtable bookInfo,ref ArrayList WarningMessageList)
		{
			bool result = true;
			WarningMessageList.Clear();
			Hashtable quoetedBookInfo=new Hashtable();	//值带有单引号的图书信息哈希表

			foreach(DictionaryEntry item in bookInfo)
			{
				switch(item.Key.ToString())
				{
					case "BookName":		//图书名称
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("警告:图书名称不能为空!");
						}
						else if(!ValidateUtility.IsString(item.Value))	//检查是否为字符串类型
							{
								result=false;
								WarningMessageList.Add("警告:图书名称数据类型错误!");
							}
						else
							quoetedBookInfo.Add("BookName",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "CategoryId":		//图书类别ID
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("警告:图书类别ID不能为空!");
						}
						else if(!ValidateUtility.IsDouble(item.Value))	//检查是否为浮点数类型
						{
							result=false;
							WarningMessageList.Add("警告:图书类别ID类型错误!");
						}
						else
							quoetedBookInfo.Add("CategoryId",item.Value.ToString());
						break;
					}
					case "Price":		//图书价格
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("警告:图书价格数不能为空!");
						}
						else if(!ValidateUtility.IsDouble(item.Value))	//检查是否为浮点数类型
						{
							result=false;
							WarningMessageList.Add("警告:图书价格数据类型错误!");
						}
						else
							quoetedBookInfo.Add("Price",item.Value.ToString());
						break;
					}
					case "Publisher":		//出版社
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("警告:出版社不能为空!");
						}
						else if(!ValidateUtility.IsString(item.Value))	//检查是否为字符串类型
						{
							result=false;
							WarningMessageList.Add("警告:出版社数据类型错误!");
						}
						else
							quoetedBookInfo.Add("Publisher",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "PublishDate":	//出版日期
					{
						if(!ValidateUtility.IsDateTime(item.Value))	//检查是否为日期类型
						{
							result=false;
							WarningMessageList.Add("警告:图书出版日期数据类型错误!");
						}
						else
							quoetedBookInfo.Add("PublishDate",SqlStringConstructor.GetQuotedString(item.Value.ToString()));

						break;
					}
					case "Author":		//作者
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("警告:作者不能为空!");
						}
						else if(!ValidateUtility.IsString(item.Value))	//检查是否为字符串类型
						{
							result=false;
							WarningMessageList.Add("警告:图书名称数据类型错误!");
						}
						else
							quoetedBookInfo.Add("Author",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "PageNum":
					{
						if(!ValidateUtility.IsInt(item.Value))		//检查是否为整数类型
						{
							result=false;
							WarningMessageList.Add("警告:图书页数数据类型错误!");
						}
						else
							quoetedBookInfo.Add("PageNum",item.Value.ToString());
						break;
					}
					case "PictureUrl":
					{
						if(!ValidateUtility.IsString(item.Value))		//检查是否为字符串类型
						{
							result=false;
							WarningMessageList.Add("警告:图片路径数据类型错误!");
						}
						else
							quoetedBookInfo.Add("PictureUrl",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "Description":
					{
						if(!ValidateUtility.IsString(item.Value))		//检查是否为字符串类型
						{
							result=false;
							WarningMessageList.Add("警告:图书页数数据类型错误!");
						}
						else if(item.Value.ToString().Length>1000)
						{
							result=false;
							WarningMessageList.Add("警告:请把图书简介字符在1000字之内!");
						}
						else
							quoetedBookInfo.Add("Description",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "SaleCount":
					{
						if(!ValidateUtility.IsString(item.Value))		//检查是否为整数类型
						{
							result=false;
							WarningMessageList.Add("警告:销售量数据类型错误!");
						}
						else
							quoetedBookInfo.Add("SaleCount",item.Value.ToString());
						break;
					}
				}//switch
			}//while

			if (result)
			{
				Book book=new Book();
				book.Add(quoetedBookInfo);
			}
			return result;
		}
	}
}