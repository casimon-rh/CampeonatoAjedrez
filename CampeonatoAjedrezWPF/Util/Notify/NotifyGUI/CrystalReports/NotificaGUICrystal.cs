using CrystalDecisions.CrystalReports.Engine;
using Notify.NotifyGUI.Visual;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.NotifyGUI.CrystalReports
{
    public class NotificaGUICrystal : INotificaGUI
    {
        private IDictionary<String, DataTable> _ReportSources;

        public IDictionary<String, DataTable> ReportSources
        {
            get { return _ReportSources; }
            set { if (value != null) _ReportSources = value; }
        }
        public string RptName { get; set; }
        public ReportClass RptObject { get; set; }
        public IDictionary<string, string> parametros { get; set; }
        public List<string> SubReports { get; set; }

        private bool? _SinDAO;

        public bool SinDAO
        {
            get { return _SinDAO ?? false; }
            set { _SinDAO = value; }
        }

        public string RutaImagen { get; set; }

        public NotificaGUICrystal() { }

        public NotificaGUICrystal(ReportClass rc)
        {
            RptObject = rc;
        }
        public NotificaGUICrystal(string rptName)
        {
            this.RptName = rptName;
        }
        public NotificaGUICrystal(IDictionary<String, DataTable> reportSources)
        {
            this.ReportSources = reportSources;
        }
        public NotificaGUICrystal(string rptName, IDictionary<String, DataTable> reportSources)
        {
            this.RptName = rptName;
            this.ReportSources = reportSources;
        }
        public void notificar()
        {
            try
            {
                if (RptObject == null)
                {
                    RptObject = new ReportClass();
                    RptObject.Load(RptName);
                }



                foreach (string sub in (SubReports ?? new List<string>()))
                    RptObject.OpenSubreport(sub);
                int i = 0;
                foreach (string key in ReportSources.Keys)
                {
                    if (i == 0)
                    {
                        RptObject.Database.Tables[0].SetDataSource(ReportSources[key] ?? new DataTable());
                        i++;
                    }
                    else
                    {
                        RptObject.Subreports[i - 1].Database.Tables[0].SetDataSource(ReportSources[key] ?? new DataTable());
                        i++;
                    }
                }
                Visor.getVisor(RptObject, parametros ?? new Dictionary<string, string>()).ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void notificaVacio()
        {
            Visor.enviaVisorVacio();
        }

        public void SetReportSources(IDictionary<String, DataTable> rs)
        {
            this.ReportSources = rs;
        }
        public ReportDocument RptDoc { get; set; }
        public void Process()
        {
            try
            {

                if (RptObject == null)
                {
                    RptDoc = new ReportDocument();
                    RptDoc.Load(RptName);
                    //Log.Log.logdebug("Carga de reporte en =" + RptName);
                }
                else
                    RptDoc = RptObject as ReportDocument;

                foreach (string sub in (SubReports ?? new List<string>()))
                {
                    RptDoc.OpenSubreport(sub);
                    //Log.Log.logdebug("Carga de subreporte =" + sub);
                }
                int i = 0;

                foreach (string key in ReportSources.Keys)
                {
                    if (i == 0)
                    {
                        RptDoc.Database.Tables[0].SetDataSource(ReportSources[key] ?? new DataTable());
                        i++;
                    }
                    else if (RptObject.Subreports.Count > 0)
                    {
                        RptDoc.Subreports[i - 1].Database.Tables[0].SetDataSource(ReportSources[key] ?? new DataTable());
                        i++;
                    }
                    else if (RptDoc.Database.Tables.Count > 1)
                    {
                        RptObject.Database.Tables[0].SetDataSource(ReportSources[key] ?? new DataTable());
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is LoadSaveReportException)
                    throw new Exception("No se encontró el archivo de reporte");
                throw ex;
            }
        }


        public void ProcessSinDao()
        {
            if (RptObject == null)
            {
                RptDoc = new ReportDocument();
                RptDoc.Load(RptName);
                //Log.Log.logdebug("Carga de reporte en =" + RptName);
            }
            else
                RptDoc = RptObject as ReportDocument;

            foreach (string sub in (SubReports ?? new List<string>()))
            {
                RptDoc.OpenSubreport(sub);
                //Log.Log.logdebug("Carga de subreporte =" + sub);
            }
        }
    }
}
