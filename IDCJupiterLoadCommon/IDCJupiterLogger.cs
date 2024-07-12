using IDCJupiterLoadModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IDCJupiterLoadCommon
{
    public interface IIDCJupiterLogger
    {
        void LogData(HeaderData headerInfo, string shortMessage, string longMessage);
        void LogMessage(HeaderData headerInfo, string shortMessage, string longMessage);
        void LogException(HeaderData headerInfo, string shortMessage, Exception ex);
    }
    public class IDCJupiterLogger : IIDCJupiterLogger
    {
        private string _service = string.Empty;
        public IDCJupiterLogger() 
        {
            _service = "MyAPI";
        }

        public void LogData(HeaderData headerInfo, string shortMessage, string longMessage)
        {
            try
            {

                LogWriteDB.WriteLogData(headerInfo, new LogData()
                {
                    ShortMessage = shortMessage,
                    LongMessage = longMessage,
                    Service = _service,
                });

            }
            catch (Exception ex)
            {
                TextLogger.WriteEventLog(ex);
            }
        }

        public void LogException(HeaderData headerInfo, string shortMessage, Exception ex)
        {
            try
            {

                LogWriteDB.WriteLogException(headerInfo, new LogData()
                {
                    ShortMessage = shortMessage,
                    LongMessage = ex.ToString(),
                    StackTrace = ex.StackTrace,
                    BaseMessage = ex.GetBaseException().Message,
                    MessageType = "Error",
                    Service = _service,
                });

            }
            catch (Exception exex)
            {
                TextLogger.WriteEventLog(exex);
            }
        }

        public void LogMessage(HeaderData headerInfo, string shortMessage, string longMessage)
        {
            try
            {

                LogWriteDB.WriteLogMessage(headerInfo, new LogData()
                {
                    ShortMessage = shortMessage,
                    LongMessage = longMessage,
                    MessageType = "Message",
                    Service = _service,
                });

            }
            catch (Exception ex)
            {
                TextLogger.WriteEventLog(ex);
            }
        }

    }
    public class LogWriteDB : BaseData
    {
        public static void WriteLogException(HeaderData headerInfo, LogData logInfo)
        {
            try
            {
                using (TransactionScope journalTransaction = TransactionUtility.GetTransactionScope(TransactionUtility.OperationType.Supress))
                {
                    using (SqlConnection con = new SqlConnection(MySettingData.AppSettings?.LogConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(WriteConstants.LOG_EXCEPTION_SP, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            cmd.Parameters.Add("@SessionId", SqlDbType.NVarChar).Value = logInfo.SessionId;
                            cmd.Parameters.Add("@ShortMessage", SqlDbType.NVarChar).Value = logInfo.ShortMessage;
                            cmd.Parameters.Add("@Exception", SqlDbType.NVarChar).Value = logInfo.LongMessage;
                            cmd.Parameters.Add("@BaseMessage", SqlDbType.NVarChar).Value = logInfo.BaseMessage;
                            cmd.Parameters.Add("@StackTrace", SqlDbType.NVarChar).Value = logInfo.StackTrace;
                            cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = logInfo.Service;
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = headerInfo != null ? headerInfo.Id : 0;
                            cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TextLogger.WriteEventLog(ex);
            }
        }
        public static void WriteLogData(HeaderData headerInfo, LogData logInfo)
        {
            try
            {
                using (TransactionScope journalTransaction = TransactionUtility.GetTransactionScope(TransactionUtility.OperationType.Supress))
                {
                    using (SqlConnection con = new SqlConnection(MySettingData.AppSettings?.LogConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(WriteConstants.LOG_DATA_SP, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            cmd.Parameters.Add("@SessionId", SqlDbType.NVarChar).Value = logInfo.SessionId;
                            cmd.Parameters.Add("@ShortMessage", SqlDbType.NVarChar).Value = logInfo.ShortMessage;
                            cmd.Parameters.Add("@Xml", SqlDbType.NVarChar).Value = logInfo.LongMessage;
                            cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = logInfo.Service;
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = headerInfo != null ? headerInfo.Id : 0;
                            cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TextLogger.WriteEventLog(ex);
            }
        }
        public static void WriteLogMessage(HeaderData headerInfo, LogData logInfo)
        {
            try
            {
                using (TransactionScope journalTransaction = TransactionUtility.GetTransactionScope(TransactionUtility.OperationType.Supress))
                {
                    using (SqlConnection con = new SqlConnection(MySettingData.AppSettings?.LogConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(WriteConstants.LOG_WRITE_SP, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            cmd.Parameters.Add("@SessionId", SqlDbType.NVarChar).Value = logInfo.SessionId;
                            cmd.Parameters.Add("@ShortMessage", SqlDbType.NVarChar).Value = logInfo.ShortMessage;
                            cmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = logInfo.LongMessage;
                            cmd.Parameters.Add("@MessageType", SqlDbType.NVarChar).Value = logInfo.MessageType;
                            cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = logInfo.Service;
                            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = headerInfo != null ? headerInfo.Id : 0;
                            cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TextLogger.WriteEventLog(ex);
            }
        }
    }
    public static class TextLogger
    {
        private static object lockObject = new object();
        public static void WriteEventLog(Exception ex)
        {
            lock (lockObject)
            {
                try
                {

                    using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\EventLog.txt", true))
                    {
                        sw.WriteLine(DateTime.Now.GetStringDateTime() + ":" + ex.Source.ToString().Trim() + ":" + ex.Message.ToString().Trim() + ";Base Message:" + ex.GetBaseException().Message.ToString().Trim());
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception exex)
                {
                    exex.Data.Add("BaseException", ex);
                    //  throw exex;
                }
            }
        }
        public static void WriteEventLog(string message)
        {
            lock (lockObject)
            {
                try
                {
                    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\EventLog.txt"))
                    {
                        using (var fileStream = File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\EventLog.txt"))
                        {
                            fileStream.Close();
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\EventLog.txt", true))
                    {
                        sw.WriteLine(DateTime.Now.GetStringDateTime() + ":" + message);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception exex)
                {
                    throw exex;
                }
            }
        }
    }
    public static class teraExtensions
    {
        public static string GetStringDateTime(this DateTime input)
        {
            if (input == DateTime.MinValue)
            {
                return string.Empty;
            }

            return input.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }
}
