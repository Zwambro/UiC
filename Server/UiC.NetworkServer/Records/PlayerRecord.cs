﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiC.NetworkServer.Extensions;
using UiC.ORM;
using UiC.ORM.SubSonic.SQLGeneration.Schema;

namespace UiC.NetworkServer.Records
{
    public class PlayerRelator
    {
        public static string FetchQuery = "SELECT * FROM players";
        public static string FetchQueryById = "SELECT * FROM players WHERE Id = @0";
        public static string FetchQueryByIP = "SELECT * FROM players WHERE IP = @0";
        public static string FetchQueryByHwid = "SELECT * FROM players WHERE Hwid = @0";
        public static string FetchQueryByNewHwid = "SELECT * FROM players WHERE NewHwid = @0";
        public static string FetchByXnAddr = "SELECT * FROM players WHERE XnAddr = @0";
    }

    [TableName("players")]
    public partial class PlayerRecord : IAutoGeneratedRecord
    {
        public PlayerRecord()
        {
            m_aliases = new List<string>();
        }

        [PrimaryKey("Id", true)]
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        private List<string> m_aliases;
        private string m_aliasesCSV;

        [Ignore]
        public List<string> Aliases
        {
            get
            {
                return m_aliases;
            }
            set
            {
                m_aliases = value;
                m_aliasesCSV = m_aliases.ToCSV(",");
            }
        }

        [JsonIgnore]
        public string AliasesCSV
        {
            get
            {
                return m_aliasesCSV;
            }
            set
            {
                m_aliasesCSV = value;
                m_aliases = !string.IsNullOrEmpty(m_aliasesCSV) ? m_aliasesCSV.FromCSV<string>(",").ToList() : new List<string>();
            }
        }



        public string XnAddr
        {
            get;
            set;
        }

        public string Guid
        {
            get;
            set;
        }

        public string Hwid
        {
            get;
            set;
        }

        public string NewHwid
        {
            get;
            set;
        }

        public string IP
        {
            get;
            set;
        }

        public DateTime RowAdded
        {
            get;
            set;
        }

        public DateTime RowUpdated
        {
            get;
            set;
        }

        public void BeforeSave(bool insert)
        {
            m_aliasesCSV = m_aliases.ToCSV(",");
            
        }
    }
}
