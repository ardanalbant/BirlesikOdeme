using BirlesikOdeme.Business;
using BirlesikOdeme.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.BusinessLayer.BL
{
    public class customerBL
    {
        private static customerBL _instance;

        public static customerBL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new customerBL();
               
            }

            return _instance;
        }

        public List<customerDTO> VerifyUnverifiedCustomers()
        {
            List<customerDTO> result = new List<customerDTO>();
            result = customerDAL.GetInstance().GetAllUnverifieds();

            return result;
        }
    }
}
