using MCGA.Constants;
using MCGA.Entities;
using MCGA.UI.Process;
using MCGA.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA.WebSite.Controllers
{
	[Authorize(Roles = "Administrador")]
	public class CalendarioGeneralController : Controller
    {
		// GET: CalendarioGeneral
		private AgendaProcess agendaProcess = new AgendaProcess();
		private EspecialidadProcess especialidadProcess = new EspecialidadProcess();
		private EspecialidadesProfesionalProcess especialidadesProfesionalProcess = new EspecialidadesProfesionalProcess();
		private ProfesionalProcess profesionalProcess = new ProfesionalProcess();
		private TurnoProcess turnoProcess = new TurnoProcess();
		private AtencionProcess atencionProcess = new AtencionProcess();
		private CancelacionProcess cancelacionProcess = new CancelacionProcess();
		

		// GET: Calendario
		[Route("calendario-profesional", Name = CalendarioGeneralControllerRoute.GetCalendarioProfesional)]
		public ActionResult CalendarioProfesional()
		{
			ViewBag.ProfesionalId = new SelectList(profesionalProcess.GetAll().Select(o => new { Id = o.Id, Profesional = string.Format("{0} {1}", o.Nombre, o.Apellido) }), "Id", "Profesional");
			return View();
		}

		public JsonResult GetCalendarioProfesional(DateTime fechaDesde, DateTime fechaHasta, string profesionalId)
		{
			if (fechaDesde == null)
				fechaDesde = new DateTime(1800, 1, 1);

			if (fechaHasta == null)
				fechaHasta = new DateTime(1800, 1, 1);

			int iColor = 0;
			//Reviso si tiene alguna agenda
			List<Agenda> listAtencion = agendaProcess.GetAll().Where(o => o.EspecialidadesProfesional.ProfesionalId == Convert.ToInt32(profesionalId) && fechaDesde >= o.fecha_desde && fechaHasta <= o.fecha_hasta).ToList();

			if (listAtencion.Count > 0)
			{
				List<CalendarioGeneralViewModel> listCalendario = new List<CalendarioGeneralViewModel>();
				List<CalendarioGeneralColorViewModel> listProfesionalColor = new List<CalendarioGeneralColorViewModel>();
				//Recorremos por especialidad
				foreach (int especialidadProfesionalId in listAtencion.Select(o => o.EspecialidadProfesionalId).Distinct().ToList())
				{
					//Recorro la lista filtrando por especialidadProfesionalId					
					foreach (Agenda agenda in listAtencion.Where(o => o.EspecialidadProfesionalId == especialidadProfesionalId).ToList())
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
									CalendarioGeneralViewModel calendario = new CalendarioGeneralViewModel();

									Turno turno = turnoProcess.GetAll().Where(o => o.Fecha == fecha && o.Hora == hora && o.EspecialidadProfesionalId == especialidadProfesionalId).FirstOrDefault();
									//Cargo variables generales
									calendario.FechaInicio = (new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hours, hora.Minutes, hora.Seconds)).ToString("yyyy-MM-dd HH:mm"); //"2018-10-29 17:00";
									calendario.FechaFin = (new DateTime(fecha.Year, fecha.Month, fecha.Day, (hora.Hours + 1), hora.Minutes, hora.Seconds)).ToString("yyyy-MM-dd HH:mm");
									calendario.FontColor = Framework.ColorEvento.NEGRO;
									calendario.BackgroundColor = Framework.ColorEspecialidad.lstColor[iColor];
									calendario.EspecialidadProfesionalId = especialidadProfesionalId;
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
												calendario.Cancelado = false;
											}
											else
											{
												//Tiene turno
												calendario.Atendido = false;
												calendario.IdTurno = turno.Id;
												calendario.Titulo = string.Format("{0} {1}", turno.Afiliado.Nombre, turno.Afiliado.Apellido);
												calendario.Descripcion = string.Format("{0} {1}", turno.Afiliado.Nombre, turno.Afiliado.Apellido);
												if (cancelacionProcess.GetAll().Where(o => o.turno_id == turno.Id).FirstOrDefault() != null)
												{ 
													calendario.Cancelado = true;
													calendario.BackgroundColor = Framework.ColorEvento.CANCELADO;
													calendario.BorderColor = Framework.ColorEvento.CANCELADO;
												}
												else
												{
													calendario.Cancelado = false;
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
											calendario.Cancelado = false;
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
					listProfesionalColor.Add
						(
							new CalendarioGeneralColorViewModel()
							{
								Descripcion = especialidadesProfesionalProcess.GetById(especialidadProfesionalId).Especialidad.descripcion,
								Color = Framework.ColorEspecialidad.lstColor[iColor]
							}
						);
					iColor += 1;
				}
				//Retorno un objeto con 2 atributos, uno de color de especialidad otro agenda
				dynamic jsonRetorno = new
				{
					Eventos = listCalendario,
					EspecialidadColor = listProfesionalColor
				};
				return Json(jsonRetorno, JsonRequestBehavior.AllowGet);
			}
			else
				return Json(null, JsonRequestBehavior.AllowGet);
		}

		[Route("calendario-especialidad", Name = CalendarioGeneralControllerRoute.GetCalendarioEspecialidad)]
		public ActionResult CalendarioEspecialidad()
		{
			ViewBag.EspecialidadId = new SelectList(especialidadProcess.GetAll().Select(o => new { Id = o.Id, Especialidad = string.Format("{0}", o.descripcion) }), "Id", "Especialidad");
			return View();
		}

		public JsonResult GetCalendarioEspecialidad(DateTime fechaDesde, DateTime fechaHasta, string especialidadId)
		{
			if (fechaDesde == null)
				fechaDesde = new DateTime(1800, 1, 1);

			if (fechaHasta == null)
				fechaHasta = new DateTime(1800, 1, 1);

			int iColor = 0;
			//Reviso si tiene alguna agenda
			List<Agenda> listAtencion = agendaProcess.GetAll().Where(o => o.EspecialidadesProfesional.EspecialidadId == Convert.ToInt32(especialidadId) && fechaDesde >= o.fecha_desde && fechaHasta <= o.fecha_hasta).ToList();

			if (listAtencion.Count > 0)
			{
				List<CalendarioGeneralViewModel> listCalendario = new List<CalendarioGeneralViewModel>();
				List<CalendarioGeneralColorViewModel> listProfesionalColor = new List<CalendarioGeneralColorViewModel>();
				//Recorremos por especialidad
				foreach (int profesionalId in listAtencion.Select(o => o.EspecialidadesProfesional.ProfesionalId).Distinct().ToList())
				{
					//Recorro la lista filtrando por especialidadProfesionalId					
					foreach (Agenda agenda in listAtencion.Where(o => o.EspecialidadesProfesional.ProfesionalId == profesionalId).ToList())
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
									CalendarioGeneralViewModel calendario = new CalendarioGeneralViewModel();

									Turno turno = turnoProcess.GetAll().Where(o => o.Fecha == fecha && o.Hora == hora && o.EspecialidadProfesionalId == agenda.EspecialidadProfesionalId).FirstOrDefault();
									//Cargo variables generales
									calendario.FechaInicio = (new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hours, hora.Minutes, hora.Seconds)).ToString("yyyy-MM-dd HH:mm"); //"2018-10-29 17:00";
									calendario.FechaFin = (new DateTime(fecha.Year, fecha.Month, fecha.Day, (hora.Hours + 1), hora.Minutes, hora.Seconds)).ToString("yyyy-MM-dd HH:mm");
									calendario.FontColor = Framework.ColorEvento.NEGRO;
									calendario.BackgroundColor = Framework.ColorEspecialidad.lstColor[iColor];
									calendario.EspecialidadProfesionalId = agenda.EspecialidadProfesionalId;
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
												calendario.Cancelado = false;
											}
											else
											{
												//Tiene turno
												calendario.Atendido = false;
												calendario.IdTurno = turno.Id;
												calendario.Titulo = string.Format("{0} {1}", turno.Afiliado.Nombre, turno.Afiliado.Apellido);
												calendario.Descripcion = string.Format("{0} {1}", turno.Afiliado.Nombre, turno.Afiliado.Apellido);
												if (cancelacionProcess.GetAll().Where(o => o.turno_id == turno.Id).FirstOrDefault() != null)
												{
													calendario.Cancelado = true;
													calendario.BackgroundColor = Framework.ColorEvento.CANCELADO;
													calendario.BorderColor = Framework.ColorEvento.CANCELADO;
												}
												else
												{
													calendario.Cancelado = false;
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
											calendario.Cancelado = false;
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
					Profesional profesional = profesionalProcess.GetById(profesionalId);
					listProfesionalColor.Add
						(
							new CalendarioGeneralColorViewModel()
							{
								Descripcion = string.Format("{0} {1}", profesional.Nombre, profesional.Apellido),
								Color = Framework.ColorEspecialidad.lstColor[iColor]
							}
						);
					iColor += 1;
				}
				//Retorno un objeto con 2 atributos, uno de color de especialidad otro agenda
				dynamic jsonRetorno = new
				{
					Eventos = listCalendario,
					EspecialidadColor = listProfesionalColor
				};
				return Json(jsonRetorno, JsonRequestBehavior.AllowGet);
			}
			else
				return Json(null, JsonRequestBehavior.AllowGet);
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
				especialidadProcess.Dispose();
				cancelacionProcess.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}