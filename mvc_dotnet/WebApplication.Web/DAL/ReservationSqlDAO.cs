using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;
using WebApplication.Web.Models.Account;

namespace WebApplication.Web.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {
        private readonly string connectionString;

        public ReservationSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int AddReservation(ReservationUserViewModel reservation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    conn.Open();

                    string sql = @"
                        begin tran;
                        Declare @resId int;
                        Insert Into Reservations Values (@address, @startTime, @endTime, @petName, @description); 
                        Select @resId = @@Identity;
                        Insert into users_reservations(userId, reservationId, status) values(@userId, @resId, 2);
                        Insert into users_reservations(userId, reservationId, status) values(@invitedUserId, @resId, 1);
                        commit tran;
                        Select @resId;
                        ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@address", reservation.Reservation.Address);
                    cmd.Parameters.AddWithValue("@startTime", reservation.Reservation.StartTime);
                    cmd.Parameters.AddWithValue("@endTime", reservation.Reservation.EndTime);
                    cmd.Parameters.AddWithValue("@petName", reservation.Reservation.PetName);
                    cmd.Parameters.AddWithValue("@userId", reservation.User.Id);
                    cmd.Parameters.AddWithValue("@description", reservation.Reservation.Description);
                    cmd.Parameters.AddWithValue("@invitedUserId", reservation.InvitedUser.Id);

                    int Id = Convert.ToInt32(cmd.ExecuteScalar());


                    return Id;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


        public IList<Reservation> GetAllReservationsForUser(int userId)
        {
            IList<Reservation> list = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId JOIN users as u on u.id = ur.userID WHERE u.id = @userId";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Reservation reservation = new Reservation();

                        reservation.ReservationId = Convert.ToInt32(rdr["id"]);
                        reservation.Address = Convert.ToString(rdr["address"]);
                        reservation.StartTime = Convert.ToDateTime(rdr["startTime"]);
                        reservation.EndTime = Convert.ToDateTime(rdr["endTime"]);
                        reservation.PetName = Convert.ToString(rdr["petName"]);
                        reservation.Description = Convert.ToString(rdr["description"]);

                        list.Add(reservation);

                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return list;
        }



        // Pending method
        public IList<Reservation> GetAllPendingReservations(int userId)
        {
            IList<Reservation> list = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId where userId = @userId and status = 1";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Reservation reservation = new Reservation();

                        reservation.ReservationId = Convert.ToInt32(rdr["id"]);
                        reservation.Address = Convert.ToString(rdr["address"]);
                        reservation.StartTime = Convert.ToDateTime(rdr["startTime"]);
                        reservation.EndTime = Convert.ToDateTime(rdr["endTime"]);
                        reservation.PetName = Convert.ToString(rdr["petName"]);
                        reservation.Description = Convert.ToString(rdr["description"]);



                        list.Add(reservation);

                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return list;
        }




        // Accepted method
        public IList<Reservation> GetAllAcceptedReservations(int userId)
        {
            IList<Reservation> list = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId where userId = @userId and status = 2";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Reservation reservation = new Reservation();

                        reservation.ReservationId = Convert.ToInt32(rdr["id"]);
                        reservation.Address = Convert.ToString(rdr["address"]);
                        reservation.StartTime = Convert.ToDateTime(rdr["startTime"]);
                        reservation.EndTime = Convert.ToDateTime(rdr["endTime"]);
                        reservation.PetName = Convert.ToString(rdr["petName"]);
                        reservation.Description = Convert.ToString(rdr["description"]);



                        list.Add(reservation);

                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return list;
        }

        public Reservation GetPendingReservation(int userId, int reservationId)
        {

            Reservation reservation = new Reservation();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId where userId = @userId and @reservationId = reservationId and status = 1";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        reservation = new Reservation();

                        reservation.ReservationId = Convert.ToInt32(rdr["id"]);
                        reservation.Address = Convert.ToString(rdr["address"]);
                        reservation.StartTime = Convert.ToDateTime(rdr["startTime"]);
                        reservation.EndTime = Convert.ToDateTime(rdr["endTime"]);
                        reservation.PetName = Convert.ToString(rdr["petName"]);
                        reservation.Description = Convert.ToString(rdr["description"]);

                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return reservation;
        }


        // Try to update the status of an invite depending on if they accept or decline...

        public void AcceptPendingReservation(int userId, int reservationId)
        {

            

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Update Users_Reservations set status = 2 where userId = @userId and @reservationId = reservationId";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    cmd.ExecuteScalar();
                    

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
           
        }

        public void DeclinePendingReservation(int userId, int reservationId)
        {



            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Update Users_Reservations set status = 3 where userId = @userId and @reservationId = reservationId";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    cmd.ExecuteScalar();


                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


        public Reservation GetAcceptedReservation(int userId, int reservationId)
        {

            Reservation reservation = new Reservation();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Reservations AS r JOIN Users_Reservations AS ur on r.id = ur.reservationId where userId = @userId and @reservationId = reservationId and status = 2";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        reservation = new Reservation();

                        reservation.ReservationId = Convert.ToInt32(rdr["id"]);
                        reservation.Address = Convert.ToString(rdr["address"]);
                        reservation.StartTime = Convert.ToDateTime(rdr["startTime"]);
                        reservation.EndTime = Convert.ToDateTime(rdr["endTime"]);
                        reservation.PetName = Convert.ToString(rdr["petName"]);
                        reservation.Description = Convert.ToString(rdr["description"]);

                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return reservation;
        }
    }
}
