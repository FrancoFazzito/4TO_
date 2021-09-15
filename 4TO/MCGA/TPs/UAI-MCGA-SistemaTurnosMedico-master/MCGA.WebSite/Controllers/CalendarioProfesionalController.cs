using MCGA.Constants;
using MCGA.Entities;
using MCGA.UI.Process;
using MCGA.WebSite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA.WebSite.Controllers
{
	[Authorize(Roles = "Profesional")]
    public class CalendarioProfesionalController : Controller
    {
		private AgendaProcess agendaProcess = new AgendaProcess();
		private EspecialidadesProfesionalProcess especialidadesProfesionalProcess = new EspecialidadesProfesionalProcess();
		private ProfesionalProcess profesionalProcess = new ProfesionalProcess();
		private TurnoProcess turnoProcess = new TurnoProcess();
		private AtencionProcess atencionProcess = new AtencionProcess();
		private CancelacionProcess cancelacionProcess = new CancelacionProcess();
		

		// GET: Calendario
		[Route("mi-calendario", Name = CalendarioProfesionalControllerRoute.GetCalendario)]
		public ActionResult Calendario()
        {
			Profesional profesional = profesionalProcess.GetAll().Where(o => o.Email == User.Identity.Name).FirstOrDefault();
			ViewBag.NombreProfesional = string.Format("{0} {1}", profesional.Nombre, profesional.Apellido);
			ViewBag.EspecialidadId = new SelectList(especialidadesProfesionalProcess.GetAll().Where(o => o.ProfesionalId == profesional.Id).Select(o => new { Id = o.Id, Especialidad = o.Especialidad.descripcion }), "Id", "Especialidad");
			ViewBag.ProfesionalId = profesional.Id;
			return View();
        }

		public JsonResult GetCalendarioViewProfesional(DateTime fechaDesde, DateTime fechaHasta, string especialidadProfesional)
		{
			//parametro especialidadProfesional si viene vacio son todas las especialidades del profesional logueado
			if (fechaDesde == null)
				fechaDesde = new DateTime(1800, 1, 1);

			if (fechaHasta == null)
				fechaHasta = new DateTime(1800, 1, 1);

			int iColor = 0;
			//Reviso si tiene alguna agenda
			List<Agenda> listAtencion;
			if (especialidadProfesional == string.Empty)
			{
				int profesionalId = profesionalProcess.GetAll().Where(o => o.Email == User.Identity.Name).FirstOrDefault().Id;
				listAtencion = agendaProcess.GetAll().Where(o => o.EspecialidadesProfesional.ProfesionalId == profesionalId && fechaDesde >= o.fecha_desde && fechaHasta <= o.fecha_hasta).ToList();
			}
			else
				listAtencion = agendaProcess.GetAll().Where(o => o.EspecialidadProfesionalId == Convert.ToInt32(especialidadProfesional) && fechaDesde >= o.fecha_desde && fechaHasta <= o.fecha_hasta).ToList();

			if (listAtencion.Count > 0)
			{
				List<CalendarioViewProfesionalModel> listCalendario = new List<CalendarioViewProfesionalModel>();
				List<EspecialidadColorModel> listEspecialidadColor = new List<EspecialidadColorModel>();
				//Recorremos por especialidad
				foreach (int especialidadProfesionalId in listAtencion.Select(o=>o.EspecialidadProfesionalId).Distinct().ToList())
				{
					//Recorro la lista filtrando por especialidadProfesionalId					
					foreach (Agenda agenda in listAtencion.Where(o=> o.EspecialidadProfesionalId == especialidadProfesionalId).ToList())
					{
						DateTime fecha = fechaDesde;
						while (fecha <= fechaHasta)
						{
							//Ver si atiende ese dia
							if ((int)fecha.DayOfWeek == agenda.TipoDia.referenciaDayOfWeek)
							{
								TimeSpan hora = agenda.hora_desde;
								while (hora <= agenda.hora_hasta)
								{
									CalendarioViewProfesionalModel calendario = new CalendarioViewProfesionalModel();
									
									Turno turno = turnoProcess.GetAll().Where(o => o.Fecha == fecha && o.Hora == hora && o.EspecialidadProfesionalId == especialidadProfesionalId).FirstOrDefault();
									//Cargo variables generales
									calendario.FechaInicio = (new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hours, hora.Minutes, hora.Seconds)).ToString("yyyy-MM-dd HH:mm"); //"2018-10-29 17:00";
									calendario.FechaFin = (new DateTime(fecha.Year, fecha.Month, fecha.Day, (hora.Hours + 1), hora.Minutes, hora.Seconds)).ToString("yyyy-MM-dd HH:mm");
									calendario.FontColor = Framework.ColorEvento.NEGRO;
									calendario.BackgroundColor = Framework.ColorEspecialidad.lstColor[iColor];
									//Verificar si ese día y horario tiene turno
									if (agenda.AgendaCancelacion.Count() == 0)
									{ 
										if (turno != null)
										{
											//Ver si esta atendido 
											if (atencionProcess.GetAll().Where(o => o.turno_id == turno.Id).FirstOrDefault() != null)
											{
												//Lo atendio
												//Tiene turno
												calendario.Atendido = true;
												calendario.IdTurno = turno.Id;
												calendario.Titulo = string.Format("{0} {1}", turno.Afiliado.Nombre, turno.Afiliado.Apellido);
												calendario.Descripcion = string.Format("{0} {1}", turno.Afiliado.Nombre, turno.Afiliado.Apellido);
												calendario.BorderColor = Framework.ColorEvento.ATENDIDO;
											}
											else
											{
												//Tiene turno
												calendario.IdTurno = turno.Id;
												calendario.Titulo = string.Format("{0} {1}", turno.Afiliado.Nombre, turno.Afiliado.Apellido);
												calendario.Descripcion = string.Format("{0} {1}", turno.Afiliado.Nombre, turno.Afiliado.Apellido);
												//Turno ocupado
												if (cancelacionProcess.GetAll().Where(o => o.turno_id == turno.Id).FirstOrDefault() != null)
												{
													calendario.Atendido = true;
													calendario.BackgroundColor = Framework.ColorEvento.CANCELADO;
													calendario.BorderColor = Framework.ColorEvento.CANCELADO;
												}
												else
												{
													calendario.Atendido = false;
													calendario.BorderColor = Framework.ColorEvento.OCUPADO;
													calendario.BorderColor = Framework.ColorEvento.OCUPADO;
												}
											}
										}
										else
										{
											//No tiene turno
											calendario.Atendido = false;
											calendario.IdTurno = -1;
											calendario.Titulo = "Disponible";
											calendario.Descripcion = "Disponible";
											calendario.BorderColor = Framework.ColorEvento.DISPONIBLE;
										}
									}
									else
									{
										calendario.Atendido = true;
										calendario.IdTurno = 0;
										calendario.Titulo = "Agenda cancelada";
										calendario.Descripcion = "Agenda cancelada";
										calendario.BackgroundColor = Framework.ColorEvento.CANCELADO;
										calendario.BorderColor = Framework.ColorEvento.CANCELADO;
									}

									listCalendario.Add(calendario);
									hora = hora.Add(new TimeSpan(1, 0, 0));
								}
							}
							fecha = fecha.AddDays(1);
						}
					}
					listEspecialidadColor.Add
						(
							new EspecialidadColorModel()
							{
								Especialidad = especialidadesProfesionalProcess.GetById(especialidadProfesionalId).Especialidad.descripcion,
								Color = Framework.ColorEspecialidad.lstColor[iColor]
							}
						);
					iColor += 1;
				}
				//Retorno un objeto con 2 atributos, uno de color de especialidad otro agenda
				dynamic jsonRetorno = new
					{
						Eventos = listCalendario,
						EspecialidadColor = listEspecialidadColor
					};
				return Json(jsonRetorno, JsonRequestBehavior.AllowGet);
			}
			else
				return Json(null, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult AtenderTurno(string TurnoId,string Sintomas,string Diagnostico)
		{
			Atencion atencion = new Atencion();
			Turno turno = turnoProcess.GetById(Convert.ToInt32(TurnoId));
			atencion.turno_id = turno.Id;
			atencion.hora_llegada = turno.Fecha.AddHours(turno.Hora.Hours).AddMinutes(turno.Hora.Minutes);
			atencion.hora_atencion = turno.Fecha.AddHours(turno.Hora.Hours).AddMinutes(turno.Hora.Minutes);
			atencion.sintomas = Sintomas;
			atencion.diagnostico = Diagnostico;
			atencion.bono_id = 0;
			atencion.createdon = DateTime.Now;
			atencion.createdby = "";
			atencion.changedon = new DateTime(1800,1,1);
			atencion.changedby = "";
			atencionProcess.Add(atencion);
			return Json(atencion, JsonRequestBehavior.AllowGet);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				agendaProcess.Dispose();
				especialidadesProfesionalProcess.Dispose();
				profesionalProcess.Dispose();
				turnoProcess.Dispose();
				atencionProcess.Dispose();
				cancelacionProcess.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}