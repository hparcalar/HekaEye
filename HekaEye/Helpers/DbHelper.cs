using HekaEye.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Helpers
{
    public class DbHelper
    {
        string _connectionString = "Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "Db\\eye.db;";
        public bool ExecuteSql(string sql)
        {
            int affectedRows = 0;

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = sql;
                affectedRows = command.ExecuteNonQuery();

                connection.Close();
            }

            return affectedRows > 0;
        }

        public CaptureClassModel[] GetClassList()
        {
            CaptureClassModel[] data = new CaptureClassModel[0];

            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM CaptureClass";

                    List<CaptureClassModel> results = new List<CaptureClassModel>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var objId = reader.GetInt32(0);
                            var objName = reader.GetString(1);
                            var thresh = 0;

                            if (reader[2] != null && reader[2] != DBNull.Value)
                                thresh = reader.GetInt32(2);

                            results.Add(new CaptureClassModel
                            {
                                Id = objId,
                                Name = objName,
                                Threshold = thresh,
                            });
                        }
                    }

                    connection.Close();

                    data = results.ToArray();
                }
            }
            catch (Exception)
            {

            }

            return data;
        }

        public ClassSampleModel[] GetSamples(int classId)
        {
            ClassSampleModel[] data = new ClassSampleModel[0];

            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM ClassSample WHERE ClassId=" + classId;

                    List<ClassSampleModel> results = new List<ClassSampleModel>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var objId = reader.GetInt32(0);
                            var objName = reader.GetString(2);

                            results.Add(new ClassSampleModel
                            {
                                Id = objId,
                                ClassId = classId,
                                ImgFileName = objName,
                            });
                        }
                    }

                    connection.Close();

                    data = results.ToArray();
                }
            }
            catch (Exception)
            {

            }

            return data;
        }
    }
}
