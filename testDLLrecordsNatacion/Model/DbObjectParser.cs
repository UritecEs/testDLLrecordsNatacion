using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testDLLrecordsNatacion.Model.Entities;

namespace testDLLrecordsNatacion.Model
{
    /// <summary>
    /// Parse DB reader objects into model objets or
    /// parse a model object into the parameters of a a sqlCommand
    /// </summary>
    internal class Parser
    {
        /// <summary>
        /// Creates an Athlete Object based on 
        /// the returned values of the Sql Reader
        /// </summary>
        /// <param name="reader">SqlReader providing the data returned by the query</param>
        /// <returns>The athlete object corresponding to that reader iteration</returns>
        internal Athlete DbReaderToAthlete(SqlDataReader reader)
        {
            Athlete atleta = new Athlete();
            atleta.Id = (int)reader["Id"];
            atleta.FullName = reader["FullName"].ToString();
            atleta.Birthdate = DateTime.Parse(reader["Birthdate"].ToString());
            atleta.Gender = reader["Gender"].ToString();
            atleta.Nation = reader["Nation"].ToString();
            atleta.License = reader["License"].ToString();
            atleta.ClubName = reader["ClubName"].ToString();
            atleta.ClubShortName = reader["ClubShortName"].ToString();
            atleta.ClubCode = (int)reader["ClubCode"];
            return atleta;
        }

        /// <summary>
        /// Fills the parameters of the sql command with 
        /// the values of the attributes of the object
        /// </summary>
        /// <param name="athlete">The Athlete object we want to insert/update</param>
        /// <returns>The SQL command with the parameters</returns>
        internal SqlCommand AthleteToSqlCommandParams(Athlete athlete, SqlCommand command)
        {
            command.Parameters.AddWithValue("@fullName", athlete.FullName);
            command.Parameters.AddWithValue("@birthdate", athlete.Birthdate);
            command.Parameters.AddWithValue("@gender", athlete.Gender ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@nation", athlete.Nation ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@license", athlete.License ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@clubCode", athlete.ClubCode);
            command.Parameters.AddWithValue("@clubName", athlete.ClubName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@clubShortName", athlete.ClubShortName ?? (object)DBNull.Value);
            return command;
        }

        /// <summary>
        /// Creates an Event Object based on 
        /// the returned values of the Sql Reader
        /// </summary>
        /// <param name="reader">SqlReader providing the data returned by the query</param>
        /// <returns>The Event object corresponding to that reader iteration</returns>
        internal Event DbReaderToEvent(SqlDataReader reader)
        {
            Event evento = new Event();
            evento.Id = (int)reader["Id"];
            evento.MeetName = reader["MeetName"].ToString();
            evento.MeetDate = DateTime.Parse(reader["MeetDate"].ToString());
            evento.Nation = reader["Nation"].ToString();
            evento.City = reader["City"].ToString();
            evento.Status = reader["Status"].ToString();
            evento.PoolLength = (int)reader["PoolLength"];
            evento.SessionNum = (int)reader["SessionNum"];
            evento.SessionName = reader["SessionName"].ToString();
            evento.GenderCategory = reader["GenderCategory"].ToString();
            evento.EventRound = reader["EventRound"].ToString();
            evento.EventCourse = reader["EventCourse"].ToString();
            evento.SwimDistance = (int)reader["SwimDistance"];
            evento.SwimStroke = reader["SwimStroke"].ToString();
            evento.SwimRelayCount = (int)reader["SwimRelayCount"];
            return evento;
        }

        /// <summary>
        /// Fills the parameters of the sql command with 
        /// the values of the attributes of the object
        /// </summary>
        /// <param name="evento">The Event object we want to insert/update</param>
        /// <returns>The SQL command with the parameters</returns>
        internal SqlCommand EventToSqlCommandParams(Event evento, SqlCommand command)
        {
            command.Parameters.AddWithValue("@MeetName", evento.MeetName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@MeetDate", evento.MeetDate);
            command.Parameters.AddWithValue("@Nation", evento.Nation ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@City", evento.City ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Status", evento.Status ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PoolLength", evento.PoolLength);
            command.Parameters.AddWithValue("@SessionNum", evento.SessionNum);
            command.Parameters.AddWithValue("@SessionName", evento.SessionName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@GenderCategory", evento.GenderCategory ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@EventRound", evento.EventRound ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@EventCourse", evento.EventCourse ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SwimDistance", evento.SwimDistance);
            command.Parameters.AddWithValue("@SwimStroke", evento.SwimStroke ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SwimRelayCount", evento.SwimRelayCount);
            return command;
        }

        /// <summary>
        /// Creates a Result Object based on 
        /// the returned values of the Sql Reader
        /// </summary>
        /// <param name="reader">SqlReader providing the data returned by the query</param>
        /// <returns>The Result object corresponding to that reader iteration</returns>
        internal Result DbReaderToResult(SqlDataReader reader)
        {
            Result result = new Result();
            result.Id = (int)reader["Id"];
            result.SplitDistance = (int)reader["SplitDistance"];
            result.SwimTime = reader["SwimTime"].ToString();
            result.Points = (int)reader["Points"];
            result.IsWaScoring = (int)reader["IsWaScoring"];
            result.EntryTime = reader["EntryTime"].ToString();
            result.Comment = reader["Comment"].ToString();
            result.AgeGroupMaxAge = (int)reader["AgeGroupMaxAge"];
            result.AgeGroupMinAge = (int)reader["AgeGroupMinAge"];
            result.EventId = (int)reader["EventId"];
            result.AthleteId = (int)reader["AthleteId"];
            return result;
        }

        /// <summary>
        /// Fills the parameters of the sql command with 
        /// the values of the attributes of the object
        /// </summary>
        /// <param name="result">The Result object we want to insert/update</param>
        /// <returns>The SQL command with the parameters</returns>
        internal SqlCommand ResultToSqlCommandParams(Result result, SqlCommand command)
        {
            command.Parameters.AddWithValue("@SplitDistance", result.SplitDistance);
            command.Parameters.AddWithValue("@SwimTime", result.SwimTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Points", result.Points);
            command.Parameters.AddWithValue("@IsWaScoring", result.IsWaScoring);
            command.Parameters.AddWithValue("@EntryTime", result.EntryTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Comment", result.Comment ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@AgeGroupMaxAge", result.AgeGroupMaxAge);
            command.Parameters.AddWithValue("@AgeGroupMinAge", result.AgeGroupMinAge);
            command.Parameters.AddWithValue("@EventId", result.EventId);
            command.Parameters.AddWithValue("@AthleteId", result.AthleteId);
            return command;
        }
    }
}
