using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StoredProc.Data;
using StoredProcedure.Models;

namespace StoredProcedure.Controllers
{
    public class CarsController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _config { get; }

        public CarsController
            (
            StoredProcDbContext context,
            IConfiguration config
            )
        {
            _context = context;
            _config = config;

        }

        public IActionResult Index()
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchCars";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Car> model = new List<Car>();
                while (sdr.Read())
                {
                    var details = new Car();
                    details.carManufacturer = sdr["carManufacturer"].ToString();
                    details.carModel = sdr["carModel"].ToString();
                    details.carModelYear = Convert.ToInt32(sdr["carModelYear"]);
                    details.carColor = sdr["carColor"].ToString();
                    model.Add(details);
                }
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Index(string carManufacturer, string carModel, int carModelYear, string carColor)
        {
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchCars";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (carManufacturer != null)
                {
                    SqlParameter param = new SqlParameter("@CarManufacturer", carManufacturer);
                    cmd.Parameters.Add(param);
                }
                if (carModel != null)
                {
                    SqlParameter param = new SqlParameter("@CarModel", carModel);
                    cmd.Parameters.Add(param);
                }
                if (carModelYear != 0)
                {
                    SqlParameter param = new SqlParameter("@CarModelYear", carModelYear);
                    cmd.Parameters.Add(param);
                }
                if (carColor != null)
                {
                    SqlParameter param = new SqlParameter("@CarColor", carColor);
                    cmd.Parameters.Add(param);
                }
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Car> model = new List<Car>();
                while (sdr.Read())
                {
                    var details = new Car();
                    details.carManufacturer = sdr["carManufacturer"].ToString();
                    details.carModel = sdr["carModel"].ToString();
                    details.carModelYear = Convert.ToInt32(sdr["carModelYear"]);
                    details.carColor = sdr["carColor"].ToString();
                    model.Add(details);
                }
                return View(model);
            }
        }
    }
}