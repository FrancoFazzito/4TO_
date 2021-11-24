using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MrClean
{
	public partial class CarritoXML : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				XmlDocument xmlDoc = new XmlDocument();
				XmlTextReader xmlReader = new XmlTextReader(Server.MapPath("Catalogo.xml"));
				xmlReader.WhitespaceHandling = WhitespaceHandling.None;
				xmlDoc.Load(xmlReader);
				Session.Add("CatalogoSesion", xmlDoc);

				xmlReader.Close();
			}
		}

		protected void btnAgregar_Click(object sender, EventArgs e)
		{
			int n;
			int cantidad = 1;
			
			XmlDocument xmldocumento = (XmlDocument)Session["CatalogoSesion"];
			n = 1;
			cantidad = int.Parse(txtCantidad.Text);
			double precio = double.Parse(xmldocumento.DocumentElement.ChildNodes[n].ChildNodes[2].InnerText);


		}
	}
}