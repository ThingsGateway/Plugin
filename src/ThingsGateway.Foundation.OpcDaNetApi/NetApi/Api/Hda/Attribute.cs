﻿

using System;


namespace Opc.Hda
{
    [Serializable]
    public class Attribute : ICloneable
    {
        private int m_id;
        private string m_name;
        private string m_description;
        private System.Type m_datatype;

        public int ID
        {
            get => m_id;
            set => m_id = value;
        }

        public string Name
        {
            get => m_name;
            set => m_name = value;
        }

        public string Description
        {
            get => m_description;
            set => m_description = value;
        }

        public System.Type DataType
        {
            get => m_datatype;
            set => m_datatype = value;
        }

        public override string ToString() => Name;

        public virtual object Clone() => MemberwiseClone();
    }
}
