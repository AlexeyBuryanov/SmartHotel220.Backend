using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Bookings.Queries
{
    /// <summary>
    /// Запрос на проверку заполненности номера
    /// </summary>
    public class OccupancyQuery
    {
        private readonly string _constr;

        public OccupancyQuery(string constr) => _constr = constr;

        public async Task<(double sunny, double notSunny)> GetRoomOcuppancy(DateTime date, int idRoom) =>
            (await GetRoomOcuppancy(date, idRoom, true), 0);

        private async Task<double> GetRoomOcuppancy(DateTime date, int idRoom, bool isSunny)
        {
            var day = date.Date;

            using (var con = new SqlConnection(_constr)) {
                await con.OpenAsync();

                const string sql = "PredictOccupation";

                using (var cmd = new SqlCommand(sql, con)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = day;
                    cmd.Parameters.Add("@idRoom", System.Data.SqlDbType.Int).Value = idRoom;
                    cmd.Parameters.Add("@isSunnyDay", System.Data.SqlDbType.Bit).Value = isSunny;

                    // Выполнение хранимой процедуры с параметрами
                    var percent = Convert.ToDouble(await cmd.ExecuteScalarAsync());

                    return percent;
                } // using
            } // using
        } // GetRoomOcuppancy
    } // OccupancyQuery
}