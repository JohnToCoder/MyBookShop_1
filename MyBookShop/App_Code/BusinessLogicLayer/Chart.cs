using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using MyBookShop.DataAccessHelper;

namespace MyBookShop.BusinessLogicLayer
{
	/// <summary>
	/// 一个通用的画饼图的类
	/// </summary>
	public class Chart
	{
		private const int SIDE_LENGTH=400;
		private const int PIE_DIAMETER=200;

		/// <summary>
		/// 画饼图方法
		/// </summary>
		/// <param name="title">饼图标题</param>
		/// <param name="subTitle">子标题</param>
		/// <param name="width">宽</param>
		/// <param name="height">高</param>
		/// <param name="dt">数据来源表</param>
		/// <param name="targetFile">生成的图形保存目标文件</param>
		/// <param name="descColumn">文字说明列</param>
		/// <param name="dataColumn">显示在统计图上的数据列名</param>
		public static void DrawPie(string title,string subTitle,int width,int height,DataTable dt,string targetFile,string descColumn,string dataColumn)
		{
			//创建一个位图对象
			Bitmap bm=new Bitmap(width,height);
			Graphics g=Graphics.FromImage(bm);
 
			//将图象"缩放"到指定面积
			g.ScaleTransform(Convert.ToSingle(width)/SIDE_LENGTH,Convert.ToSingle(height)/SIDE_LENGTH);
 
			//画饼图所在的线框
			g.Clear(Color.White);
			g.DrawRectangle(Pens.Black,0,0,SIDE_LENGTH-1,SIDE_LENGTH-1);
 
			//画标题title,副标题subTitle
			g.DrawString(title,new Font("宋体",14),Brushes.Black,new PointF(5,5)); 
			g.DrawString(subTitle,new Font("宋体",12),Brushes.Black,new PointF(7,35));
 
			//画饼图
			float curAngle=0;		//当前所画到的角度
			float totalAngle=0;		//总的角度
			float sumData=0;		//计算所要统计的数据之和
			
			//计算所要统计的数据之和
			foreach(DataRow dr in dt.Rows)
			{
				if(dr[dataColumn]!=DBNull.Value)
					sumData+=Convert.ToSingle(dr[dataColumn]);
			}

			//循环画出每一个扇形,以及其说明
			int colorIndex=0;		//颜色
			float percent=0;		//每一个种类的百分比
			g.DrawRectangle(Pens.Black,100,270,300,130);	//说明线框
			PointF boxOrigin=new PointF(110,275);			//说明标签起始位置
			PointF textOrigin=new PointF(135,275);			//说明文字起始位置

			//循环画出每一个扇形
			foreach(DataRow row in dt.Rows)
			{
				if(row[dataColumn]!=System.DBNull.Value)
				{
					colorIndex++;

					//扇形
					curAngle=Convert.ToSingle(row[dataColumn])/sumData*360;
					g.FillPie(new SolidBrush(GetColor(colorIndex)),100,60,PIE_DIAMETER,PIE_DIAMETER,totalAngle,curAngle);
					g.DrawPie(Pens.Black,100,60,PIE_DIAMETER,PIE_DIAMETER,totalAngle,curAngle);
					totalAngle+=curAngle;

					//标签
					g.FillRectangle(new SolidBrush(GetColor(colorIndex)),boxOrigin.X,boxOrigin.Y,20,10);
					g.DrawRectangle(Pens.Black,boxOrigin.X,boxOrigin.Y,20,10);
 
					//说明
					percent=Convert.ToSingle(row[dataColumn])/sumData*100;
					g.DrawString(
						row[descColumn].ToString()+"（"+percent.ToString("0.0")+"%）",
						new Font("宋体",12),Brushes.Black,textOrigin
						);

					boxOrigin.Y+=20;
					textOrigin.Y+=20;
				}
			}
	
			//将生成的图保存到target
			bm.Save(targetFile,ImageFormat.Gif);
 
			//释放资源
			bm.Dispose();
			g.Dispose();
		}

		/// <summary>
		/// 生成颜色的方法
		/// </summary>
		/// <param name="itemIndex"></param>
		/// <returns></returns>
		public static Color GetColor(int idx)
		{
			idx*=60;
			int r=idx%255;
			int g=((255/3)+idx)%255;
			int b=((255*2/3)+idx)%255;
			return Color.FromArgb(r,g,b);
		}
	}
}