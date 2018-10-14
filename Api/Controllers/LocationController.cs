using Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data.OleDb;
using System.Web.Http;

namespace Api.Controllers
{
    public class LocationController : ApiController
    {
        [Route("api/location/get_location")]
        public string get_location()
        {
            JObject obj = new JObject();
            try
            {
                string sql = @"select * from tbl_location";
                obj["success"] = true;
                obj["data"] = DAL.serializeDataTable(sql, new OleDbCommand());
            }
            catch (Exception ex)
            {
                obj["success"] = false;
                obj["data"] = ex.Message + " " + ex.StackTrace;
            }
            return obj.ToString();
        }

        [Route("api/location/get_location")]
        public string get(int location_id)
        {
            JObject obj = new JObject(); 
            try
            {
                string sql = @"select * from tbl_location where location_id = @location_id";
                OleDbCommand cmd = new OleDbCommand();
                cmd.Parameters.AddWithValue("@location_id", location_id);
                obj["success"] = true;
                obj["data"] = DAL.serializeDataTable(sql, cmd);
            }
            catch (Exception ex)
            {
                obj["success"] = false;
                obj["data"] = ex.Message + " " + ex.StackTrace;
            }
            return obj.ToString();
        }

    }
}
