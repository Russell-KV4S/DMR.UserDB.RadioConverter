using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KV4S.AmateurRadio.DMR.UserDB.RadioConverter
{
    [Serializable]
    class User
    {
        public string callsign
        {
            get;
            set;
        }

        public string city
        {
            get;
            set;
        }

        public string country
        {
            get;
            set;
        }

        public string fname
        {
            get;
            set;
        }

        public string radio_id
        {
            get;
            set;
        }

        public string remarks
        {
            get;
            set;
        }

        public string state
        {
            get;
            set;
        }

        public string surname
        {
            get;
            set;
        }

        public User()
        {
        }
    }
}
