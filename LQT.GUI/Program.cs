
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

using System;
using System.Windows.Forms;
using LQT.Core.UserExceptions;
using System.Threading;
using log4net;
using System.IO;
using System.Reflection;

namespace LQT.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new ThreadExceptionEventHandler(UIThreadExceptionHandler);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

                Application.DoEvents();
                new frmSplash().ShowDialog();                
                Application.Run(new LqtMainWindowForm());
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                //System.Diagnostics.Debugger.Break();
            }
        }
        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception)args.ExceptionObject;
            LogErr(ex);
            //ILog log = LogManager.GetLogger("RollingFileAppender");
            // log4net.Config.XmlConfigurator.Configure();
            // Exception ex = (Exception)args.ExceptionObject;
            // log.Error( ex.Message + ex.StackTrace);
            // foreach (log4net.Appender.IAppender app in log.Logger.Repository.GetAppenders())
            // {
            //     app.Name = "LogFileAppender";
            //     app.Close();
            // }
            // log.Logger.Repository.Shutdown();
             new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();

        }
        private static void UIThreadExceptionHandler(object sender, ThreadExceptionEventArgs t)
        {
            LogErr(t.Exception);
            //ILog log = LogManager.GetLogger("RollingFileAppender");
            //log4net.Config.XmlConfigurator.Configure();
            //log.Error(t.Exception.Message + t.Exception.StackTrace);
            //foreach (log4net.Appender.IAppender app in log.Logger.Repository.GetAppenders())
            //{
            //    app.Name = "LogFileAppender";
            //    app.Close();
            //}
            //log.Logger.Repository.Shutdown();
            new FrmShowError(CustomExceptionHandler.ShowExceptionText(t.Exception)).ShowDialog();
            //Application.Exit();
        }
        public static void LogErr(Exception ex)
        {
              
              string strDirectoryPath="";
            try
            {
                string directoryPath = strDirectoryPath;
                //if (!string.IsNullOrEmpty(strDirectoryPath))
                //{ "\\bin\\Debug\\"
                string path = Path.Combine(System.IO.Path.GetTempPath(), "error-log.txt");
                    //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "error-log.txt");
                    //StreamWriter swErrorLog = null;
         
                    if (File.Exists(path))
                    {
                        using (StreamWriter swErrorLog = new StreamWriter(path, true))
                        {
                            //write to the file

                            //swErrorLog = new StreamWriter(path, true); //append the error message
                            swErrorLog.WriteLine("Date and Time of Exception: " + DateTime.Now);
                            swErrorLog.WriteLine("Source of Exception: " + ex.StackTrace);
                            swErrorLog.WriteLine(" ");
                            swErrorLog.WriteLine("Error Message: " + ex.Message);
                            swErrorLog.WriteLine("------------------------------------------- ");
                            swErrorLog.WriteLine(" ");
                            //swErrorLog.WriteLine(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                            swErrorLog.Close();
                            //swErrorLog = null;
                        }
                    }
                    else
                    {
                        
                        using (StreamWriter swErrorLog = new StreamWriter(path, true))
                        {
                            //File.CreateText(path);
                            swErrorLog.WriteLine("Date and Time of Exception: " + DateTime.Now);
                            swErrorLog.WriteLine("Source of Exception: " + ex.StackTrace);
                            swErrorLog.WriteLine(" ");
                            swErrorLog.WriteLine("Error Message: " + ex.Message);
                            swErrorLog.WriteLine("------------------------------------------- ");
                            swErrorLog.WriteLine(" ");
                            swErrorLog.Close();
                        }
                    }
                }
            //}
            catch (NullReferenceException)
            {
                throw;
            }
        }
    }
}
