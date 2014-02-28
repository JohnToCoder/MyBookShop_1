using System;
using System.Collections;

using MyBookShop.BusinessLogicLayer;
using MyBookShop.DataAccessHelper;

namespace MyBookShop.BusinessLogicHelper
{
	public class BookHelper
	{
		/// <summary>
		/// Book��Ľӿڰ�����,���Add���������ݼ��
		/// </summary>
		/// <param name="bookInfo">Add������ͼ���ϣ����Ϣ</param>
		/// <param name="WarningMessageList">���صľ�����Ϣ</param>
		/// <returns>������ݼ����ȷ:����true;����:����false</returns>
		public static bool Add(Hashtable bookInfo,ref ArrayList WarningMessageList)
		{
			bool result = true;
			WarningMessageList.Clear();
			Hashtable quoetedBookInfo=new Hashtable();	//ֵ���е����ŵ�ͼ����Ϣ��ϣ��

			foreach(DictionaryEntry item in bookInfo)
			{
				switch(item.Key.ToString())
				{
					case "BookName":		//ͼ������
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("����:ͼ�����Ʋ���Ϊ��!");
						}
						else if(!ValidateUtility.IsString(item.Value))	//����Ƿ�Ϊ�ַ�������
							{
								result=false;
								WarningMessageList.Add("����:ͼ�������������ʹ���!");
							}
						else
							quoetedBookInfo.Add("BookName",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "CategoryId":		//ͼ�����ID
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("����:ͼ�����ID����Ϊ��!");
						}
						else if(!ValidateUtility.IsDouble(item.Value))	//����Ƿ�Ϊ����������
						{
							result=false;
							WarningMessageList.Add("����:ͼ�����ID���ʹ���!");
						}
						else
							quoetedBookInfo.Add("CategoryId",item.Value.ToString());
						break;
					}
					case "Price":		//ͼ��۸�
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("����:ͼ��۸�������Ϊ��!");
						}
						else if(!ValidateUtility.IsDouble(item.Value))	//����Ƿ�Ϊ����������
						{
							result=false;
							WarningMessageList.Add("����:ͼ��۸��������ʹ���!");
						}
						else
							quoetedBookInfo.Add("Price",item.Value.ToString());
						break;
					}
					case "Publisher":		//������
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("����:�����粻��Ϊ��!");
						}
						else if(!ValidateUtility.IsString(item.Value))	//����Ƿ�Ϊ�ַ�������
						{
							result=false;
							WarningMessageList.Add("����:�������������ʹ���!");
						}
						else
							quoetedBookInfo.Add("Publisher",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "PublishDate":	//��������
					{
						if(!ValidateUtility.IsDateTime(item.Value))	//����Ƿ�Ϊ��������
						{
							result=false;
							WarningMessageList.Add("����:ͼ����������������ʹ���!");
						}
						else
							quoetedBookInfo.Add("PublishDate",SqlStringConstructor.GetQuotedString(item.Value.ToString()));

						break;
					}
					case "Author":		//����
					{
						if(item.Value.ToString()=="")
						{
							result=false;
							WarningMessageList.Add("����:���߲���Ϊ��!");
						}
						else if(!ValidateUtility.IsString(item.Value))	//����Ƿ�Ϊ�ַ�������
						{
							result=false;
							WarningMessageList.Add("����:ͼ�������������ʹ���!");
						}
						else
							quoetedBookInfo.Add("Author",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "PageNum":
					{
						if(!ValidateUtility.IsInt(item.Value))		//����Ƿ�Ϊ��������
						{
							result=false;
							WarningMessageList.Add("����:ͼ��ҳ���������ʹ���!");
						}
						else
							quoetedBookInfo.Add("PageNum",item.Value.ToString());
						break;
					}
					case "PictureUrl":
					{
						if(!ValidateUtility.IsString(item.Value))		//����Ƿ�Ϊ�ַ�������
						{
							result=false;
							WarningMessageList.Add("����:ͼƬ·���������ʹ���!");
						}
						else
							quoetedBookInfo.Add("PictureUrl",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "Description":
					{
						if(!ValidateUtility.IsString(item.Value))		//����Ƿ�Ϊ�ַ�������
						{
							result=false;
							WarningMessageList.Add("����:ͼ��ҳ���������ʹ���!");
						}
						else if(item.Value.ToString().Length>1000)
						{
							result=false;
							WarningMessageList.Add("����:���ͼ�����ַ���1000��֮��!");
						}
						else
							quoetedBookInfo.Add("Description",SqlStringConstructor.GetQuotedString(item.Value.ToString()));
						break;
					}
					case "SaleCount":
					{
						if(!ValidateUtility.IsString(item.Value))		//����Ƿ�Ϊ��������
						{
							result=false;
							WarningMessageList.Add("����:�������������ʹ���!");
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