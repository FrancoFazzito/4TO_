using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.Framework
{
	public class ExportExcel
	{
		public byte[] ExportarExcel(string[] aColumnas,List<dynamic> lstDatos)
		{
			Workbook book = new Workbook();
			Worksheet sheet = book.Worksheets[0];

			int row = 0;
			int cells = 0;
			//Cargo las columnas
			foreach (string columna  in aColumnas)
			{
				sheet.Rows[row].Cells[cells].Text = columna;
				sheet.Rows[row].Cells[cells].Style.Font.IsBold = true;
				cells++;
			}
			row++;
			//Cargo los datos
			foreach (dynamic objDynamic in lstDatos)
			{
				cells = 0;
				foreach(var property in objDynamic.GetType().GetProperties())
				{			
					sheet.Rows[row].Cells[cells].Text = property.GetValue(objDynamic, null); 
					cells++;
				}
				row++;
			}

			byte[] toArray = null;
			using (MemoryStream ms1 = new MemoryStream())
			{
				book.SaveToStream(ms1, FileFormat.Version97to2003);
				toArray = ms1.ToArray();
			}
			return toArray;
		}

	}
}
