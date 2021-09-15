
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml;
using System.IO;
using System.Security;

namespace MedialunaTP
{
    public partial class bitacora : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogueado(BLL.PermisosBLL.Web());
            lblUsuario.Text = usuario.ToString();
            cargarBitacora();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            usuarioNoLogueado();
        }

        private void cargarBitacora()
        {
            List<BE.Bitacora> lista = BLL.BitacoraBLL.listar();

            XmlSerializer ser = new XmlSerializer(typeof(List<BE.Bitacora>));
            string ruta;
            ruta = AppDomain.CurrentDomain.BaseDirectory + @"\sertest.xml";

            using (FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                ser.Serialize(fs, lista);
            }

            XPathDocument xPathDocumen = new XPathDocument(AppDomain.CurrentDomain.BaseDirectory + @"\sertest.xml");
            XPathNavigator xnavegador;
            XPathNodeIterator iterator;
            xnavegador = xPathDocumen.CreateNavigator();
            iterator = xnavegador.Select("ArrayOfBitacora/Bitacora");

            foreach (XPathNavigator item in iterator)
            {
                TableRow fila = new TableRow();

                TableCell id = new TableCell();
                TableCell usuario = new TableCell();
                TableCell usuario2 = new TableCell();
                TableCell accion = new TableCell();
                TableCell fecha = new TableCell();

                id.Text = item.SelectSingleNode(xnavegador.Compile("id")).Value;
                usuario.Text = item.SelectSingleNode(xnavegador.Compile("usuario/login")).Value;
                usuario2.Text = item.SelectSingleNode(xnavegador.Compile("usuario/nombre")).Value;
                usuario2.Text += item.SelectSingleNode(xnavegador.Compile("usuario/apellido")).Value;
                accion.Text = item.SelectSingleNode(xnavegador.Compile("accion")).Value;
                fecha.Text = item.SelectSingleNode(xnavegador.Compile("fecha")).Value;

                fila.Cells.Add(id);
                fila.Cells.Add(usuario);
                fila.Cells.Add(usuario2);
                fila.Cells.Add(accion);
                fila.Cells.Add(fecha);
                tablaBitacora.Rows.Add(fila);
            }
        }
    }
}