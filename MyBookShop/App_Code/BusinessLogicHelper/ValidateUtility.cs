using System;

namespace MyBookShop.BusinessLogicHelper
{
	/// <summary>
	/// 数据验证功能类,提供了一系列验证数据的静态方法
	/// </summary>
	public class ValidateUtility
	{
		#region 验证数据类型
		/// <summary>
		/// 验证一个变量能否转换为字符串类型
		/// </summary>
		/// <param name="val">待验证变量</param>
		/// <returns>如果能,返回true;否则,返回false</returns>
		public static bool IsString(object val)
		{
			try
			{
				Convert.ToString(val);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsDouble(object val)
		{
			try
			{
				Convert.ToDouble(val);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public static bool IsInt(object val)
		{
			try
			{
				Convert.ToInt32(val);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public static bool IsDateTime(object val)
		{
			try
			{
				Convert.ToDateTime(val);
				return true;
			}
			catch
			{
				return false;
			}
		}

		#endregion 验证数据类型

	}
}
