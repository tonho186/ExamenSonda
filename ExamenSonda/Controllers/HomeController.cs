using ExamenSonda.Code.Comunes;
using ExamenSonda.Code.Data;
using ExamenSonda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenSonda.Controllers
{
    public class HomeController : Controller
    {
        DataHelper dataHelper = new DataHelper();
        Persona objPersona = new Persona();
        DataTable dt = new DataTable();

        // GET: Home
        public ActionResult Index()
        {
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("NOMBRE", typeof(string)));
            dt.Columns.Add(new DataColumn("APELLIDOS", typeof(string)));
            dt.Columns.Add(new DataColumn("FECHA_NACIMIENTO", typeof(string)));
            dt.Columns.Add(new DataColumn("SEXO", typeof(string)));
            //dt.Columns.Add(new DataColumn("EDITAR", typeof(string)));
            //dt.Columns.Add(new DataColumn("ELIMINAR", typeof(string)));
            System.Web.HttpContext.Current.Session["tablaPersona"] = dt;
            return View();
        }

        [HttpPost]
        public JsonResult RegistrarPersonas(Persona personaBE)
        {
            string score = "";
            bool visibleScore = false;
            string colorScore = "";
            try
            {
                //UserSesionBE userSesionBE = new UserSesionBE
                //{
                //    NCodUsrSis = int.Parse(CustomSession.Current.UserId),
                //    SUsrHost = CustomSession.Current.UsrHost,
                //    SNomHost = CustomSession.Current.UsrHost,
                //    SDirIp = CustomSession.Current.HostIp,
                //    SUsrSis = CustomSession.Current.User
                //};

                DataTable dtP = (DataTable)System.Web.HttpContext.Current.Session["tablaPersona"];
                dt.Rows.Add(dt.Rows.Count + 1, personaBE.nombre, personaBE.apellidos, personaBE.fechaNac, personaBE.sexo);
                //MensajeCliente("Mensaje", sDesResultado, sTipResultado);
                return Json(new
                {
                    score = score,
                    visibleScore = visibleScore,
                    colorScore = colorScore
                }, JsonRequestBehavior.AllowGet);
                // me quede aqui, probar actualizaciones para empezar...
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        public JsonResult GetListaPersonas(CustomDtRequest param)
        {
            int iRecordsTotal = 0;
            string cantServ = param.pnCantServ;
            DataTable dtP = (DataTable)System.Web.HttpContext.Current.Session["tablaPersona"];
            List<Dictionary<string, object>> list = dataHelper.GetListFromTable(dtP);
            if (list.Count > 0)
            {
                iRecordsTotal = dt.Rows.Count;
                foreach (var item in list)
                    item.Add("DT_RowId", "row_" + item["ID"]);
            }
            return Json(new
            {
                draw = param.Draw,
                recordsTotal = iRecordsTotal,
                recordsFiltered = iRecordsTotal,
                data = list
            }, JsonRequestBehavior.AllowGet);
        }

        public class CustomDtRequest : DtRequest
        {
            public string pnCantServ { get; set; }
        }
    }
}